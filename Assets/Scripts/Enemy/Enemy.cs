using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private int health = 50;
    private Transform[] lstHexagonalPos;
    public Transform[] LstHexagonalPos {
        get => lstHexagonalPos;
        set => lstHexagonalPos = value;
    }

    [SerializeField] private float internalY;
    [SerializeField] private float internalMoveTime;

    private Transform lastPos;
    public Transform LastPos
    {
        get => lastPos;
        set => lastPos = value;
    }

    public int currentPos { get; set; }

    public void MoveAround(float timeDelay)
    {
        StartCoroutine(Move(timeDelay));
    }

    IEnumerator Move(float delayTime)
    {
        for(int i = 0; i < lstHexagonalPos.Length; i++)
        {
            if(currentPos < lstHexagonalPos.Length - 1)
            {
                
                currentPos++;
            }
            else
            {
                currentPos = 0;

            }
            this.transform.DOMove(lstHexagonalPos[currentPos].position, delayTime);
            yield return new WaitForSeconds(delayTime);
        }

        this.transform.DOMove(lastPos.position, delayTime).OnComplete(()=> {
            if (!SpaceShip.instance.IsAutoShoot()) SpaceShip.instance.AutoShoot(true);
            LoopMoveUpDown(internalY);
        });
    }

    private void LoopMoveUpDown(float internalY)
    {
        this.transform.DOMoveY(this.transform.position.y + internalY, internalMoveTime).OnComplete(()=> {
            LoopMoveUpDown(-internalY);
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health--;
            if(health <=0)
            {
                this.gameObject.SetActive(false);
            }
        }

    }
}
