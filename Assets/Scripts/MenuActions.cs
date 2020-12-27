using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuActions : MonoBehaviour
{
    bool sfx = true , sound = true;
    public Sprite offIcon, soundIcon, sfxIcon;
    public GameObject btnSound, btnSFX,volumeSlider;
    public AudioSource MainMenuMusic;

    private void Awake()
    {
        
    }
    public void toggleSound() {
        if (sound) {
            sound = !sound;
            btnSound.GetComponent<Image>().sprite = offIcon;
            MainMenuMusic.Stop();
            PlayerPrefs.SetInt("togglesound", 0);
        }
        else {
            sound = !sound;
            btnSound.GetComponent<Image>().sprite = soundIcon;
            MainMenuMusic.Play();
            PlayerPrefs.SetInt("togglesound", 1);
        }
    }
    public void toggleSFX() {
        if (sfx) {
            sfx = !sfx;
            btnSFX.GetComponent<Image>().sprite = offIcon;
            PlayerPrefs.SetInt("togglesfx", 0);
        } else {
            sfx = !sfx;
            btnSFX.GetComponent<Image>().sprite = sfxIcon;
            PlayerPrefs.SetInt("togglesfx", 1);
        }
    }
    public void VolumeValue() {
        float value = volumeSlider
.GetComponent<Slider>().value;
        AudioSource[] audio = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        foreach (AudioSource audioVolume in audio)
            audioVolume.volume = value;

        PlayerPrefs.SetFloat("Volume",value);
        
    }

    public void about()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }

    public void settings()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);

    }

    public void levels()
    {
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }

    private void Start()
    {
        volumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
        if(PlayerPrefs.GetInt("togglesound") == 0)
        {
            btnSound.GetComponent<Image>().sprite = offIcon;
            MainMenuMusic.Stop();
        }
        else
        {
            btnSound.GetComponent<Image>().sprite = soundIcon;
            MainMenuMusic.Play();
        }

        if (PlayerPrefs.GetInt("togglesfx") == 0)
        {
            btnSFX.GetComponent<Image>().sprite = offIcon;
        }
        else
        {
            btnSFX.GetComponent<Image>().sprite = sfxIcon;
        }
    }
}
