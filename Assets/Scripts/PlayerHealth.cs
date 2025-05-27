using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int MaxPlayerHP = 3;
    [SerializeField] public int CurrnetPlayerHp;
    public TextMeshProUGUI playerHptext;

    [SerializeField] private AudioClip hitSound; // Звук удара
    [SerializeField] private AudioSource audioSource; // Компонент для проигрывания звуков
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
        playerHptext.text = "ХП:" + CurrnetPlayerHp;
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
                audioSource.PlayOneShot(hitSound);
        }
    }
    
}
