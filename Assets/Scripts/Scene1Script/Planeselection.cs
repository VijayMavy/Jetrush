using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planeselection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scriptablemaster._gamevariabales.whichplane = 0;
        if (StartMenuManager.startMenuManager == null)
        {
            StartMenuManager.startMenuManager = FindObjectOfType<StartMenuManager>();
        }
        foreach (Button b in StartMenuManager.startMenuManager.planeselectionbutton)
        {
            b.onClick.AddListener(delegate { Planeselectionmenu(b); });
        }
    }
    public void Planeselectionmenu(Button button)
    {
        if(StartMenuManager.startMenuManager==null)
        {
            StartMenuManager.startMenuManager = FindObjectOfType<StartMenuManager>();
        }
        Debug.Log(button.name);
       StartMenuManager.startMenuManager. buttonindex = StartMenuManager.startMenuManager.planeselectionbutton.FindIndex(x => x.name == button.name);
      //  StartMenuManager.startMenuManager.buttonindex += 1;
        Scriptablemaster._gamevariabales.whichplane = StartMenuManager.startMenuManager.buttonindex;
      StartMenuManager.startMenuManager.planemenu.  gameObject.SetActive(false);
        StartMenuManager.startMenuManager.startmenu.gameObject.SetActive(true);
    }
}
