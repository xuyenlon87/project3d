using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUpnDown : MonoBehaviour
{
    public GameObject wallUpnDown;
    private float heightWall;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isDown = false;
    [SerializeField]
    private bool isUp = false;
    // Start is called before the first frame update
    void Awake()
    {
        heightWall = wallUpnDown.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        WallDown();
        if (isUp)
        {
            Invoke("WallUp", 2f);
        }
    }

    private void WallDown()
    {
        if (isDown)
        {
            wallUpnDown.transform.position += Vector3.down * Time.deltaTime * speed;
            if (wallUpnDown.transform.position.y <= 0.009 )
            {
                isDown = false;
            }
        }
    }

    private void WallUp()
    {
        if (isUp)
        {
            wallUpnDown.transform.position += Vector3.up * Time.deltaTime * speed;
            if (wallUpnDown.transform.position.y - heightWall >= 0)
            {
                isUp = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDown = true;
            isUp = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isUp = true;
            isDown = false;
        }
    }
}
