using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class BotSpawn : MonoBehaviour
{
    public GameObject botPrefab; // Kéo thả Prefab của con bot vào đây
    public int numberOfBots; // Số lượng con bot cần sao chép
    public int numberOfPlayer;
    public float spawnInterval = 0.5f; // Khoảng thời gian giữa mỗi lần sao chép
    public Vector3[] spawnPositionsBot; // Mảng chứa các vị trí xuất hiện
    public Vector3 spawnPositionPlayer;
    public GameObject playerPrefab;
    public List<GameObject> hatsList = new List<GameObject>();
    public GameObject hatBot;
    public Text nameBot;
    public string[] botNames;


    private static List<GameObject> _listPlayer = new List<GameObject>();
    
    public List<GameObject> debugPlayer;
    private int currentBotIndex = 0;
    private int currentPlayerIndex = 0;


    public static List<GameObject> ListPlayer { get
        {
            if (_listPlayer == null)
            {
                _listPlayer = new List<GameObject>();
            }
            return _listPlayer;
        }
    }


    private void Awake()
    {
        debugPlayer = _listPlayer;
    }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        if (currentPlayerIndex < numberOfPlayer)
        {
             GameObject newPlayer = Instantiate(playerPrefab, spawnPositionPlayer, Quaternion.identity);
            currentPlayerIndex++;
            ListPlayer.Add(newPlayer);


        }
        yield return new WaitForSeconds(spawnInterval);
        while (currentBotIndex < numberOfBots)
        {
            Vector3 spawnPosition = spawnPositionsBot[currentBotIndex];
            GameObject newBot = Instantiate(botPrefab, spawnPosition, Quaternion.identity);
            ListPlayer.Add(newBot);
            //HatBot randomHat = GetRandomHat();
            //if (randomHat != null)
            //{
            //    GameObject hatPrefab = Instantiate(randomHat.hatPrefab, hatBot.transform.position, Quaternion.identity);
            //    hatPrefab.transform.parent = hatBot.transform;
            //}
            Text nameText = newBot.GetComponentInChildren<Text>();
            string randomBotName = GetRandomBotName();
            //Debug.Log($"botname: {randomBotName}");
            nameText.text = randomBotName;
            currentBotIndex++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    //private GetRandomHat()
    //{
    //    if (hatsList.Count > 0)
    //    {
    //        int randomIndex = Random.Range(0, hatsList.Count);
    //        return hatsList[randomIndex];
    //    }
    //    return null;
    //}

    private string GetRandomBotName()
    {
        int randomIndex = Random.Range(0, botNames.Length);
        return botNames[randomIndex];

    }
    private void Update()
    {

    }
}