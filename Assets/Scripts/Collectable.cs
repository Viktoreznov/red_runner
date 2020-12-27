using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public GameObject vfx;
    public static int goldCollected;
    private void Awake()
    {
        goldCollected = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            goldCollected++;
            collision.GetComponent<Animator>().SetBool("Collected", true);
            Die.playerAudioSources[2].Play();
            StartCoroutine(destroyCoin(collision.gameObject,.7f));
        }
        if (collision.gameObject.CompareTag("Chest"))
        {
            goldCollected += 10;
            collision.GetComponent<Animator>().SetBool("Opened", true);
            Die.playerAudioSources[3].Play();
            Instantiate(vfx, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<BoxCollider2D>().enabled = false;

        }
        if (collision.gameObject.CompareTag("superChest"))
        {
            goldCollected += 25;
            collision.GetComponent<Animator>().SetBool("Opened", true);
            Die.playerAudioSources[3].Play();
            Instantiate(vfx, collision.transform.position, collision.transform.rotation);
            collision.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    IEnumerator destroyCoin(GameObject obj, float val)
    {
        yield return new WaitForSeconds(val);
        Destroy(obj);
    }
}
