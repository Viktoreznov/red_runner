using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backoff : MonoBehaviour
{
    public GameObject baseMenu;
    void click()
    {
        transform.parent.gameObject.SetActive(false);
        baseMenu.SetActive(true);
    }

    private void Update()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => click());
        
    }
}
