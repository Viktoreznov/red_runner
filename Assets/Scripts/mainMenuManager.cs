using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{

    private void Awake()
    {
        if(!(PlayerPrefs.HasKey("togglesfx") && PlayerPrefs.HasKey("togglesound") && PlayerPrefs.HasKey("Volume")))
        {
            save(1,1,1.0f);
        }

        
    }

    public void save(int sfx, int sound, float volume)
    {
        PlayerPrefs.SetInt("togglesfx", sfx);
        PlayerPrefs.SetInt("togglesound", sound);
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void continueLastLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       }

   
}
