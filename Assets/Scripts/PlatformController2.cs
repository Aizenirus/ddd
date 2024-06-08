using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController2>();

        if (player && collision.relativeVelocity.y < 0)
        {
            player.Jump();
        }
    }


}

