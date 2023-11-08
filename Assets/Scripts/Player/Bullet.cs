using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float timeLive = 2f;
    private Transform bulletHolder;


    public Vector2 direction = new Vector2(1, 0);
    public float speed = 2;

    public Vector2 velocity;

    public bool isEnemy = false;

    public float TimeLive
    {
        get => timeLive;
        set => timeLive = value;
    }

    public Transform BulletHolder
    {
        get => bulletHolder;
        set => bulletHolder = value;
    }
    private void OnEnable()
    {
        //prePos.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }

    public void SetInitStatus(Transform pos)
    {
        StartCoroutine(DelaySetDefaultPos(pos, timeLive));
        
    }

    IEnumerator DelaySetDefaultPos(Transform pos, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        SetDefaultPos(pos, timeDelay);
    }

    private void SetDefaultPos(Transform pos, float timeDelay)
    {
        this.gameObject.SetActive(false);
        this.transform.position = pos.position;
        this.transform.parent = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) 
        {
            Debug.Log("va cham");
            SetDefaultPos(bulletHolder, 0f);
        }

    }
}
