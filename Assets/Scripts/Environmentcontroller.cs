using System.Collections.Generic;
using UnityEngine;

public class Environmentcontroller : MonoBehaviour
{
   

    void Start()
    {
      
       
    }

    private void LateUpdate()
    {
        Skychanging();
    }

    void Skychanging()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, 0.02f);
    }
}