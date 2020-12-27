using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public GameObject vfx;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ending"))
        {
            Destroy(gameObject);
            Instantiate(vfx,transform.position-new Vector3(0,1.75f,0),vfx.transform.rotation);
        }else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(vfx, collision.GetContact(0).point - new Vector2(0, .75f) /* transform.position-new Vector3(0,1.75f,0)*/, vfx.transform.rotation);
        }
    }
}
