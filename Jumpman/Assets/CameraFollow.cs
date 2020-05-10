using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float smoothSpeed = .3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*if(target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(0, target.position.y, transform.position.z);
            transform.position = newPos;
        }
        else if(target2.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(0, target2.position.y, transform.position.z);
            transform.position = newPos;
        }*/
        if (target.position.y > target2.position.y)
        {
            Vector3 newPos = new Vector3(0, target.position.y-5, transform.position.z);
            transform.position = newPos;
        }
        else if (target2.position.y > target.position.y)
        {
            Vector3 newPos = new Vector3(0, target2.position.y - 5, transform.position.z);
            transform.position = newPos;
        }
    }
}
