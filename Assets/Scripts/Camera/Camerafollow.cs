using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Camerafollow : MonoBehaviour
{
    public Transform target;
    public float smoothtime=1f;
    public Vector3 offset;

    private void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    void LateUpdate()
    {
       
            Vector3 desiredpos = offset + target.position;
            Vector3 smoothpos = Vector3.Lerp(transform.position, desiredpos, smoothtime);
            transform.position = smoothpos;
            transform.LookAt(target);
        
        
      
    }
}
