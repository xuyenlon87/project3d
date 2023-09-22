using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        if(target)
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 newPos = target.position + offset;
            transform.position = newPos;
        }
    }
}
