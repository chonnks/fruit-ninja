using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneChanges : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadMainMode()
    {
        SceneManager.LoadScene("Main Game Mode");
    }
    public void LoadHardMode()
    {
        SceneManager.LoadScene("HARD MODE");
    }

    public void LoadZenMode()
    {
        SceneManager.LoadScene("Zen Mode");
    }
}
