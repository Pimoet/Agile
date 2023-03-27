using UnityEngine;
using UnityEngine.UI;

public class SliderApplySound : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject audioSource;
    [SerializeField] bool SFX, Master, Music;

    public bool change;

    public AudioData data;
    void Awake()
    {
        if (SFX && !Master && !Music)
        {
            slider.value = data.SFXVolume;
        }
        else if (!SFX && Master && !Music)
        {
            slider.value = data.masterVolume;
        }
        else if (!SFX && !Master && Music)
        {
            slider.value = data.musicVolume;
        }
    }

    void Update()
    {
        if (change)
        {
            if (SFX && !Master && !Music)
            {
                data.SFXVolume = slider.value;
                EditSound();
            }
            else if (!SFX && Master && !Music)
            {
                data.masterVolume = slider.value;
            }
            else if (!SFX && !Master && Music)
            {
                data.musicVolume = slider.value;
                EditSound();
            }
        }
    }
    void EditSound()
    {
        audioSource.GetComponent<ApplySound>().EditVolume();
    }
}
