using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private Transform player;
    private Camera mainCamera;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = new Vector2(player.position.x + 5.5f, 0);
    }
}
