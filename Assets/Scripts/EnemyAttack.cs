using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackCooldown = 3f;
    [SerializeField] private float attackRange = 1.5f;

    private float _lastAttackTime;
    private Transform _player;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerHealth = _player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (Time.time > _lastAttackTime + attackCooldown)
        {
            if (IsPlayerInRange())
            {
                Attack();
            }
        }
    }

    private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, _player.position) <= attackRange;
    }
    //Атака с дебагом
    private void Attack()
    {
        _playerHealth.TakeDamage(damage);
        _lastAttackTime = Time.time;

    
        Debug.Log(gameObject.name + " атаковал игрока!");
    }

    //Радиус атаки в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
