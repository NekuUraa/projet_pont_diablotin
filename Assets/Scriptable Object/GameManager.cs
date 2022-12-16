using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum State {MOVE, FLIP_CARD, UI_TURN}

public class GameManager : MonoBehaviour
{
     
    public State state;
    public GameObject player;
    public Transform garde1;
    public Transform garde2; 
    public Card CurrentCard;

    public Canvas UItext;

    public TextMeshProUGUI Cardname;
    public TextMeshProUGUI CardDescription;
    public RawImage Cardartwork;


    // Start is called before the first frame update
    void Start()
    {
        //ChangeState();
    }

    public void Update()
    {


        if (state == State.UI_TURN) 
        {
            if(Input.GetKeyUp(KeyCode.Space)) 
            {
                ChangeState();
            }
        }
    }

    public void ChangeState()
    {



        switch (state)
        {
            case State.MOVE: 
                
                //Debug.Log("BOUGE");
                state = State.FLIP_CARD;
                player.GetComponent<Player_scriptable>().state = state;
                break;
            
            case State.FLIP_CARD:

                //Debug.Log("FLIP");
                state = State.UI_TURN;
                player.GetComponent<Player_scriptable>().state = state; 
                UItext.enabled = true;
                Cardname.SetText(CurrentCard.name);
                CardDescription.SetText(CurrentCard.description);
                break;
            
            case State.UI_TURN:
                    
                //Debug.Log("UI TURN");
                state = State.MOVE;
                player.GetComponent<Player_scriptable>().state = state;
                UItext.enabled = false;
                break;
            
        }

    }

    public void CheckGuardCollision(Transform garde)
    {
        Vector3 delta = garde.position - player.transform.position;
        Debug.Log(delta.magnitude);
        if(delta.magnitude < 2.8)
        {
            Debug.Log("delta.magnitude < 1");
        }
    }
}
