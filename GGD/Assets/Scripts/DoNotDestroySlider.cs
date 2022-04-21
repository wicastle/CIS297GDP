using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoNotDestroySlider : MonoBehaviour
{
    public static DoNotDestroySlider instance = null;
    public Slider VolumeSlider;

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

    public void Update()
    {
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);

    }
}
