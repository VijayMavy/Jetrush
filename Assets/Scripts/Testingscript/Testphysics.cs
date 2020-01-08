using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testphysics : MonoBehaviour
{
    private PhysicsEngine physicsEngine;
    public GameObject player1distance;

    public float dis;
   void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
    }
   public void FixedUpdate()
    {
      dis=  Vector3.Distance(this.gameObject.transform.position, player1distance.transform.position);  
        if (Input.GetKey(KeyCode.RightArrow))
        {
            physicsEngine.Addtorque(transform.right*8);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            physicsEngine.Addtorque(-transform.right*8);
        }
    }
}
