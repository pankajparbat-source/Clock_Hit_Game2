using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animLevel : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUiShow()
    {
        animator.SetTrigger("rightToLeft");
    }
}
