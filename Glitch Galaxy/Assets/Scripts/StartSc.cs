using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSc : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(3);
    }
    public void Level4()
    {
        SceneManager.LoadScene(4);
    }
    public void Level5()
    {
        SceneManager.LoadScene(5);
    }
    public void Level6()
    {
        SceneManager.LoadScene(6);
    }
    public void EndGame()
    {
        Application.Quit();
        
    }
    public void EndScene()
    {
        SceneManager.LoadScene(7);
    }
    public void ReplayLevels()
    {
        SceneManager.LoadScene(8);
    }
}
