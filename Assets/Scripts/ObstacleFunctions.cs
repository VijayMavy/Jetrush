
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFunctions : MonoBehaviour
{
    private PhysicsEngine physicsEngine;

   
      void Start()
      {
         if(Platformcontroller.platformcontroller==null)
          {
              Platformcontroller.platformcontroller = FindObjectOfType<Platformcontroller>();
          }
          physicsEngine = GetComponent<PhysicsEngine>();
      
      }
 

  
   void FixedUpdate()
      {

          foreach (GameObject g in Platformcontroller.platformcontroller.activechildren)
          {
              switch(g.tag)
              {
                  case "rotor":
                   g.GetComponent<PhysicsEngine>().Addtorque(Vector3.up);
                      break;

              

            }

          }

      }
   
       

    }







