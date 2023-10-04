using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public Vector3 offset;
    private float speed = 2f;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            StartCoroutine(MoveCamera());
        }
    }

    private IEnumerator MoveCamera()
    {
        isMoving = true;
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        while(Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (!isMoving)
            {
                transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
            }
        }
    }
}
