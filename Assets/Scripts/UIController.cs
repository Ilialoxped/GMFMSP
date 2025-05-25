using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Выход успешен!");
    }
    public void Settings()
    {
        SceneManager.LoadScene(1);
    }

}
