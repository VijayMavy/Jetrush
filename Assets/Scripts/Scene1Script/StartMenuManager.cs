using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public static StartMenuManager startMenuManager;
    public Button startbutton;
    public Button exitbutton;
    public Button planeselectbutton;
    public GameObject planemenu;
    public GameObject startmenu;
    public List<Button> planeselectionbutton = new List<Button>();
    public int buttonindex;
    private void Start()
    {
       
        startbutton.onClick.AddListener(OnClickstartbutton);
        planeselectbutton.onClick.AddListener(OnclickPlaneselectbutton);
       
   }


    public void OnClickstartbutton()
    {
       // startbutton.transform.parent.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
        
        
    }

    public void OnclickPlaneselectbutton()
    {
      //  planeselectbutton.transform.parent.gameObject.SetActive(false);
        planemenu.SetActive(true);
       
    }

   

}
