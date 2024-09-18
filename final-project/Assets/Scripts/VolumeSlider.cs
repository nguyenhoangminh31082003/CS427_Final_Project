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
        float savedVolume = PlayerPrefs.GetFloat("VolumeLevel", 1f);

        slider.value = savedVolume * 100;

        AudioListener.volume = savedVolume;

        sliderText.text = (savedVolume * 100) + "%";

        slider.onValueChanged.AddListener((newVolume) =>
        {
            // Convert slider value (0-100) to a percentage (0.0 - 1.0)
            float volume = newVolume / 100;
            AudioListener.volume = volume;

            // Update text
            sliderText.text = newVolume + "%";

            // Save the volume level so it's retained between scenes or sessions
            PlayerPrefs.SetFloat("VolumeLevel", volume);
            PlayerPrefs.Save();
        });
    }

    void Update()
    {
        
    }
}
