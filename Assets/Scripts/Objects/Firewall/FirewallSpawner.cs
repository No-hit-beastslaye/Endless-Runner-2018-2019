using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class FirewallSpawner : MonoBehaviour {

    [SerializeField]
    public Firewall[] _firewalls;
    private Firewall _previousFirewall;
    private Transform _player;
    public int minimunDistance;
    public int maximumDistance;
    private float _trigger = 4;
    private int _firewallCounter;

	void Awake () {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        SpawnFirewall();
    }

    void Update () {
        if (_trigger <= _player.position.x) SpawnFirewall();
	}

    private void SpawnFirewall()
    {
        Firewall newFirewall = _firewalls[Random.Range(0, _firewalls.Length)];
        Vector3 position;
        if (_previousFirewall == null)
        {
            position = new Vector3( Mathf.Floor(_player.position.x + Random.Range(minimunDistance, maximumDistance)), 
                                    newFirewall.Size.y - 1.42f, 2);
        }
        else
        {
            position = new Vector3( Mathf.Floor(_previousFirewall.Position.x + _previousFirewall.Size.x + Random.Range(minimunDistance, maximumDistance)),
                                    newFirewall.Size.y, 2);
        }
        _previousFirewall = Instantiate(newFirewall, position, Quaternion.identity);
        _previousFirewall.transform.SetParent(transform);

        _trigger = _previousFirewall.Position.x;
        _firewallCounter++;
        if(_firewallCounter > 2)
        {
            _firewallCounter = 2;
            GameObject.FindWithTag("FirewallSpawner").transform.GetChild(0).GetComponent<Firewall>().Remove();
        }
    }
}
