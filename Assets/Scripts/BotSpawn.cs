using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class BotSpawn : MonoBehaviour
{
    public GameObject botPrefab; // Kéo thả Prefab của con bot vào đây
    public int numberOfBots; // Số lượng con bot cần sao chép
    public float spawnInterval = 0.5f; // Khoảng thời gian giữa mỗi lần sao chép
    public Vector3[] spawnPositions; // Mảng chứa các vị trí xuất hiện

    private static List<GameObject> _listPlayer = new List<GameObject>();
    
    public List<GameObject> debugPlayer;
    private int currentBotIndex = 0;


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

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(spawnInterval);
        while (currentBotIndex < numberOfBots)
        {
            Vector3 spawnPosition = spawnPositions[currentBotIndex];
            GameObject newBot = Instantiate(botPrefab, spawnPosition, Quaternion.identity);
            ListPlayer.Add(newBot);
            currentBotIndex++;

            yield return new WaitForSeconds(spawnInterval);
            //Tạo list người chơi còn lại
            //khi 1 tk chết => xóa khỏi list
            //goị hàm random range 0 - count-1 => index tìm
            //check loser = bot hay player
            //neu la bot thi get component bot, con neu la player thi get componnet cua player

        }
    }

    private void Update()
    {

    }
}