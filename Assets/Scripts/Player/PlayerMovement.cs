using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _body;

    public float speed;     // speed
    public float gravity;   // amount of gravity
    

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        _body.MovePosition( (_body.position + new Vector2(speed * Time.deltaTime, -gravity * Time.deltaTime)) );
        //_body.MovePosition((_body.position + new Vector2(speed * Time.deltaTime, 0)));
    }


    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float value)
    {
        speed = value;
    }

   
}
