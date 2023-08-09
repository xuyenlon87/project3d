using System.Collections;
using UnityEngine;

public class BotSpawn : MonoBehaviour
{
    public GameObject botPrefab; // Kéo thả Prefab của con bot vào đây
    public int numberOfBots; // Số lượng con bot cần sao chép
    public float spawnInterval = 0.5f; // Khoảng thời gian giữa mỗi lần sao chép
    public Vector3[] spawnPositions; // Mảng chứa các vị trí xuất hiện

    private int currentBotIndex = 0;

    private IEnumerator Start()
    {
        while (currentBotIndex < numberOfBots)
        {
            Vector3 spawnPosition = spawnPositions[currentBotIndex];
            GameObject newBot = Instantiate(botPrefab, spawnPosition, Quaternion.identity);
            currentBotIndex++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}