using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomColider : MonoBehaviour
{
     public static bool isBomb;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            isBomb = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
