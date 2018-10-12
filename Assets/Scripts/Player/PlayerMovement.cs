using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _body;

    public float speed;                 // speed
    public float gravity;               // graivty
    private float _jumpVel;             // jump veloticy
    bool _stop = false;                 // stop player movement
    private float _distance = 0;        // distance travelled
    public GameObject Score;

    public Component Restart_Button;    //Restart button
    public Component Restart_Text;      //Restart button text
    public int Counter = 0;

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
        //Brandon Ruigrok
        if (_stop == true)
        {
            Counter++;

            if(Counter == 30)
            {
                Restart_Text.gameObject.SetActive(false);
            }

            else if(Counter == 60)
            {
                Restart_Text.gameObject.SetActive(true);
                Counter = 0;
            }
        }
    }

    //Juda Hensen
    // calculate player forces
    private void CalculateMovement()
    {
        Vector2 position = _body.position;
        Vector2 calcPos = new Vector2(speed * Time.deltaTime, (-_jumpVel + -gravity) * Time.deltaTime);

        _body.MovePosition( (position + calcPos) );
        _jumpVel = 0;

        _distance += calcPos.x;
        Score.GetComponent<Score>().SetScore(Mathf.RoundToInt(_distance));
    }


    public void SetGravityFactor(string type, float value)
    {
        if(type == "*") gravity *= value;
        else if(type == "/") gravity /= value;
    }
    public void SetStop(bool value)
    {
        _stop = value;

        //Brandon Ruigrok
        if (_stop == true)
        {
            Restart_Button.gameObject.SetActive(true);
        }
    }

    //Juda Hensen
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
