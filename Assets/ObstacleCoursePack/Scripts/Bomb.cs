using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public Text CountdownBomb;
    private bool isCountingDown = false;
    private float CountdownTime = 5f;
    private BotState botState;
    private PlayerCollider playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown)
        {
            CountdownTime -= Time.deltaTime;
            CountdownBomb.text = Mathf.CeilToInt(CountdownTime).ToString();
            if (CountdownTime <= 0f)
            {
                Debug.Log("Boom");
                if (botState.hasBomb)
                {
                    Destroy(botState);
                }
                if (playerCollider.hasBomb)
                {
                    Destroy(playerCollider);
                }
                isCountingDown = false;

            }
        }
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
}
