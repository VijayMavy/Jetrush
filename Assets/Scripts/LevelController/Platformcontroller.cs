using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformcontroller : MonoBehaviour
{
   public static Platformcontroller platformcontroller;
    

    public GameObject[] ground;
    public GameObject[] obstacle;
    public GameObject[] leftbuilding;
    public GameObject[] rightbuilding;
    public Transform target;
    public float zoffset;
    public int index = 0;
    public int maxtile;
    public int maxleftbuilding;
    public int maxrightbuilding;
    public int leveldificulty;
    public List<GameObject> activetile=new List<GameObject>();
    public List<GameObject> activeleftbuilding = new List<GameObject>();
    public List<GameObject> activerightbuilding = new List<GameObject>();
    public List<GameObject> activechildren = new List<GameObject>();
    public int groundlength;
    public GameObject scaletarget;
    private GameObject g;
    public int childcount;
    public float lastzoffset;
    public float time;
    public bool isduplicate;
    public List<Vector3> dummypostion = new List<Vector3>();
   

    void Start()
    {
       
        for (int i = 0; i < ground.Length; i++)
        {
            g = Instantiate(ground[i], new Vector3(0, 0, zoffset), Quaternion.identity);
            activetile.Add(g);

            leveldificulty = 0;


            for (int j = 0; j <2; j++)
            {
             
                GameObject f = Instantiate(obstacle[j], new Vector3(-1000, 1, -1100), Quaternion.identity);
                f.transform.SetParent(g.transform);
                activechildren.Add(f);
            }

            
            maxtile = activetile.Count;
            

        }
        for (int k = 0; k < leftbuilding.Length; k++)
        {
            GameObject a = Instantiate(leftbuilding[k], new Vector3(-24, 0, zoffset), Quaternion.identity);
            activeleftbuilding.Add(a);

            
        }
        maxleftbuilding = activeleftbuilding.Count;




        for (int r = 0; r < rightbuilding.Length; r++)
        {
            GameObject b = Instantiate(rightbuilding[r], new Vector3(24, 0, zoffset), Quaternion.identity);
            activerightbuilding.Add(b);


        }
        maxrightbuilding = activerightbuilding.Count;
    }







    private void Update()
    {

        target.transform.position += Vector3.forward * 20f * Time.deltaTime;
        time += 2 * Time.deltaTime;
        Reccyleobject();
      
        
    }

    public void Reccyleobject()
    {
      
            if (target.transform.position.z >zoffset-(maxtile*groundlength))
            {
            lastzoffset = zoffset;
            activetile[index].transform.position = new Vector3(0f, 0f, zoffset);
            childcount = activetile[index].gameObject.transform.childCount;

            if (time > 5)
            {
                for (int i = 0; i < activetile[index].gameObject.transform.childCount ; i++)
                {
                   
                   if (i == 0)
                    {

                        activetile[index].gameObject.transform.GetChild(i).transform.position = new Vector3(Random.Range(-14, 16), -5f, zoffset);

                    }
                    if (i == 1 ||i==2)
                    {
                        activetile[index].gameObject.transform.GetChild(i).transform.position = new Vector3(Random.Range(-14, 16), 0f, zoffset);

                    }









                  

                        for (int x = 0; x < activetile[index].gameObject.transform.childCount - 1; x++)
                        {
                            float distancebetweenchild = activetile[index].gameObject.transform.GetChild(x).transform.position.x - activetile[index].gameObject.transform.GetChild(x + 1).transform.position.x;

                            if (distancebetweenchild <= 1.5f)
                            {
                                float Directionsign = Mathf.Sign(activetile[index].gameObject.transform.GetChild(x + 1).transform.position.x);
                                activetile[index].gameObject.transform.GetChild(x).transform.position = new Vector3((Directionsign == -1) ? activetile[index].gameObject.transform.GetChild(x + 1).transform.position.x + 6 : activetile[index].gameObject.transform.GetChild(x).transform.position.x - 6, (x == 0) ? -5f : 0f, zoffset);
                            }
                           
                          

                        


                    }



                }
                foreach (GameObject g in activechildren)
                {
                    switch (g.tag)
                    {

                        case "rotor":

                            g.transform.localScale = new Vector3(0.01f, 0.5f, 0.01f);
                            break;
                        case "updownrotor":

                            g.transform.localScale = new Vector3(0.01f, 0.5f, 0.01f);
                            g.GetComponent<Updowndatavariables>().speedvaries = Random.Range(0.05f, 2f);
                            break;

                    }
                }

            }
                for (int j = 0; j < activeleftbuilding.Count; j++)
                {
                    activeleftbuilding[index].gameObject.transform.transform.position = new Vector3(-22f, 1,zoffset);

                }
                for (int k = 0; k < activerightbuilding.Count; k++)
                {
                    activerightbuilding[index].gameObject.transform.transform.position = new Vector3(22f, 1, zoffset);

                }

            

            index++;
            if (index >= maxtile)
            {

                index = 0;

            }
            zoffset += 20;

        }
    }






















}






