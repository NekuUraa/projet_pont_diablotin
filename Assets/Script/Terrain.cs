using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{

    public GameObject gameManager;

    public bool activeCard = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.GetComponent<GameManager>().CurrentCard.ID == 2)
        {
            activeCard = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameManager.GetComponent<GameManager>().CurrentCard.ID == 2)
        {
            activeCard = true;
        }
    }
}
