using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneWithID(int scene_id)
    {
        SceneManager.LoadScene(scene_id);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
}
