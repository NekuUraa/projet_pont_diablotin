using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player_scriptable : MonoBehaviour
{

    public GameObject gameManager;
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        state = gameManager.GetComponent<GameManager>().state;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(state == State.MOVE){
            Move();
        }
    }


    public void Move()
    {

        //AVANCER
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * 3f;
        }

        //RECULER
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.forward * -3f;
        }

        //DROITE
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * 3f;
        }

        //GAUCHE
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * 3f;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        gameManager.GetComponent<GameManager>().ChangeState();
        state = gameManager.GetComponent<GameManager>().state;
        Debug.Log("Oui je marche");
    }

}
