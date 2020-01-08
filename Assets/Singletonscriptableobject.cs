using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singletonscriptableobject<T>:ScriptableObject where T :ScriptableObject
{
  private static T instance;


    public static T _instance
    {
        get
        {
            if(instance==null)
            {
                T[] result = Resources.FindObjectsOfTypeAll<T>();
                if(result==null)
                {
                    Debug.LogError("not found");
                    return null;
                }
                if(result.Length>1)
                {
                    Debug.Log("found");
                    return null;
                }
                instance = result[0];
            }
            return instance;
        }
    }
}
