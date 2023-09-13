using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    public Text CountdownBomb;
    private bool isCountingDown = false;
    public float CountdownTime = 5f;
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
            }
        }
    }
}
