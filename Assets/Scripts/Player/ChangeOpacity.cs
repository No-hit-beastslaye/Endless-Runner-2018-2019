using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class ChangeOpacity : MonoBehaviour {

    private float _timeTotal = 0;       // maximum time
    private float _timer = 0;           // timer
    private float _currentOpacity = 1;  // current opacity value
    public float fadeTime = 1;          // Time to change opacity
    private float _fadeSpeed;            // speed of the fade effect

	// Update is called once per frame
	void Update () {
        if (_timeTotal > 0)
        {
            _fadeSpeed = 1 / (fadeTime * 60);
            ChangeColor();
        }
	}


    private void ChangeColor() {
        _timer += Time.deltaTime;
        if (_timer < fadeTime)
        {
            _currentOpacity -= _fadeSpeed;
            if (_currentOpacity < 0) _currentOpacity = 0; 
        }
        else if(_timer > _timeTotal - fadeTime && _timer < _timeTotal)
        {
            _currentOpacity += _fadeSpeed;
            if (_currentOpacity > 1) _currentOpacity = 1;
        }
        else if(_timer >= _timeTotal)
        {
            print("reset");
            _timeTotal = 0;
            _timer = 0;
        }

        this.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, _currentOpacity);
    }

    public float GetTimeTotal()
    {
        return _timeTotal;
    }
    public void SetTimeTotal(float value)
    {
        _timeTotal = value;
    }

}
