using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManeger Instance;
    [SerializeField] private Canvas homeScrean;
  
   
   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        homeScrean.enabled = false;
       
       
    }
    void Start()
    {
        homeScrean.enabled = true;
    }

   
    void Update()
    {
        
    }
    public void levelScreanCanvase()
    {
        homeScrean.enabled = false;
        soundMangeger.Instance.playSound(soundName.click);
        int scenlevel = SceneManager.GetActiveScene().buildIndex;
        scenlevel++;
        SceneManager.LoadScene(scenlevel);

    }
   
   
   
  
   
}
