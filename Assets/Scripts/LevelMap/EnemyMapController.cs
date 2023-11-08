using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMapController : MonoBehaviour
{
    [SerializeField] private PositionsController lstFristPosition;
    public PositionsController LstFirstPosition
    {
        get => lstFristPosition;
    }
    [SerializeField] private PositionsController lstLastPosition;
    public PositionsController LstLastPosition
    {
        get => lstLastPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
