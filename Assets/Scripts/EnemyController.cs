using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float enemyHP = 1f;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip GunSound;
    private float CurrentEnemyHP;
    //Тут хп присваеваем и находим игрока через тэг и его трансформ
    void Start()
    {
        CurrentEnemyHP = enemyHP;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //Враг ищет игрока и проверка на хп
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, speed * Time.deltaTime);
        if(CurrentEnemyHP <= 0)
        {
            Die();
        }
        
    }
    
    //Смерть врага
    private void Die()
    {
    
        Destroy(gameObject);
        AudioSource.PlayOneShot(GunSound);
    }
}
