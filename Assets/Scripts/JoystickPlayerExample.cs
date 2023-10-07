using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;
    [SerializeField]
    private float magnitude;
    [SerializeField]
    private float rotationSpeed;

    public void FixedUpdate()
    {
        floatingJoystick = GameObject.FindGameObjectWithTag("JoyStick").GetComponent<FloatingJoystick>();
        float horizontalInput = floatingJoystick.Horizontal;
        float verticalInput = floatingJoystick.Vertical;

        Vector3 inputDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (inputDirection.magnitude >= magnitude)
        {
            // Xác định hướng nhìn dựa trên hướng di chuyển
            Quaternion lookRotation = Quaternion.LookRotation(inputDirection, Vector3.up);

            // Sử dụng Slerp để mượt mà chuyển từ hướng hiện tại sang hướng mới
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // Di chuyển người nhân vật
            Vector3 moveDirection = transform.forward * speed;
            rb.velocity = moveDirection;
        }
        else
        {
            // Nếu không có đầu vào từ joystick, dừng người nhân vật
            rb.velocity = Vector3.zero;
        }
    }
}