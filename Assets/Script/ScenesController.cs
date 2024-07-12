using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void SceneLoad(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
