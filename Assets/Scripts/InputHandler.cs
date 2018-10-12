using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class InputHandler : MonoBehaviour {

    // changeable input variables
    public KeyCode input_menu = KeyCode.Escape;
    public KeyCode input_slide = KeyCode.S;
    public KeyCode input_jump = KeyCode.D;
    public KeyCode input_shift = KeyCode.F;
    public KeyCode input_restart = KeyCode.R;

    // player
    public GameObject player;
    public GameObject restartButton;

    void Update () {
        // check if the player uses an ability
        if ( Input.GetKey( input_menu ) ) print("Menu");
        if ( Input.GetKey( input_slide ) ) player.GetComponent<PlayerAbilities>().ActivateSlide();
        else player.GetComponent<PlayerAbilities>().DeActivateSlide();

        if ( Input.GetKey( input_jump ) )  player.GetComponent<PlayerAbilities>().Jump();
        if ( Input.GetKey( input_shift ) ) player.GetComponent<PlayerAbilities>().Shift();
        if (Input.GetKey(input_restart)) restartButton.GetComponent<Menu>().LoadGame();
    }
}
