using UnityEngine.UI;
using UnityEngine;

public class replaceValue : MonoBehaviour
{
    public Text PlayerGold;
    int myGold = 0;

    private void Awake()
    {
        
         if (PlayerPrefs.HasKey("myGold"))
          {
              myGold = PlayerPrefs.GetInt("myGold");
          }
          else
          {
              save(myGold);
          }


      }

      public static void save(int myGold)
      {
          PlayerPrefs.SetInt("myGold", myGold);
      }

      private void Update()
      {
        PlayerGold.text = myGold.ToString();
      }
    }