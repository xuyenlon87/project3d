using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public Vector3 direction = Vector3.one;
    void Update()
    {
        var targetPosition = new Vector3(target.position.x*direction.x, target.position.y*direction.y, target.position.z*direction.z);
        
        transform.LookAt(-targetPosition);
    }
}
