using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum State {MOVE, FLIP_CARD, UI_TURN}

public class GameManager : MonoBehaviour
{
    #region Variables
    public State state;
    public Player_scriptable player;
    public Card CurrentCard;

    public Canvas UItext;
    public Canvas UIMovement;

    public TextMeshProUGUI Cardname;
    public TextMeshProUGUI CardDescription;
    public TextMeshProUGUI PV_Player;
    public TextMeshProUGUI Keys_Player;
    public Image CardArtwork;


    public GameObject[] listButtons;
    #endregion

    #region Fonctions
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
                UItext.enabled = true;
                UIMovement.enabled = false;
                Cardname.SetText(CurrentCard.name);
                CardDescription.SetText(CurrentCard.description);
                CardArtwork.sprite = CurrentCard.artwork2;
                PV_Player.text = player.P_Life.ToString();
                Keys_Player.text = player.keys.ToString();

                break;
            
            case State.UI_TURN:

                state = State.MOVE;
                player.state = state;
                UIMovement.enabled = true;
                UItext.enabled = false;
                break;
            
        }

    }
    #endregion
}
