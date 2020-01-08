using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Scriptable",menuName ="Gamedata")]
public class Scriptablemaster : Singletonscriptableobject<Scriptablemaster>
{
    [SerializeField]
    private  Gamevariabales gamevariabales;

    public static Gamevariabales _gamevariabales
    {
        get
        {
            return _instance.gamevariabales;
        }
    }
}
