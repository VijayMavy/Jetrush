using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updowndatavariables : MonoBehaviour
{
    public List<float> obstaclewaypoints = new List<float>();
    public int fromwaypointindex;
    public int towaypointindex;
    public float percentbetweenwaypointss;
    public float speed;
    float[] globalwaypoints;
    float newposition;
    private PhysicsEngine physicsEngine;
    public float speedvaries;
    

    private void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
        GlobalWaypoints();   
    }
    public void GlobalWaypoints()
    {
        obstaclewaypoints.Add(Random.Range(-18f, -18f));
        obstaclewaypoints.Add(Random.Range(4f, 7f));
        globalwaypoints = new float[obstaclewaypoints.Count];
        for (int i = 0; i < obstaclewaypoints.Count; i++)
        {
            globalwaypoints[i] = obstaclewaypoints[i] + transform.position.y;
        }
    }




    private void FixedUpdate()
    {
       
        physicsEngine.Addtorque(Vector3.up*10);
        physicsEngine.velocityvector.y = RotorUpdownmovemnt();
    }

    public float RotorUpdownmovemnt()
    {
       
            towaypointindex = fromwaypointindex + 1;
            float distancebetweenwaypoint = globalwaypoints[fromwaypointindex]- globalwaypoints[towaypointindex];
            percentbetweenwaypointss +=Mathf.Abs( speed *Time.deltaTime/ distancebetweenwaypoint);
       
        newposition =Mathf.Lerp(globalwaypoints[fromwaypointindex], globalwaypoints[towaypointindex],2* percentbetweenwaypointss);
            if (percentbetweenwaypointss >= 1)
            {
                percentbetweenwaypointss = 0;
                fromwaypointindex++;
                if (fromwaypointindex >= globalwaypoints.Length - 1)
                {
                    fromwaypointindex = 0;
                    System.Array.Reverse(globalwaypoints);
                }

            }

        return newposition - transform.position.y;
    }





}
