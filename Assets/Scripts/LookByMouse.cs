using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookByMouse : MonoBehaviour
{
    [SerializeField]
    private float anglePerSecond;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float yaw = mouseX * anglePerSecond * Time.deltaTime;
        transform.Rotate(0, yaw, 0);
    }
}
