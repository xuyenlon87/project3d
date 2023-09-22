using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject hand;
    private BotState botState;
    private float _receiveAt;
    [SerializeField]
    private float _delayToPassBomb = 2f;
    private bool alive;
    private Bomb bomb;

    public BotState BotState
    {
        get
        {
            if (!botState)
                botState = GetComponent<BotState>();
            return botState;
        }
    }
    private bool hasBomb
    {
        get
        {
            return BotState.hasBomb;
        }
        set
        {
            BotState.hasBomb = value;
        }
    }

    private bool CanPassBomb => Time.time - _receiveAt >= _delayToPassBomb;

    public void ReceiveBomb(Transform bomb)
    {
        Debug.Log($"loser: {name} - receive bom: {bomb.name}");
        hasBomb = true;
        bomb.parent = hand.transform;
        bomb.localPosition = Vector3.zero;
        _receiveAt = Time.time;
        RefenceBom();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (hasBomb && CanPassBomb)
        {
            if (other.CompareTag("Player"))
            {
                var player = other.GetComponent<PlayerCollider>();
                player.ReceiveBomb(GetBomb());
                hasBomb = false;
            }
            else if (other.CompareTag("Bot"))
            {
                var bot = other.GetComponent<BotCollider>();
                bot.ReceiveBomb(GetBomb());
                hasBomb = false;
            }
        }

    }

    private void Boom()
    {
        if(bomb.CountdownTime <= 0)
        {
            if (hasBomb)
            {
                BotSpawn.ListPlayer.Remove(gameObject);
                Destroy(gameObject);
                alive = false;
            }
        }
    }
    public Transform GetBomb()
    {
        if (hasBomb)
            return hand.transform.GetChild(0);
        else
            return null;
    }
    private void Start()
    {
        bomb = hand.GetComponentInChildren<Bomb>();
        alive = true;
    }

    void RefenceBom()
    {
        bomb = hand.GetComponentInChildren<Bomb>();
    }
    private void Update()
    {
        Boom();
        Debug.Log (BotSpawn.ListPlayer.Count);
    }
}
