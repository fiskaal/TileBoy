using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("L1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("L2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("L3");
    }
    public void LoadTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }
}
