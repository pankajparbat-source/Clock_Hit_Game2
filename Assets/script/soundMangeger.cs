using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class soundMangeger : MonoBehaviour
{

    // [SerializeField] private Slider slider;
    public static soundMangeger Instance;
    [SerializeField] private AudioSource audioSource;
    public sound[] clip;
   
   
   
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // slider.value = audioSource.volume;
       
    }
    public void playSound(soundName name)
    {
        foreach (var item in clip)
        {
            if (item.name == name)
            {
                audioSource.PlayOneShot(item.num);
                break;
            }

        }
    }
    public void soundMute(bool val)
    {
        audioSource.mute = val;
    }
    public void muteUnmute()
    {
        audioSource.mute = !audioSource.mute;
    }
  
}
[System.Serializable]
public class sound
{
    public soundName name;
    public AudioClip num;
}
public enum soundName
{
    click,
   congratulation,
   levelCompleted,
   move,
   missedClock
}







