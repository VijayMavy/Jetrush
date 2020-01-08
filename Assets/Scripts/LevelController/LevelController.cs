using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
   public static LevelController levelController;
    
    public LevelPiece[] levelPieces;
    public int drawdistance;
    public float piecelength;
    public Transform player;
    public Vector3 offset;

    public Transform cameratransform;
    public float speed;
    public int currentcamstep;
    public int lastcamstep;
    public Queue<GameObject> activepieces = new Queue<GameObject>();
    public List<int> probabilitylist = new List<int>();
    void Start()
    {
        Probability();
        for (int i = 0; i < drawdistance; i++)
        {
            GameObject newlevellpiece = Instantiate(levelPieces[0].prefab, new Vector3(0f, 0f, (-20 + activepieces.Count) * piecelength), Quaternion.identity);
            activepieces.Enqueue(newlevellpiece);
           
        }
        
    }
   void Update()
    {
        Cameradetail();
    }


    void Spawnnewpiece()
    {

        int whichpiece =probabilitylist[Random.Range(0,probabilitylist.Count)];
            GameObject newlevellpiece = Instantiate(levelPieces[whichpiece].prefab, new Vector3(Random.Range(-8f,8f), 5f,(currentcamstep+activepieces.Count)* piecelength), Quaternion.identity);


        activepieces.Enqueue(newlevellpiece);
        
    }


    void Cameradetail()
    {


        cameratransform.transform.position = GameObject.Find("rocket").transform.position+offset;
         //cameratransform.transform.position = Vector3.MoveTowards(cameratransform.transform.position, cameratransform.transform.position + Vector3.forward ,Time.deltaTime * speed);
         currentcamstep = (int)(cameratransform.transform.position.z / piecelength);
        if(currentcamstep!=lastcamstep)
        {
            lastcamstep = currentcamstep;
            Despawn();
            Spawnnewpiece();
        }
    }

    public void Despawn()
    {
     GameObject oldobject=   activepieces.Dequeue();
        Destroy(oldobject);

    }




    public void Probability()
    {
        int index = 0;
        foreach (LevelPiece level in levelPieces)
        {
            for (int i = 0; i < level.probability; i++)
            {
                probabilitylist.Add(index);
            }
            index++;
        }
    }







}

[System.Serializable]
public class LevelPiece
{
    public string name;
    public GameObject prefab;
    public int probability;
}
