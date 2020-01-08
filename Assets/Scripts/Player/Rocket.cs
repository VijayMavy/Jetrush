using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
   
    private PhysicsEngine physicsEngine;
   
   
    public static Rocket rocket;
    public List<GameObject> smokeparticles = new List<GameObject>();
   
   
    
    
    void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
      Scriptablemaster._gamevariabales.  startpos = transform.position;
        Scriptablemaster._gamevariabales.ishittedwithcollider = false;
        Scriptablemaster._gamevariabales.isparticleeffect = false;
      
       

    }
public void Scoreupdate()
    {
       
        if (Gamemanager.gamemanager == null)
        {
            Gamemanager.gamemanager = FindObjectOfType<Gamemanager>();
        }
        Gamemanager.gamemanager.score += (float)Time.deltaTime;
        Gamemanager.gamemanager.Scoretext.text = Gamemanager.gamemanager.score.ToString("0");

        Gamemanager.gamemanager.calculatedscore = (int)Gamemanager.gamemanager.score;
    }

    public void FinalpanelUpate()
    {
        Gamemanager.gamemanager.Finalpanelobject.gameObject.SetActive(true);
        Gamemanager.gamemanager.Scoretext.rectTransform.parent.gameObject.SetActive(false);
        Gamemanager.gamemanager.calculatedscoretext.text = Gamemanager.gamemanager.calculatedscore.ToString("0");
    }
   
    public void  Movement()
    {
        
            if (Gamemanager.gamemanager == null)
            {
                Gamemanager.gamemanager = FindObjectOfType<Gamemanager>();
            }

            physicsEngine.Addforce(Vector3.forward *Scriptablemaster._gamevariabales.increamentspeed * Time.deltaTime);

            if (physicsEngine.velocityvector.magnitude >= Scriptablemaster._gamevariabales.rocketmaxpeed)
            {
                physicsEngine.velocityvector.z = Scriptablemaster._gamevariabales.rocketmaxpeed;
            }
            if (Gamemanager.gamemanager.score >= 50)
            {
            Scriptablemaster._gamevariabales.rocketmaxpeed = 80;
            }
            if (Input.GetMouseButton(0))
            {

                if (Input.GetKey(KeyCode.LeftArrow) || (Input.mousePosition.x < Screen.width * 0.5f))
                {



                   

                    transform.position += Vector3.left * 4f * Time.deltaTime;
                    Vector3 originalpos = new Vector3(transform.position.x, Scriptablemaster._gamevariabales.startpos.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, originalpos, Time.deltaTime);

            

                Vector3 euler = new Vector3(0f, 0f, 35f);
                    Quaternion t = Quaternion.Euler(euler);
                    transform.rotation = Quaternion.Lerp(transform.rotation, t, 2 * Time.deltaTime);

                }
                else if (Input.GetKey(KeyCode.RightArrow) || (Input.mousePosition.x > Screen.width * 0.5f))
                {


                    transform.position += Vector3.right * 4f * Time.deltaTime;
                    // physicsEngine.velocityvector += Vector3.right * 8f * Time.deltaTime;

                    Vector3 originalpos = new Vector3(transform.position.x, Scriptablemaster._gamevariabales.startpos.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, originalpos, Time.deltaTime);

                    Vector3 euler = new Vector3(0f, 0f, -35f);
                    Quaternion t = Quaternion.Euler(euler);
                    transform.rotation = Quaternion.Lerp(transform.rotation, t, 2 * Time.deltaTime);

               
            }

            }
            else
        {
         
            Quaternion euler = Quaternion.Euler(new Vector3(0f, 0f, 0f));
                transform.rotation = Quaternion.Lerp(transform.rotation, euler, 4 * Time.deltaTime);
                Vector3 originalpos = new Vector3(transform.position.x, Scriptablemaster._gamevariabales.startpos.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, originalpos, 4 * Time.deltaTime);

            }

      

    }
    public void FixedUpdate()
    {
       
            Movement();
            Scoreupdate();
            Gameover();
        
      
        
    }

  
    public void Gameover()
    {
        if(Scriptablemaster._gamevariabales.ishittedwithcollider)
        {
            physicsEngine.velocityvector.z = 0;
            this.gameObject.SetActive(false);
            Scriptablemaster._gamevariabales.isparticleeffect = true;
        
        }
    }
   

    public void Rightmove()
    {


     
        physicsEngine.velocityvector += Vector3.right * 8f * Time.deltaTime;
        if (physicsEngine.velocityvector.x >= 10)
        {
            physicsEngine.velocityvector.z = 10;
        }
        Vector3 originalpos = new Vector3(transform.position.x, Scriptablemaster._gamevariabales.startpos.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, originalpos, Time.deltaTime);

        Vector3 euler = new Vector3(0f, 0f, -35f);
        Quaternion t = Quaternion.Euler(euler);
        transform.rotation = Quaternion.Lerp(transform.rotation, t, 4 * Time.deltaTime);
       

    }
    public void Leftmove()
    {



      
        physicsEngine.velocityvector += Vector3.left * 8f * Time.deltaTime;
        if (physicsEngine.velocityvector.x >= 10)
        {
            physicsEngine.velocityvector.z = 10;
        }
        Vector3 originalpos = new Vector3(transform.position.x, Scriptablemaster._gamevariabales.startpos.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, originalpos, Time.deltaTime);

        Vector3 euler = new Vector3(0f, 0f, 35f);
        Quaternion t = Quaternion.Euler(euler);
        transform.rotation = Quaternion.Lerp(transform.rotation, t, 4 * Time.deltaTime);

    }

   
}





































