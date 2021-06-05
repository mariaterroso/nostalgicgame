using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Interface : MonoBehaviour
{
    public static bool gameover = false;
    [SerializeField] GameObject Panel;


    void Update()
    {
        if (gameover)
        {
            Panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void SairJogo()
    {
        Application.Quit();
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);
        gameover = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}