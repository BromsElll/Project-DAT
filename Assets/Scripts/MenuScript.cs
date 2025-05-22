using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("2PreviewScene"); //Переход к повествовательной сцене
    }

    public void ExitGame()
    {
        Application.Quit(); //Выход из игры
    }
}