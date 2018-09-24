using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class ChunkSpawner : MonoBehaviour {

    [SerializeField]
    public Chunk[] _chunks;

    private Transform _player;
    private Chunk _previousChunk;
    private float _trigger = -8;
    //private int _chunkCounter = 0;


	private void Awake () {
        _player = GameObject.FindWithTag("Player").transform;
	}

    private void Start()
    {
        _previousChunk = FindObjectOfType<Chunk>();
    }

    private void Update()
    {
        if(_trigger < _player.position.x)
        {
            SpawnChunk();
        }
    }

    public void SpawnChunk ()
    {
        Chunk newChunk = _chunks[Random.Range(0, _chunks.Length)];
        Vector2 position = new Vector2( (_previousChunk.Position.x + _previousChunk.Size.x / 2f) + (newChunk.Size.x / 2f),
                                        0);
        _previousChunk = Instantiate(newChunk, position, Quaternion.identity);
        _previousChunk.transform.SetParent(transform);

        _trigger += newChunk.Size.x;

        //_chunkCounter++;
        //if(_chunkCounter >= 2)
        //{
            //_chunkCounter = 2;
            //GameObject.Destroy( GameObject.FindWithTag("ChunkSpawner").transform.GetChild(0) );
        //}
    }
}
