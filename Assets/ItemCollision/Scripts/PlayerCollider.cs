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
    private Rigidbody rb;
    [SerializeField]

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private bool CanPassBomb => Time.time - _receiveAt >= _delayToPassBomb;

    public void ReceiveBomb(Transform bomb)
    {
        //Debug.Log($"loser: {name} - receive bom: {bomb.name}");
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

            else if (other.gameObject.CompareTag("Rotator"))
            {
            gameObject.GetComponent<Collider>().isTrigger = false;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Rotator") )
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }


    public Transform GetBomb()
    {
        if (hasBomb && Hand != null)
            return Hand.transform.GetChild(0);
        else
            return null;
    }

    private void Boom()
    {
        if (bomb != null && bomb.CountdownTime <= 0)
        {
            if (hasBomb)
            {
                BotSpawn.ListPlayer.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
    }
    void Update()
    {
        Hand = GameObject.FindGameObjectWithTag("PlayerHand");
        //bomb = Hand.GetComponentInChildren<Bomb>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Boom();
    }
}
