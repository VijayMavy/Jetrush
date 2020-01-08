using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Raycastcontroller3d : MonoBehaviour
{
  //  public Raycastorigin raycastorigin;
    private BoxCollider colllider;
    const float skinwidth = 0.015f;



    public int Horizontalraycount;
    public int Verticalraycount;
    public int Frontraycount;

    public float Horizontalrayspacing;
    public float Verticalrayspacing;
    public float Frontrayspacing;
    private PhysicsEngine physicsEngine;
    private Rocket rocket;

    public LayerMask Collisionmask;
    public Bounds colliderbounds;
   
    private void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
        colllider = GetComponent<BoxCollider>();
        rocket = GetComponent<Rocket>();
    
    }

 
 private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer ==11)
        {
            Scriptablemaster._gamevariabales.ishittedwithcollider = true;
        }
    }

  



  
}
