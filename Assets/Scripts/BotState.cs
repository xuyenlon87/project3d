using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotState : MonoBehaviour
{
    public bool hasBomb;

    private void Awake()
    {
        hasBomb = false;
    }

}
