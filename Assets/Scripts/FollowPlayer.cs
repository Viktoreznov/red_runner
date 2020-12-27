using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    float smoothSpeed = .125f;
    private void Start()
    {
        //offset = transform.position - player.position;
    }
    private void FixedUpdate()
    {
        if (transform.position.y > 0.3f)
        {
            Vector3 desiredPos = player.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = smoothPosition;
        }
    }
}
