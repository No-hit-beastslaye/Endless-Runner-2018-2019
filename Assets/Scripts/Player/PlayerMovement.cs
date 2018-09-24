using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class PlayerMovement : MonoBehaviour {

    public float _speed;
    private Rigidbody2D _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        _body.MovePosition( (_body.position + new Vector2(_speed * Time.deltaTime, 0)) );
	}
}
