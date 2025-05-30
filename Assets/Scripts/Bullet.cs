using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 1f;

    private void OnTriggerEnter(Collider other)
    {
        
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamageEnemy(damage);
        }

        
        Destroy(gameObject);
    }
}
