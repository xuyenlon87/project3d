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
        RefenceBom();
        Debug.Log($"loser: {name} - receive bom: {bomb.name} -");
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
        else if (other.gameObject.CompareTag("Rotator"))
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Rotator"))
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            hasBomb = false;
        }
    }

    private void BoomBot()
    {
        if(bomb != null && bomb.CountdownTime <= 0)
        {
            if (hasBomb)
            {
                BotSpawn.ListPlayer.Remove(gameObject);
                //Destroy(gameObject);
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
    }

    void RefenceBom()
    {
        bomb = hand.GetComponentInChildren<Bomb>();
    }
    private void Update()
    {
        hand = GameObject.FindGameObjectWithTag("BotHand");
        bomb = hand.GetComponentInChildren<Bomb>();
        BoomBot();
    }
}
