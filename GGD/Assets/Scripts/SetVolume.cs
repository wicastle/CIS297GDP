using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    private Slider VolumeSlider = null;
    // Start is called before the first frame update
    void Start()
    {
        VolumeSlider = this.GetComponent<Slider>();
        VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
