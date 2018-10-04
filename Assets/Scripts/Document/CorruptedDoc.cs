using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedDoc : MonoBehaviour
{
    public Component player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Deadend();
        }
    }

    public void Deadend()
    {
        print("DIE");
        player.GetComponent<PlayerMovement>().SetStop(true);
    }
}
