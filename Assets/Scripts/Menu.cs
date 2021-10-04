using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();
    }
    public void RetryLevel()
    {
        SceneManager.LoadScene(1);
    }

}
