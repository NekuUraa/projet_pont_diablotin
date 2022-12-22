using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum State {MOVE, FLIP_CARD, UI_TURN}

public class GameManager : MonoBehaviour
{
     
    public State state;
    public Player_scriptable player;
    //public Player_scriptable playerScript;
    public Transform garde1;
    public Transform garde2; 
    public Card CurrentCard;

    public Canvas UItext;
    public Canvas UIMovement;

    public TextMeshProUGUI Cardname;
    public TextMeshProUGUI CardDescription;
    public Material Cardartwork;

    public int nombreTest= 0;

    public GameObject[] listButtons;


    // Start is called before the first frame update
    void Start()
    {
        //ChangeState();
    }

    public void Update()
    {


        /*if (state == State.UI_TURN) 
        {
            if(Input.GetKeyUp(KeyCode.Space)) 
            {
                ChangeState();
            }
        }*/
    }

    public void updateButtons()
    {
        listButtons[0].SetActive(player.moveLeft);
        listButtons[1].SetActive(player.moveForward);
        listButtons[2].SetActive(player.moveRight);
        listButtons[3].SetActive(player.moveBack);
    }

    public void ChangeState()
    {



        switch (state)
        {
            case State.MOVE:

                state = State.FLIP_CARD;
                player.state = state;
                break;
            
            case State.FLIP_CARD:

                state = State.UI_TURN;
                player.state = state;
                UIMovement.enabled = false;
                UItext.enabled = true;
                Cardname.SetText(CurrentCard.name);
                CardDescription.SetText(CurrentCard.description);
                break;
            
            case State.UI_TURN:

                state = State.MOVE;
                player.state = state;
                UIMovement.enabled = true;
                UItext.enabled = false;
                break;
            
        }

    }

}
