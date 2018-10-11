using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class BossFightSpawner : MonoBehaviour {

    public float minimumTime;
    public float maximumTime;
    public float delaySpawn;
    private float currentTime;
    private float _timer = 0;
    private bool _fighting = false;
    private bool _spawned = false;
    private Transform _player;

    public AntiVirus antiVirus;
    private AntiVirus _currentAntiVirus;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
        PlanBossFight();
    }

    // Update is called once per frame
    void Update () {
        if(!_fighting)
        {
            _timer += Time.deltaTime;
            if (_timer >= currentTime)
            {
                _timer = 0;
                BossFight();
            }
        }
        if (!_spawned && _fighting) BossFight();
	}

    void PlanBossFight()
    {
        currentTime = Random.Range(minimumTime, maximumTime);
    }

    void BossFight()
    {
        _timer += Time.deltaTime;
        _fighting = true;
        if (_timer >= delaySpawn)
        {
            _currentAntiVirus = Instantiate(antiVirus, new Vector3(_player.position.x + 24, 0, 0), Quaternion.identity);
            _currentAntiVirus.transform.SetParent(transform);
            _spawned = true;
        }          
    }

    public void DefeatBossFight()
    {
        currentTime = 0;
        _fighting = false;
        _spawned = false;
        _currentAntiVirus = null;
        PlanBossFight();
    }


    public bool GetBossFight()
    {
        return _fighting;
    }
}
