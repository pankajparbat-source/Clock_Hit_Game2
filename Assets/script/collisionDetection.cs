using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionDetection : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public static  collisionDetection Instance;
    Vector2 upperLimit;
    Vector2 lowerLimit;
    [SerializeField] private Sprite activeImage;
    [SerializeField] private Sprite activeFaceImage;
    [SerializeField] private Sprite activeHand;
    public bool itsCollision=false;
    GameObject clockHand;
    GameObject clock;
    GameObject[] active;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("clock"))
        {
          active = GameObject.FindGameObjectsWithTag("active");
            if(active.Length>0)
            {
                //Debug.Log("this is destroy method");

                Destroy(active[0]);

                gamePlayer.Instance.removeFromList(active[0]);
               // gamePlayer.Instance.removeFromList();


            }
           
            clock =collision.gameObject;
            if (clock != null)
            {
                int id = collision.contactCount;
                for(int index=1;index<=id;index++)
                {
                    if(index==1)
                    {
                       
                        clock.GetComponent<SpriteRenderer>().sprite = activeImage;
                        clock.tag = "active";
                        GameObject childGameObject = clock.transform.GetChild(0).gameObject;
                        clockHand = childGameObject.transform.GetChild(0).gameObject;
                        clockHand.GetComponent<SpriteRenderer>().sprite = activeHand;
                        Vector3 tra = clockHand.GetComponent<Transform>().position;
                        tra = Vector3.zero;                       
                        clockHand.GetComponent<Transform>().localScale = new Vector3(0.290804f, 0.3100241f, 1f);
                       //this localScale is chengesd for showwing the proper clock size 
                        Destroy(gameObject);
                    }
                }
               
               

            }
        }      
     
    }
    private void Update()
    {
        upperLimit = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        lowerLimit = Camera.main.ScreenToWorldPoint(Vector2.zero);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, lowerLimit.x, upperLimit.x), Mathf.Clamp(transform.position.y, lowerLimit.y, upperLimit.y));
        if (transform.position.y == upperLimit.y || transform.position.y == lowerLimit.y || transform.position.x == upperLimit.x || transform.position.x == lowerLimit.x)
        {
            reloadscene();
        }
    }
    public void reloadscene()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }
   


}
