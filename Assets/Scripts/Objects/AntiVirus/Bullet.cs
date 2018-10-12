using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
public class Bullet : MonoBehaviour {

    int count = 0;
    public Component player;
    public Component Movement;
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Translate(-0.05f, 0, 0);
        count++;
        if(count == 120)
        {
            Destroy(gameObject);
        }
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Deadend();
        }
    }

    public void Deadend()
    {
        print("DIE");
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetStop(true);
        //player.GetComponent<PlayerMovement>().SetStop(true);
    }
}
