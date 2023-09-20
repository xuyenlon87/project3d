using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public Text CountdownBomb;
    private bool isCountingDown = false;
    public float CountdownTime = 5f;
    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        Boom();
    }
    void StartCountdown()
    {
        CountdownBomb.text = Mathf.CeilToInt(CountdownTime).ToString();
        StartCoroutine(CountdownCoroutine());
    }
    private IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSeconds(CountdownTime);
        isCountingDown = true;
    }

    void  NewBom()
    {
        GameObject newBom = Instantiate(bombPrefab);
        var index = Random.Range(0,BotSpawn.ListPlayer.Count - 1);
        var recievePlayer = BotSpawn.ListPlayer[index];
        if (recievePlayer == gameObject.CompareTag("Player"))
        {
            var abc = recievePlayer.GetComponent<PlayerCollider>();
           
            
        }
        else if (recievePlayer == gameObject.CompareTag("Bot"))
        {
            var abc = recievePlayer.GetComponent<BotCollider>();
            abc.ReceiveBomb(transform);
        }
        StartCountdown();
    }
    public void Boom()
    {
        if (isCountingDown)
        {
            CountdownTime -= Time.deltaTime;
            CountdownBomb.text = Mathf.CeilToInt(CountdownTime).ToString();
            if (CountdownTime <= 0f)
            {
                isCountingDown = false;
                Debug.Log("Boom");
                Destroy(gameObject);
                NewBom();
            }
        }
    }
}
