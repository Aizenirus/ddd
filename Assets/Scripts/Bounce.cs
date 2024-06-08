using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    [SerializeField] private float forceJump = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerController2>();

        if (player != null && collision.relativeVelocity.y < 0)
        {
            player.BounceJump();
        }
    }


}
