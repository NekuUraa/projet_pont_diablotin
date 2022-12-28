using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Player_scriptable : MonoBehaviour
{
    #region Variables
    public GameObject gameManager;
    public GameManager gmScript;
    public State state;

    public Card CurrentCard;
    public Deplacement_npc garde1;
    public Deplacement_npc carte1;
    public Deplacement_npc garde2;
    public Deplacement_npc carte2;
    public Deplacement_npc garde3;
    public Deplacement_npc carte3;
    public Deplacement_npc garde4;
    public Deplacement_npc carte4;
    public GameObject endCard;
    public Camera cameraL;

    

    public float P_Life = 3;

    public bool hasKeys = false;
    public int keys = 0;
    public bool hasBrique = false;

    public bool moveForward = true;
    public bool moveLeft = true;
    public bool moveRight = true;
    public bool moveBack = true;


    public float distanceRay = 3f;
    public float distanceRayDown = 2.5f;

    public Vector3 cameraTargetPos;


    private float damageCooldown = 0.5f;

    private float damageCooldownCounter = 0f;

    #endregion

    #region Start/Update/FUpdate

    void Start()
    {
        cameraTargetPos = cameraL.transform.position;

        state = gameManager.GetComponent<GameManager>().state;
    }

    
    void Update()
    {
        //CE QUI SE PASSE A CHAQUE FRAME A L'ETAT MOVE
        if(state == State.MOVE){
            Move();
        }

        cameraL.transform.position = Vector3.Lerp(cameraL.transform.position, cameraTargetPos, Time.deltaTime*2f);

        //Compteur frames invulnerabilit�
        damageCooldownCounter -= Time.deltaTime;

        noMoreLife();

    }

    void FixedUpdate()
    {
        Raycasting();
        //gmScript.updateButtons();
    }

    #endregion

    #region Déplacement
    public void MoveTactile(int direction)
    {
        Vector2 _targetPos = Vector2.zero;

        switch (direction)
        {
            //GAUCHE
            case 0:
                if (moveLeft)
                {
                    _targetPos.x = -1;
                }
                AfterMove();
                break;

            //HAUT
            case 1:
                if (moveForward)
                {
                    _targetPos.y = 1;
                }
                AfterMove();
                break;

            //DROITE
            case 2:
                if (moveRight)
                {
                    _targetPos.x = 1;
                }
                AfterMove();
                break;

            //BAS
            case 3:
                if (moveBack)
                {
                    _targetPos.y = -1;
                }
                AfterMove();
                break;

            default:
                Debug.Log("Les mouvements ne marchent pas");
                break;
        }


        transform.position = new Vector3(transform.position.x + _targetPos.x * 3f, transform.position.y, transform.position.z + _targetPos.y * 3f);
        cameraTargetPos = new Vector3(cameraTargetPos.x + _targetPos.x * 3f, cameraTargetPos.y, cameraTargetPos.z + _targetPos.y * 3f);


    }


    public void Move()
    {

        Vector2 _targetPos = Vector2.zero;

        //AVANCER
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (moveForward)
            {
                _targetPos.y  = 1;
            }
            AfterMove();
        }

        //RECULER
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (moveBack)
            {
                _targetPos.y = -1;
            }
            AfterMove();
        }

        //DROITE
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (moveRight)
            {
                _targetPos.x= 1;
            }
            AfterMove();
        }

        //GAUCHE
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (moveLeft)
            {
                _targetPos.x = -1;
            }
            AfterMove();
        }

        transform.position = new Vector3(transform.position.x + _targetPos.x * 3f, transform.position.y, transform.position.z +_targetPos.y * 3f);
        cameraTargetPos = new Vector3(cameraTargetPos.x + _targetPos.x * 3f, cameraTargetPos.y, cameraTargetPos.z + _targetPos.y * 3f);
    }

    public void AfterMove()
    {
        garde1.UpdateIA();
        carte1.UpdateIA();

        garde2.UpdateIA2();
        carte2.UpdateIA2();

        garde3.UpdateIA();
        carte3.UpdateIA();

        garde4.UpdateIA2();
        carte4.UpdateIA2();

    }

    #endregion

    #region Raycasting
    public void Raycasting()
    {
        RaycastHit hit;

        // Rayon devant
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.green);
            //Debug.Log("Did Hit");
            moveForward = false;

            if (hit.transform.tag == "Porte" && hasKeys == true)
            {
                hasKeys= false;
                keys -=1;
                Destroy(GameObject.FindWithTag("Porte"));
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * distanceRay, Color.red);
            //Debug.Log("Did not Hit");
            moveForward = true;
        }

        //Rayon derri�re

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            //Debug.Log("Did Hit");
            moveBack = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceRay, Color.red);
            //Debug.Log("Did not Hit");
            moveBack = true;
        }

        //Rayon droite

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.green);
            //Debug.Log("Did Hit");
            moveLeft = false;

            if (hit.transform.tag == "Porte" && hasKeys == true)
            {
                hasKeys = false;
                keys -= 1;
                Destroy(GameObject.FindWithTag("Porte"));
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * distanceRay, Color.red);
            //Debug.Log("Did not Hit");
            moveLeft = true;
        }

        //Rayon gauche

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.green);
            //Debug.Log("Did Hit");
            moveRight = false;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * distanceRay, Color.red);
            //Debug.Log("Did not Hit");
            moveRight = true;
        }

        //Rayon Bas

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, distanceRayDown))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * distanceRayDown, Color.red);
            //Debug.Log("Did not Hit");
        }
    }

    #endregion

    #region Autres fonctions
    public void GetKeys()
    {
        keys += 1;
        hasKeys = true;
    }

    public void GetBrique()
    {
        hasBrique = true;
    }

   public void noMoreLife()
    {
        if(P_Life <= 0)
        {
            SceneManager.LoadScene("GameOver");
         }
    }


    public void ChangeLife(float _modifier)
    {

        if (damageCooldownCounter > 0f)
            return;

        P_Life += _modifier;

        damageCooldownCounter = damageCooldown;

        Debug.Log(P_Life);
    }

    #endregion

    #region Collisions
    public void OnTriggerEnter(Collider other)
    {
            gameManager.GetComponent<GameManager>().CurrentCard = other.gameObject.GetComponent<CardDisplay>().card;
            gameManager.GetComponent<GameManager>().ChangeState();
            //Permet de changer de tours

            gameManager.GetComponent<GameManager>().ChangeState();
            state = gameManager.GetComponent<GameManager>().state;
            //other.gameObject.faisTesTrucsDeCarte();
            //other.gameObject.faisTesTrucsSp�ciaux();

            if (gameManager.GetComponent<GameManager>().CurrentCard.name == "Cle")
            {
                hasKeys= true;
                keys += 1;
            }

            if (gameManager.GetComponent<GameManager>().CurrentCard.name == "Voleur")
            {
                hasKeys= true;
                keys += 1;
            }

            if (gameManager.GetComponent<GameManager>().CurrentCard.name == "Brique")
                {
                    GetBrique();
                    endCard.SetActive(true);
                }

            if (gameManager.GetComponent<GameManager>().CurrentCard.name == "Boulangerie")
            {
                P_Life += 1;
            }

            if (gameManager.GetComponent<GameManager>().CurrentCard.name == "Fin")
                {
                    SceneManager.LoadScene("Menu");
                    Debug.Log("Fin");
                }

        //other.enabled = false;

        if (gameManager.GetComponent<GameManager>().CurrentCard.ID == 1)
        {

            other.transform.rotation = Quaternion.Euler(0, 90, 0);
            other.enabled = false;


        }

        if (gameManager.GetComponent<GameManager>().CurrentCard.ID == 2)
        {

            Debug.Log("Carte2");


        }

    }

    #endregion



}
