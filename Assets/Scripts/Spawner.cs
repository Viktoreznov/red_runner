using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool dead = true;
    public GameObject shot;
    public GameObject shotSpawn;
    public float waitValue;

    private void Start()
    {
            StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        do
        {
            yield return new WaitForSeconds(waitValue);
            Instantiate(shot,shotSpawn.transform.position,shotSpawn.transform.rotation);
        } while (dead);
        
    }
}
