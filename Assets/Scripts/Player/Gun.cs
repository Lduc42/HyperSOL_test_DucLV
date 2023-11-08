using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private float timeLive;
    private List<Bullet> bulletPool = new();
    public int powerUpLevelRequirement = 0;

    public Bullet bullet;
    Vector2 direction;

    public bool AutoShoot {get; set;}
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0.0f;
    float shootTimer = 0f;
    float delayTimer = 0f;

    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        InitBulletPool();

    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;

        if (AutoShoot && bulletPool.Count >= poolSize)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
            
        }
        else
        {
            
        }
    }

    public void InitBulletPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            Bullet tempBullet = go.GetComponent<Bullet>();
            bulletPool.Add(tempBullet);
            tempBullet.TimeLive = timeLive;
            tempBullet.BulletHolder = this.transform;
            go.transform.position = this.transform.position;
            go.transform.parent = this.transform;
            go.gameObject.SetActive(false);
        }
    }

    public GameObject CreatBullet()
    {
        foreach(Bullet bullet in bulletPool)
        {
            if (!bullet.gameObject.activeSelf) {
                
                return bullet.gameObject;
            } 
        }

        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        go.SetActive(false);
        Bullet goBullet = go.GetComponent<Bullet>();
        go.transform.parent = this.transform;
        bulletPool.Add(goBullet);
        return go;
    }

    public void Shoot()
    {
        GameObject go = CreatBullet();
        go.gameObject.SetActive(true);
        go.gameObject.transform.SetParent(null);
        Bullet goBullet = go.GetComponent<Bullet>();
        go.transform.rotation = transform.rotation;
        goBullet.direction = transform.up;
        goBullet.SetInitStatus(this.transform);
    }
}
