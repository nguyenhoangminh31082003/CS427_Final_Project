using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    void Start()
    {
        slider.onValueChanged.AddListener((newVolume) => {
            sliderText.text = newVolume + "%";
        });
    }

    void Update()
    {
        
    }
}
