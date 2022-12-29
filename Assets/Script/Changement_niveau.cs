using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changement_niveau : MonoBehaviour
{

    public GameObject gameManager;
    [SerializeField] private string sceneToLoad = "scene";

    public void OnTriggerEnter(Collider other)
    {
        if (gameManager.GetComponent<GameManager>().CurrentCard.ID == 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    }
