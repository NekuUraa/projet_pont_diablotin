using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde : MonoBehaviour
{


    public bool Direction = false;
    public float NumDirection = 3;

    public Player_scriptable player;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.P_Life);
    }

    public void UpdateIA()
    {
        if (Direction)
        {
            
            transform.position += Vector3.right * NumDirection;
        }


        else
        {
            transform.position += Vector3.left * NumDirection;
        }

        Direction = !Direction;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            Debug.Log("Oui je touche le joueur");
            player.P_Life -= 1;
            gameManager.ChangeState();
        }
    }

    void FixedUpdate()
    {
        
    }

    }
