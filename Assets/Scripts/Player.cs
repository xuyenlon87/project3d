using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public InputField nameInput;
    public Text playerNameText;

    public void SaveName()
    {
        string playerName = nameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
    }
    // Start is called before the first frame update
    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Anonymous");
        playerNameText.text = playerName;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
