using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject Player;
    public bool hasBomb;
    [SerializeField]
    private GameObject Hand;
    private float _receiveAt = float.MinValue;
    [SerializeField]
    private float _delayToPassBomb = 2f;
    private Bomb bomb;
    private bool alive;

    private bool CanPassBomb => Time.time - _receiveAt >= _delayToPassBomb;

    public void ReceiveBomb(Transform bomb)
    {
        bomb.parent = Hand.transform;
        bomb.localPosition = Vector3.zero;
        _receiveAt = Time.time;
        hasBomb = true;

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

    private void Boom()
    {
        if (bomb.CountdownTime <= 0)
        {
            if (hasBomb)
            {
                BotSpawn.ListPlayer.Remove(gameObject);
                Destroy(gameObject);
                alive = false;
            }
        }
    }

    private void Start()
    {
        alive = true;
    }
    void Update()
    {
        bomb = Hand.GetComponentInChildren<Bomb>();
        Boom();
    }
}
