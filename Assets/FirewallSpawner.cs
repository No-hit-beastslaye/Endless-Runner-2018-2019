using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewallSpawner : MonoBehaviour {

    [SerializeField]
    public Firewall[] _firewalls;
    private Firewall _previousFirewall;
    private Transform _player;
    public int minimunDistance;
    public int maximumDistance;

	void Awake () {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        SpawnFirewall();
    }

    void Update () {
		
	}

    private void SpawnFirewall()
    {
        Firewall newFirewall = _firewalls[Random.Range(0, _firewalls.Length)];
        Vector3 position;
        if (_previousFirewall == null)
        {
            position = new Vector3( Mathf.Floor(Random.Range( (_player.position.x + minimunDistance), maximumDistance)), 
                                    newFirewall.Size.y - 1.42f, 2);
        }
        else
        {
            position = new Vector3( Mathf.Floor(Random.Range( (_previousFirewall.Position.x + _previousFirewall.Size.x + minimunDistance) , maximumDistance)),
                                    newFirewall.Size.y, 2);
        }
        _previousFirewall = Instantiate(newFirewall, position, Quaternion.identity);
        _previousFirewall.transform.SetParent(transform);
    }
}
