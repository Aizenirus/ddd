using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField]private float _forceJump;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "platform(Clone)")
        {
            collision.transform.position = new Vector3 (transform.position.x, transform.position.y+1f, 0);
        }
        if (collision.relativeVelocity.y < 0)
            PlayerController.instance._rb.velocity = Vector2.up * _forceJump;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.name == "DeadZone")
        {
            float RandX = Random.Range(-2f, 2f);                
            float RandY = Random.Range(transform.position.y + 20f, transform.position.y + 22f);

            transform.position = new Vector3(RandX, RandY, -1);


        }
    }
}
