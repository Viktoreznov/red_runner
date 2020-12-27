using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextLevel : MonoBehaviour
{
    public GameObject GamePlayUI, LevelCompleteUI,Player,Camera;
    public AudioSource lvlComplet;
    bool levelCompleted = false;
    float totalGold = 0.0f;
    float bonusCalculated;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource[] audio = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];


            foreach (AudioSource turnOff in audio)
                turnOff.Stop();

            GamePlayUI.SetActive(false);
            LevelCompleteUI.SetActive(true);

            if (PlayerPrefs.GetInt("togglesound") == 1)
                lvlComplet.Play();

            Camera.GetComponent<FollowPlayer>().enabled = false;
            Player.GetComponent<playerMouvement>().enabled = false;

            levelCompleted = true;

            bonusCalculated = countDown.BonusGold / 10;

            replaceValue.save(PlayerPrefs.GetInt("myGold") + Mathf.RoundToInt(Collectable.goldCollected + bonusCalculated));
        }

    }

    private void Update()
    {
        if (levelCompleted)
        {
            
            // print total gold in the Game Over UI
            if (totalGold < Collectable.goldCollected+bonusCalculated)
            {
                totalGold += Time.deltaTime * 10;
                LevelCompleteUI.transform.GetChild(3).gameObject.GetComponent<Text>().text = totalGold.ToString("0");
            }
            // print the bonus after total gold
            if (totalGold >= Collectable.goldCollected + bonusCalculated) {
                LevelCompleteUI.transform.GetChild(4).gameObject.GetComponent<Text>().text ="+"+bonusCalculated.ToString("0")+" Bonus";
                levelCompleted = false;
            }
        }
    }
}
