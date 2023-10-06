using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform targetPlayerShop;
    public GameObject target;
    public Vector3 offset;
    public Vector3 offsetPlayerShop;
    private float speed = 1f;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
    }

    public void QuickPlay()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            StartCoroutine(MoveCamera());
        }
    }

    public void TargetPlayerShop()
    {
        transform.position = new Vector3(targetPlayerShop.position.x + offsetPlayerShop.x, targetPlayerShop.position.y + offsetPlayerShop.y, targetPlayerShop.position.z + offsetPlayerShop.z);
    }
    public void DelayQuickPlay()
    {
        Invoke("QuickPlay", 3f);
    }
    private IEnumerator MoveCamera()
    {
        isMoving = true;
        Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y  , target.transform.position.z  );
        while(Vector3.Distance(transform.position, target.transform.position) > 16f)
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
                transform.position = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, target.transform.position.z + offset.z);
            }

        }
    }
}
