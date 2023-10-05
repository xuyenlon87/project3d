using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
        transform.LookAt(target);
    }
}
