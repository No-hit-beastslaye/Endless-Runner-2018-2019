using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class ObjectCollision : MonoBehaviour {

    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Anti-Virus")
        {
            Die();
        }
        else if (collision.gameObject.tag == "Floor")
        {
            if(!player.GetComponent<PlayerAbilities>().GetJumpActive() )
            {
                player.GetComponent<PlayerAbilities>().SetJumpActive(false);
                player.GetComponent<PlayerAbilities>().SetJumpDelay(false);
            }
            
        }
        else if (collision.gameObject.tag == "Ceiling")
        {
            player.GetComponent<PlayerAbilities>().SetJumpActive(false);
            player.GetComponent<PlayerAbilities>().SetJumpDelay(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player collides with the firewall, kill the player
        if(collision.gameObject.tag == "Firewall")
        {
            if (player.GetComponent<PlayerAbilities>().GetShiftActive())
            {
                print("through firewall");
            }
            else
            {
                Die();
            }
        }
    }

    // kill the player
    private void Die()
    {
        print("die");
        player.GetComponent<PlayerMovement>().SetStop(true);
        GetComponent<AudioSource>().Play();
    }

}
