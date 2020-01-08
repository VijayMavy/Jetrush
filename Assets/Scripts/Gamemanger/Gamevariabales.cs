using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Gamevariable",menuName ="Game")]
public class Gamevariabales : ScriptableObject
{
    public static Gamevariabales gamevariabales;
    public bool isgamestarted;
    public int whichplane;
    public float rocketmaxpeed;
    public float increamentspeed;
    public bool isparticleeffect;
    public Vector3 velocity;
    public List<GameObject> fireparticles=new List<GameObject>();
    public bool ishittedwithcollider;
    public Vector3 startpos;
   
    





}
