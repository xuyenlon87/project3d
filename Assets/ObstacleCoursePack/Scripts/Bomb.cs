using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public Text CountdownBomb;
    private bool isCountingDown = false;
    public float CountdownTime = 5f;
    public float delayTime = 1f;
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
        yield return new WaitForSeconds(delayTime);
        isCountingDown = true;
    }

    void NewBom()
    {
        if (BotSpawn.ListPlayer.Count >= 1)
        {
            GameObject newBom = Instantiate(bombPrefab);
            var index = Random.Range(0, BotSpawn.ListPlayer.Count - 1);
            var loser = BotSpawn.ListPlayer[index];
            if (loser.CompareTag("Player"))
            {
                Debug.Log("bomb player");
                loser = GameObject.FindGameObjectWithTag("Player");
                var abc = loser.GetComponent<PlayerCollider>();
                if (abc == null)
                //{
                //    Debug.Log($"loser: {loser.name}\nindex: {index}");
                //}
                abc.ReceiveBomb(newBom.transform);

            }
            else if (loser.CompareTag("Bot"))
            {
                loser = GameObject.FindGameObjectWithTag("Bot");
                var acb = loser.GetComponent<BotCollider>();
                if(acb == null)
                {
                    Debug.Log("full");
                }
                acb.ReceiveBomb(newBom.transform);
            }
            else
            {
                Debug.Log("bomb nothing");

            }
            StartCountdown();
        }
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
