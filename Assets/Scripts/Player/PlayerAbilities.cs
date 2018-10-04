using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class PlayerAbilities : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _body;

    // jump vars
    private bool _jumpActive = false;       // is the player jumping
    private bool _jumpDelay;                // is the player falling
    public float jumpHeight;                // jump height
    public float fallSpeed;                 // fallspeed
    private float _jumpVel;                 // jump velocity to send
    public float jumpAcc;                   // jump acceleration
    private float _jumpPos;                 // current jump sine position
    //public float

    // shift vars
    private bool _shiftActive = false;      // is shift active
    private float _shiftActiveTimer = 2;    // tracks active time
    public float shiftMaxTime = 1.5f;       // maximum amount of time per use
    private bool _shiftDelay = false;       // is the delay active
    private float _shiftDelayTimer = 0;     // tracks time between shift usages  
    public float shiftMaxDelay = 1f;        // delay between shift usages

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CalculateJump();
        RenderShift();
    }

    // lets the player slide on the ground
    public void Slide ()
    {
        print("slide");
    }


    // lets the player jump
    public void Jump ()
    {
        if(!_jumpActive && !_jumpDelay)
        {
            print("jump");
            _jumpActive = true;
        } 
    }

    // calculate player jump velocity
    private void CalculateJump()
    {
        if (_jumpActive)
        {
            _jumpVel = _body.position.y + jumpHeight * Mathf.Sin(_jumpPos * Mathf.PI / 180);
            GetComponent<PlayerMovement>().SetJumpVel(_jumpVel);

            _jumpPos += jumpAcc;

            if (_jumpPos > 270)
            {
                _jumpPos = 270 + (270 - _jumpPos);
                _jumpActive = false;
                _jumpDelay = true;
            }
        }
        else if(_jumpDelay)
        {
            _jumpVel = _body.position.y + fallSpeed * Mathf.Sin(_jumpPos * Mathf.PI / 180);
            GetComponent<PlayerMovement>().SetJumpVel(_jumpVel);

            if (_jumpPos < 180)
            {
                _jumpPos = 180;
            }
            else _jumpPos -= jumpAcc;
        }
        else
        {
            _jumpPos = 180;
        }
    }


    // allows the player to walk through fire-walls
    public void Shift ()
    {
        if(!_shiftDelay && !_shiftActive)
        {
            _shiftActive = true;
        }
    }

    private void RenderShift()
    {
        if (_shiftActive)
        {
            _shiftActiveTimer += Time.deltaTime;
            if (_shiftActiveTimer >= shiftMaxTime)
            {
                _shiftActiveTimer = 0;
                _shiftActive = false;
                _shiftDelay = true;
            }
        }
        else if (_shiftDelay)
        {
            if (_shiftDelayTimer < shiftMaxDelay)
            {
                _shiftDelayTimer += Time.deltaTime;
            }
            else
            {
                _shiftActiveTimer = 0;
                _shiftDelay = false;
            }
        }
    }


    public bool GetJumpActive()
    {
        return _jumpActive;
    }
    public void SetJumpActive(bool value)
    {
        _jumpActive = value;
    }
    public bool GetJumpDelay()
    {
        return _jumpDelay;
    }
    public void SetJumpDelay(bool value)
    {
        _jumpDelay = value;
    }


    public bool GetShiftActive()
    {
        return _shiftActive;
    }
    public void SetShiftActive(bool value)
    {
        _shiftActive = value;
    }
}
