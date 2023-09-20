using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BotSpawn : MonoBehaviour
{
    public GameObject botPrefab; // Kéo thả Prefab của con bot vào đây
    public GameObject player;
    public int numberOfBots; // Số lượng con bot cần sao chép
    public float spawnInterval = 0.5f; // Khoảng thời gian giữa mỗi lần sao chép
    public Vector3[] spawnPositions; // Mảng chứa các vị trí xuất hiện
    
    public static List<GameObject> ListPlayer = new List<GameObject>();
    private int currentBotIndex = 0;

    private IEnumerator Start()
    {
        ListPlayer.Add(player);
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
        Debug.Log(ListPlayer.Count);
    }
}