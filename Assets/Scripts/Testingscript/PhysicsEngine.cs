using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
   
   public Vector3 velocityvector;
   
   private Vector3 netforcevector;
    public int mass;
   private List<Vector3> forcevectorlist = new List<Vector3>();
    private List<Vector3> torquelist = new List<Vector3>();
    Vector3 acceleration;
   




  //torque
    private Vector3 torques;
    //public Vector3 tor;
    private float torquemagnitude;
    private float calculatedangle;
    private Vector3 nettorquevector;
    private float angle;
    Vector3 Direction;



    //Drag
    public bool drag;
    [Range(0,2)]
    public float velocityexponent;
    public float dragconstant;










   


    public void FixedUpdate()
    {
        Dragforce();
       Updateposition();
        Updatetorque();
    }

    public void Addforce(Vector3 force)
    {
        forcevectorlist.Add(force);
    }
    public void Addtorque(Vector3 velocity)
    {
      

        torquelist.Add(velocity);

    }

    void Updateposition()
    {
        netforcevector = Vector3.zero;
        foreach (Vector3 forcevector in forcevectorlist)
        {
            netforcevector += forcevector;
        }
        forcevectorlist = new List<Vector3>();
        acceleration = netforcevector / mass;          //force=mass*accelertion//acceleration=force/mass
        velocityvector += acceleration *Time.deltaTime;
      
        transform.position += velocityvector * Time.deltaTime;

    }
    public void Updatetorque()
    {
        nettorquevector = Vector3.zero;
        // torques = Vector3.zero;
        //calculatedangle = 0;
        foreach (Vector3 torque in torquelist)
        {
            nettorquevector += torque;
        }
        torquelist = new List<Vector3>();

        angle = Vector3.Angle(transform.position, nettorquevector);
        Vector3 Direction = nettorquevector;
        Direction = Direction.normalized;
        calculatedangle = Mathf.Sin(angle);
        torques = Vector3.ClampMagnitude(torques, 10);
        torques += (nettorquevector * calculatedangle) + Direction;
        torquemagnitude = torques.magnitude;
        transform.Rotate(torques*Time.deltaTime*torquemagnitude);

    }
    void Dragforce()
    {
        if (drag)
        {
            Vector3 velocityVector = velocityvector;
            float speed = velocityVector.magnitude;
           
            float dragvalue = Calculatedrag(speed);
          //  print(dragvalue + "drag");
            Vector3 dragcvector = dragvalue * -velocityVector.normalized;
          //  print(dragcvector + "vec");
            Addforce(dragcvector);


        }
    }


    float Calculatedrag(float velocity)
    {
        return dragconstant * Mathf.Pow(velocity, velocityexponent);
    }


  










}
