using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int MaxPlayerHP = 3;
    [SerializeField] public int CurrnetPlayerHp;
    
    void Start()
    {
        CurrnetPlayerHp = MaxPlayerHP;
    }

    private void Update()
    {
        if (CurrnetPlayerHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
                CurrnetPlayerHp--;
            
        }
    }
    
}
