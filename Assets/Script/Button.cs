using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    #region Variables
    [SerializeField] private string sceneToLoad = "scene";
    [SerializeField] private float duration = 1.5f;
    #endregion

    #region Fonctions
    IEnumerator waitToLoad(float delay)
    {
        while (delay > 0)
        {

            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(sceneToLoad);
            delay -= 1;
        }
    }

    public void NewButtonGame()
    {
        StartCoroutine(waitToLoad(duration));
        
    }
    #endregion
}
