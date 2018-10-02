using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
public class DocumentPickUp : MonoBehaviour
{
    Animator Move;

    private void Start()
    {
        Move = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        print(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            //Boolean voor de wipe animation
            Move.SetBool("Wipe", true);
        }
    }
}