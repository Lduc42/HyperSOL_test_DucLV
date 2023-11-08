using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private Gun[] gunController;

    private Vector3 offset; 
    private bool isDragging = false;

    public static SpaceShip instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void OnValidate()
    {
        gunController = GetComponentsInChildren<Gun>();
    }

    private void Start()
    {
        AutoShoot(false);
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    public void AutoShoot(bool isActive)
    {
        for(int i = 0; i < gunController.Length; i++)
        {
            gunController[i].AutoShoot = isActive;
        }
    }

    public bool IsAutoShoot() {
        for (int i = 0; i < gunController.Length; i++)
        {
            if (gunController[i].AutoShoot == false) return false;
        }
        return true;
    }
}
