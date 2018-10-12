using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
public class Shooting : MonoBehaviour {

    public GameObject Bullet;
    public Transform Boss;
    public int Counter;

	// Update is called once per frame
	void Update ()
    {
        Counter++;

        if(Counter == 120)
        {
            fired();
            Counter = 0;
        }
    }

    void fired()
    {
        Instantiate(Bullet, Boss.position, Boss.rotation);
    }
}
