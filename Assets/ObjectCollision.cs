using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
    }

}
