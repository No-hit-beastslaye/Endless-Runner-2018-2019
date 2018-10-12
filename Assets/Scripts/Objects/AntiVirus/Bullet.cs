using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
public class Bullet : MonoBehaviour {

    private int _count = 0;
    public Component player;
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Translate(-0.05f, 0, 0);
        _count++;
        if(_count == 180)
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
    }
}
