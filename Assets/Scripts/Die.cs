using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public static AudioSource[] playerAudioSources;
    public static bool dead = false;
    public GameObject blood, splash;
    private void Start()
    {
        playerAudioSources = GetComponents<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            hide();
            dead = true;
            Instantiate(blood, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            hide();
            playerAudioSources[1].Play();
            dead = true;
            Instantiate(splash, transform.position, transform.rotation);
        }
    }

    void hide()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(killPlayer());
    }

    IEnumerator killPlayer()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
