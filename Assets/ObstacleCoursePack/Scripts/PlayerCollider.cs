using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField]
    private bool hasBomb;
    public GameObject Hand;
    private float _receiveAt = float.MinValue;
    private float _delayToPassBomb = 2f;

    private bool CanPassBomb => Time.time - _receiveAt >= _delayToPassBomb;

    public void ReceiveBomb(Transform bomb)
    {
        bomb.parent = Hand.transform;
        bomb.localPosition = Vector3.zero;
        _receiveAt = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot"))
        {
            if (hasBomb && CanPassBomb)
            {
                var bot = other.GetComponent<BotCollider>();
                bot.ReceiveBomb(GetBomb());
                hasBomb = false;
            }
        }
    }

    private Transform GetBomb()
    {
        if (hasBomb)
            return Hand.transform.GetChild(0);
        else
            return null;
    }

}
