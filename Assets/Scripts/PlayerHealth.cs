using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int MaxPlayerHP = 3;
    [SerializeField] public int CurrnetPlayerHp;
    //Присваеваем хп
    void Start()
    {
        CurrnetPlayerHp = MaxPlayerHP;
    }
    //Проверка еа хп
    private void Update()
    {
        if (CurrnetPlayerHp <= 0)
        {
            Die();
        }
    }
    //Смерть игрока
    private void Die()
    {
        SceneManager.LoadScene(0);
    }
    //Для EnemyAttack
    public void TakeDamage(int damage) {
        {                      
                CurrnetPlayerHp -= damage;
        }
    }
    
}
