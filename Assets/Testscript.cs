using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testscript : MonoBehaviour
{
    public float distancebetweenchild;
    public List<GameObject> children = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            children.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
      
    }

    private void Update()
    {
        for (int i = 0; i < this.gameObject.transform.childCount-1; i++)
        {
            distancebetweenchild = children[i].transform.position.x- children[i + 1].transform.position.x;
           
        }
        
    }
}
