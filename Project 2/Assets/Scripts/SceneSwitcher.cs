using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private string scene1 = "Gameplay Prototype";
    private string scene2 = "Art Prototype";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchScene();
        }
    }

    void SwitchScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        string nextScene = (currentScene == scene1) ? scene2 : scene1;

        SceneManager.LoadScene(nextScene);
    }
}
