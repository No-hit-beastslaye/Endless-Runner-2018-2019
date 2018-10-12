using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class ChunkSpawner : MonoBehaviour {

    [SerializeField]
    public Chunk[] _chunks;
    public Chunk[] _chunksBossFight;
    public GameObject bossFightSpawner;

    private Transform _player;
    private Chunk _previousChunk;
    private float _trigger = -9;
    private int _chunkCounter = 0;

	private void Awake () {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        _previousChunk = FindObjectOfType<Chunk>();
        SpawnChunk();
    }

    private void Update()
    {
        if(_chunkCounter == 1)
        {
            SpawnChunk();
            _trigger -= _previousChunk.Size.x;
        }
        if(_trigger <= _player.position.x) SpawnChunk();
    }

    public void SpawnChunk ()
    {
        Chunk newChunk;
        if(GameObject.FindWithTag("BossFightSpawner").GetComponent<BossFightSpawner>().GetBossFight()) // boss-fight
        {
            newChunk = _chunksBossFight[Random.Range(0, _chunksBossFight.Length)];
        }
        else // no boss-fight
        {
            newChunk = _chunks[Random.Range(0, _chunks.Length)];
        }
        Vector3 position = new Vector3((_previousChunk.Position.x + _previousChunk.Size.x / 2f) + (newChunk.Size.x / 2f),
                                            0, 2);
        _previousChunk = Instantiate(newChunk, position, Quaternion.identity);
        _previousChunk.transform.SetParent(transform);

        _trigger += newChunk.Size.x;

        _chunkCounter++;
        if (_chunkCounter >= 5)
        {
            _chunkCounter = 5;
            GameObject.FindWithTag("ChunkSpawner").transform.GetChild(0).GetComponent<Chunk>().Remove();
        }

    }
}
