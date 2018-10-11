using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _body;

    public float speed;     // speed
    public float gravity;   // graivty
    private float _jumpVel; // jump veloticy
    bool _stop = false;     // stop player movement

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update ()
    {
        if(!_stop)
        {
            CalculateMovement();
        }
    }

    // calculate player forces
    private void CalculateMovement()
    {
        Vector2 position = _body.position;
        Vector2 calcPos = new Vector2(speed * Time.deltaTime, (-_jumpVel + -gravity) * Time.deltaTime);

        _body.MovePosition( (position + calcPos) );
        _jumpVel = 0;
    }


    public void SetGravityFactor(string type, float value)
    {
        if(type == "*") gravity *= value;
        else if(type == "/") gravity /= value;
    }
    public void SetStop(bool value)
    {
        _stop = value;
    }
    public float GetJumpVel()
    {
        return _jumpVel;
    }
    public void SetJumpVel(float value)
    {
        _jumpVel = value;
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
