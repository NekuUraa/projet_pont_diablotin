using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {MOVE, FLIP_CARD, UI_TURN}

public class GameManager : MonoBehaviour
{

    public State state;
    // Start is called before the first frame update
    void Start()
    {
        ChangeState();
        ChangeState();
        ChangeState();
    }


    public void ChangeState(){



        switch (state)
        {
            case State.MOVE: 
                
                Debug.Log("BOUGE");
                state = State.FLIP_CARD;
                break;
            
            case State.FLIP_CARD:
                Debug.Log("FLIP");
                state = State.UI_TURN;
                break;
            
            case State.UI_TURN:
                Debug.Log("UI TURN");
                state = State.MOVE;
                break;
            
        }

    }
}
