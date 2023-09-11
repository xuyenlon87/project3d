using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotState : MonoBehaviour
{
    public bool hasBomb;
    public bool alive;

    private void Awake()
    {
        hasBomb = false;
        alive = true;
    }

}
