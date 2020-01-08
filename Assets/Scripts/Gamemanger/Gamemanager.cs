using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public Button Reloadbutton;
    public Button Quitbutton;
    public Button Restartbutton;
    public Button Backbutton;
    public GameObject explosiveparticle;
    public static Gamemanager gamemanager;
    public float score;
    public Text Scoretext;
    public int calculatedscore;
    public Text calculatedscoretext;
    public GameObject Finalpanelobject;
    public List<GameObject> planeselection = new List<GameObject>();
    public bool caninstantiate;
   public GameObject pr;
    public GameObject pl;


    private void Awake()
    {
        Planeinstantiate();
    }
    private void Start()
    {
        GameObject g = Instantiate(Scriptablemaster._gamevariabales.fireparticles[0]);
        explosiveparticle = g;
        explosiveparticle.SetActive(false);
        Reloadbutton.onClick.AddListener(OnclickReloadButton);
        Restartbutton.onClick.AddListener(OnclickRestartButton);
        Quitbutton.onClick.AddListener(OnclickQuitbutton);
        Backbutton.onClick.AddListener(OnclickBackButton);
            
    }

    public void Planeinstantiate()
    {
        
          GameObject g=  Instantiate(planeselection[Scriptablemaster._gamevariabales.whichplane], new Vector3(0, 3, 0), Quaternion.identity);
      
       
     

    }


    public void OnclickReloadButton()
    {

        SceneManager.LoadScene(1);
    }
    public void OnclickRestartButton()
    {

        SceneManager.LoadScene(1);
    }
    public void OnclickQuitbutton()
    {
        Application.Quit();
    }
    public void OnclickBackButton()
    {

        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        
       
            StartCoroutine("Particledelay");
        
    }
    IEnumerator Particledelay()
    {
        if(Rocket.rocket==null)
        {
            Rocket.rocket = FindObjectOfType<Rocket>();
        }
       
        if (Scriptablemaster._gamevariabales.isparticleeffect )
        {
            explosiveparticle.SetActive(true);
            explosiveparticle.transform.position =new Vector3( Rocket.rocket.gameObject.transform.position.x-.5f, Rocket.rocket.gameObject.transform.position.y, Rocket.rocket.gameObject.transform.position.z-4f);
           
            yield return new WaitForSeconds(1f);
           explosiveparticle.SetActive(false);
            Scriptablemaster._gamevariabales.isparticleeffect = false;
            Rocket.rocket.FinalpanelUpate();

        }
    }
}
