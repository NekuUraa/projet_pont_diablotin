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

        Debug.Log(UItext.enabled);

        if (state == State.UI_TURN) 
        {
            if(Input.GetKeyUp(KeyCode.Space)) 
            {
                ChangeState();
            }
        }
    }

    public void ChangeState(){



        switch (state)
        {
            case State.MOVE: 
                
                Debug.Log("BOUGE");
                state = State.FLIP_CARD;
                player.GetComponent<Player_scriptable>().state = state;
                break;
            
            case State.FLIP_CARD:
                Debug.Log("FLIP");
                state = State.UI_TURN;
                player.GetComponent<Player_scriptable>().state = state;
                
                UItext.enabled = true;
                //Ne se relance pas ?   
                Cardname.SetText(CurrentCard.name);
                CardDescription.SetText(CurrentCard.description);
                Cardartwork.material.SetTexture("_BaseMap", CurrentCard.artwork);
                break;
            
            case State.UI_TURN:
                Debug.Log("UI TURN");
                state = State.MOVE;
                player.GetComponent<Player_scriptable>().state = state;
                UItext.enabled = false;
                break;
            
        }

    }
}
