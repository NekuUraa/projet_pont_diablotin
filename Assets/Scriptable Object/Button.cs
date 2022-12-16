using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "scene";

    public void NewButtonGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
