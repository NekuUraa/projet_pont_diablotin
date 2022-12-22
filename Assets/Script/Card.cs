using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")] 
public class Card : ScriptableObject
{
    #region Variables
    public new string name;
    public string description;
    public int ID;

    public Texture2D artwork;

    public Sprite artwork2;

    public Material cardMaterial;
    #endregion
}
