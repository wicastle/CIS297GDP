using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource AudioSource;
    public Slider VolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = VolumeSlider.value;
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
    }

}
