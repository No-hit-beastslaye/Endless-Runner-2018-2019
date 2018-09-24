using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class InputHandler : MonoBehaviour {

    // changeable input variables
    public KeyCode input_menu = KeyCode.Escape;
    public KeyCode input_slide = KeyCode.A;
    public KeyCode input_jump = KeyCode.W;
    public KeyCode input_shift = KeyCode.S;

    // player
    public GameObject player;


	void Update () {
        // check if the player uses an ability
        if ( Input.GetKey( input_menu ) ) print("Menu");
        if ( Input.GetKey( input_slide ) ) player.GetComponent<PlayerAbilities>().Slide();
        if ( Input.GetKey( input_jump ) )  player.GetComponent<PlayerAbilities>().Jump();
        if ( Input.GetKey( input_shift ) ) player.GetComponent<PlayerAbilities>().Shift();
	}
}
