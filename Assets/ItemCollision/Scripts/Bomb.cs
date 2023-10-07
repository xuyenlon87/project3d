using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public Text CountdownBomb;
    private bool isCountingDown ;
    public float CountdownTime;
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

    public void DelayNewBom()
    {
        Invoke("NewBom", 5f);
    }
    void StartCountdown()
    {
        CountdownBomb.text = Mathf.CeilToInt(CountdownTime).ToString();
        StartCoroutine(CountdownCoroutine());
    }
    private IEnumerator CountdownCoroutine()
    {
        Debug.Log("countdown");
        yield return new WaitForSeconds(delayTime);
        isCountingDown = true;
    }
    void NewBom()
    {
        if (BotSpawn.ListPlayer.Count >= 1)
        {
            GameObject newBom = Instantiate(bombPrefab);
            newBom.SetActive(true);
            Bomb bombComponent = newBom.GetComponent<Bomb>();
            bombComponent.enabled = true;
            
            var index = Random.Range(0, BotSpawn.ListPlayer.Count - 1);
            GameObject loser = BotSpawn.ListPlayer[index];
            Debug.Log("loser index: " + index);
            if (loser.CompareTag("Player"))
            {
                var abc = loser.GetComponent<PlayerCollider>();
                if(abc != null)
                {
                    abc.ReceiveBomb(newBom.transform);
                }
                else
                {
                    Debug.Log("NotPlayer");
                }

            }
            else if (loser.CompareTag("Bot"))
            {
                var acb = loser.GetComponent<BotCollider>();
                if (acb != null)
                {
                    acb.ReceiveBomb(newBom.transform);
                }
                else
                {
                    Debug.Log("NotBot");
                }
            }
            else
            {
                Debug.Log("bomb nothing");

            }
            SetupCountdownTime();
            StartCountdown();
        }
    }

    void SetupCountdownTime()
    {
        if (BotSpawn.ListPlayer.Count >= 6)
        {
            CountdownTime = 8f;
        }
        else if (BotSpawn.ListPlayer.Count >= 3 && BotSpawn.ListPlayer.Count < 6)
        {
            CountdownTime = 10f;
        }
        else if (BotSpawn.ListPlayer.Count == 2)
        {
            CountdownTime = 15f;
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
                Destroy(gameObject);
                Debug.Log("delbom");
                NewBom();
            }
        }
    }
}
