using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



  /**********************************************************************************/
 /**********/               /*.Made By Wassim Mefteh.*/                /************/
/**********************************************************************************/


[System.Serializable]
public class Objects
{
    public GameObject gamePlayUi, gameOverUi;
    public GameObject gold;
    public GameObject soundsButton;
    
}
public class gameManager : MonoBehaviour
{
    public GameObject cam;

    public GameObject Player;

    public Objects requiredObjects;

    public Sprite soundOff;
    public Sprite soundOn;

    AudioSource[] playlist,gameAudio,sfx;

    int played = 0;
    public static float totalGold;
    bool soundPlaying = true;
    bool done = true;

    float vol;
    private void Awake()
    {
        

        vol = PlayerPrefs.GetFloat("Volume");

        sfx = Player.GetComponents<AudioSource>();

        gameAudio = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        
        //Collectable.goldCollected = 0;
    }

    /*public void test()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     }*/


    void Start()
    {
        Die.dead = false;
        totalGold = 0;
        // adding all audiosources into an array
        playlist = GetComponents<AudioSource>();

        //mute music
        if (PlayerPrefs.GetInt("togglesound") == 0)
        {
            foreach (AudioSource audio in playlist)
                audio.mute = true;
        }
        else
        {
            foreach (AudioSource audio in playlist)
                audio.mute = false;
        }

        //mute sfx
        if (PlayerPrefs.GetInt("togglesfx") == 0)
        {
            foreach (AudioSource audio in sfx)
                audio.mute = true;
        }
        else
        {
            foreach (AudioSource audio in sfx)
                audio.mute = false;
        }

        //reduce volume
        foreach (AudioSource audioVolume in gameAudio)
            audioVolume.volume = vol;
    }


    //method to turnoff all sounds in the game by clicking the music icon
    public void stopSounds()
    {
        AudioSource[] turnOnOff = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        if (soundPlaying)
        {
            soundPlaying = !soundPlaying;
            foreach (AudioSource audio in turnOnOff)
                audio.mute = true;
            requiredObjects.soundsButton.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            soundPlaying = !soundPlaying;
            foreach (AudioSource audio in turnOnOff)
                audio.mute = false;
            requiredObjects.soundsButton.GetComponent<Image>().sprite = soundOn;
        }
    }

    // writing the Number of Gold Collected while playing
    void goldCollect()
    {
        requiredObjects.gold.GetComponent<Text>().text = Collectable.goldCollected.ToString();
        
    }

    // Retry
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Die.dead = false;
        Collectable.goldCollected = 0;
    }

    

    void Update()
    {
        //if the player died , we hide the HUD and display the
        //Game Over UI and addinc Bonus to the player too
        if (Die.dead)
        {
            //switching UI
            StartCoroutine(switchUI());
            //stop the camer from following the player and stop all sounds
            cam.GetComponent<FollowPlayer>().enabled = false;
            playlist[0].Stop();

            //start the death SFX & music and making sure to play them once
            if (played == 0)
            {
                playlist[1].Play();
                playlist[2].Play();
                played++;
            }

            //calculating bonus
            //float bonusCalculated = countDown.BonusGold/10;

            // print total gold in the Game Over UI
            if (totalGold < Collectable.goldCollected) {
                totalGold += Time.deltaTime * 10;
                requiredObjects.gameOverUi.transform.GetChild(3).gameObject.GetComponent<Text>().text = totalGold.ToString("0");
        }
            // print the bonus after total gold
            if (done) {
                replaceValue.save(PlayerPrefs.GetInt("myGold") + Collectable.goldCollected);
                done = false;
               // print("done");
            }
        }
        // gold collected while in game (without bonus)
        goldCollect();


    }

    //button to go to the main menu
    public void mainenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }

    //switching between the HUD and the gameUI after player death with .5f seconds
    IEnumerator switchUI()
    {
        yield return new WaitForSeconds(.5f);
       
            requiredObjects.gamePlayUi.SetActive(false);
            requiredObjects.gameOverUi.SetActive(true);
        
    }

    public void nextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
