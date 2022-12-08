using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Player_scriptable : MonoBehaviour
{

    public GameObject gameManager;
    public GameManager gmScript;
    public State state;

    public Card CurrentCard;
    public bool hasKeys = false;
    public bool hasBrique = false;

    public bool moveForward = true;
    public bool moveLeft = true;
    public bool moveRight = true;
    public bool moveBack = true;


    public float distanceRay = 3f;


    
    void Start()
    {
        state = gameManager.GetComponent<GameManager>().state;
    }

    
    void Update()
    {
        //CE QUI SE PASSE A CHAQUE FRAME A L'ETAT MOVE
        if(state == State.MOVE){
            Move();
        }

    }

    void FixedUpdate()
    {
        Raycasting();
    }

   

    public void Move()
    {

        //AVANCER
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (moveForward)
            {
                transform.position += Vector3.forward * 3f;
            }
        }

        //RECULER
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (moveBack)
            {
                transform.position += Vector3.forward * -3f;
            }
        }

        //DROITE
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (moveRight)
            {
                transform.position += Vector3.right * 3f;
            }
        }

        //GAUCHE
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (moveLeft)
            {
                transform.position += Vector3.left * 3f;
            }
        }
    }

    public void Raycasting()
    {
        RaycastHit hit;

        // Rayon devant
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.green);
            Debug.Log("Did Hit");
            moveForward = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * distanceRay, Color.red);
            Debug.Log("Did not Hit");
            moveForward = true;
        }

        //Rayon derrière

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Did Hit");
            moveBack = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceRay, Color.red);
            Debug.Log("Did not Hit");
            moveBack = true;
        }

        //Rayon droite

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
            Debug.Log("Did Hit");
            moveLeft = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * distanceRay, Color.red);
            Debug.Log("Did not Hit");
            moveLeft = true;
        }

        //Rayon gauche

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.green);
            Debug.Log("Did Hit");
            moveRight = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * distanceRay, Color.red);
            Debug.Log("Did not Hit");
            moveRight = true;
        }
    }

    public void getKeys()
    {
        hasKeys = true;
    }

    public void getBrique()
    {
        hasBrique = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        gameManager.GetComponent<GameManager>().ChangeState();
        state = gameManager.GetComponent<GameManager>().state;  
        gameManager.GetComponent<GameManager>().CurrentCard = other.gameObject.GetComponent<CardDisplay>().card;
        //other.gameObject.faisTesTrucsDeCarte();
        //other.gameObject.faisTesTrucsSpéciaux();

        if (gameManager.GetComponent<GameManager>().CurrentCard.name == "Cle")
        {
            getKeys();
        }

        if (gameManager.GetComponent<GameManager>().CurrentCard.name == "Brique")
        {
            getBrique();
        }

        other.enabled = false;
    }



}
