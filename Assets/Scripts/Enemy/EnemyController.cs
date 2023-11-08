using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrf;

    [SerializeField] private EnemyMapController enemyMap;

    [SerializeField] private List<Enemy> lstEnemy;
    [SerializeField] private Transform enemyHolder;
    [SerializeField] private float delayMove;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void InitEnemy()
    {
        SpawnEnemy(delayMove);
    }

    public void SpawnEnemy(float delay)
    {
        int numberEnemy = enemyMap.LstFirstPosition.LstPosition.Length;
        Vector3 initPosition = new Vector3(0, 5, 0);
        for (int i = 0; i < numberEnemy; i++)
        {
            Enemy newEnemy = Instantiate(enemyPrf);
            lstEnemy.Add(newEnemy);
            newEnemy.gameObject.transform.parent = enemyHolder;

            newEnemy.transform.position = initPosition;
            newEnemy.currentPos = i;
            Vector3 targetPos = enemyMap.LstFirstPosition.LstPosition[i].transform.position;

            newEnemy.LstHexagonalPos = enemyMap.LstFirstPosition.LstPosition;
            newEnemy.LastPos = enemyMap.LstLastPosition.LstPosition[i];
            newEnemy.transform.DOMove(targetPos, delay).OnComplete(()=>{
                newEnemy.MoveAround(.5f);
            });
        }
    }
}
