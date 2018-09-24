using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class Chunk : MonoBehaviour {

    [SerializeField]
    private Vector2 _size;
    public Vector2 Size { get { return _size; } }

    public Vector3 Position { get { return transform.position; } }

    public void Remove()
    {
        print("destroy");
        Destroy(this);
    }
}
