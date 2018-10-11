using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Juda Hensen
public class AntiVirus : MonoBehaviour {

    public float shootDelay;    // delay between shots
    public float moveSpeed;     // horizontal movement speed
    public float hoverSpeed;    // vertical movement speed
    private float _timer;       // timer
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    void Update () {
        _timer += Time.deltaTime;
        if (_timer > shootDelay) Shoot();
        if(transform.position.x < _player.position.x - 10)
        {
            Defeat();
        }
        Move();
    }

    private void Shoot()
    {
        _timer = 0;
        print("shoot");
    }

    private void Move()
    {
        transform.position = new Vector3(transform.position.x - (moveSpeed * Time.deltaTime), transform.position.y - (hoverSpeed * Time.deltaTime), 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("col");
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Ceiling")
        {
            print("inv");
            hoverSpeed = -hoverSpeed;
            Move();
        }
    }

    private void Defeat()
    {
        GameObject.FindWithTag("BossFightSpawner").GetComponent<BossFightSpawner>().DefeatBossFight();
        Destroy(gameObject);
    }

}
