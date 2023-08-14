using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField]
    private bool isBomb;
    public GameObject Hand;
    private float _receiveAt;
    private float _delayToPassBomb = 1f;

    private bool CanPassBomb => Time.time - _receiveAt >= _delayToPassBomb;

    private void ReceiveBomb(Transform bomb)
    {
        if (CanPassBomb)
        {
            bomb.parent = Hand.transform;
            bomb.localPosition = Vector3.zero;
            _receiveAt = Time.time;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            isBomb = true;
            ReceiveBomb(other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            isBomb = false;
            Debug.Log("exitbom");
        }
    }
}
