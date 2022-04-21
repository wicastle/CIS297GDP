using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
    public static MusicPlayerScript instance = null;
    public AudioSource AudioSource;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = PlayerPrefs.GetFloat("Volume");
    }

}
