using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class PlayerAbilities : MonoBehaviour {

    // jump vars
    private bool _jumpActive = false;       // is the player jumping
    public float jumpHeight;                // jump height
    

    // shift vars
    private bool _shiftActive = false;      // is shift active
    private float _shiftActiveTimer = 2;    // tracks active time
    public float shiftMaxTime = 1.5f;       // maximum amount of time per use
    private bool _shiftDelay = false;       // is the delay active
    private float _shiftDelayTimer = 0;     // tracks time between shift usages  
    public float shiftMaxDelay = 1f;        // delay between shift usages

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
        print("jump");
    }

    private void CalculateJump()
    {

    }


    // allows the player to walk through fire-walls
    public void Shift ()
    {
        if(!_shiftDelay && !_shiftActive)
        {
            print("shift: active");
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
                print("shift: delay");
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
                print("shift: ready");
                _shiftActiveTimer = 0;
                _shiftDelay = false;
            }
        }
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
