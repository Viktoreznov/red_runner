using UnityEngine.UI;
using UnityEngine;

public class countDown : MonoBehaviour
{
    public float timeLeft;
    public static float BonusGold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Die.dead)
            timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Die.dead = true;
        }
        GetComponent<Text>().text = timeLeft.ToString("0");
        BonusGold = timeLeft;
    }
}
