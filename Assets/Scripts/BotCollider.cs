using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCollider : MonoBehaviour
{
    
    [SerializeField]
    private GameObject hand;
    private float _receiveAt;
    private float _delayToPassBomb = 1f;

    private bool CanPassBomb => Time.time - _receiveAt >= _delayToPassBomb;

    private void ReceiveBomb(Transform bomb)
    {
        if (CanPassBomb)
        {
            BotMovement.isBomb = true;
            bomb.parent = hand.transform;
            bomb.localPosition = Vector3.zero;
            _receiveAt = Time.time;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (/*other.CompareTag("Player") || other.CompareTag("Bot")*/ other.CompareTag("Bomb"))
        {
            BotMovement.isBomb = true;
            ReceiveBomb(other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (/*other.CompareTag("Player") || other.CompareTag("Bot")*/ other.CompareTag("Bomb"))
        {
            BotMovement.isBomb = false;
            Debug.Log("exitbom");
        }
    }
}
