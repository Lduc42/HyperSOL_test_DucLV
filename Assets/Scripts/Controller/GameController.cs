using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private GameObject lobby;
    [SerializeField] private Button playBtn;

    // Start is called before the first frame update
    void Start()
    {
        InitBtn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitBtn()
    {
        playBtn.onClick.AddListener(()=> {
            enemyController.InitEnemy();
            lobby.gameObject.SetActive(false);
        });
    }
}
