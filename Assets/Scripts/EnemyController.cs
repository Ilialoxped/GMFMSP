using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform _player;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float enemyHP = 1f;
    private float CurrentEnemyHP;
    void Start()
    {
        CurrentEnemyHP = enemyHP;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);
        if(CurrentEnemyHP <= 0)
        {
            Die();
        }
        
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
