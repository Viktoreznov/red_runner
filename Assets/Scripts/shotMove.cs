using System.Collections; 
using UnityEngine;

public class shotMove : MonoBehaviour
{
    public float speed;
    public GameObject vfx;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(vfx, transform.position, transform.rotation);
    }

}
