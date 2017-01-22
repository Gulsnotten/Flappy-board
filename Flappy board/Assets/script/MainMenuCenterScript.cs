using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCenterScript : MonoBehaviour
{
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
