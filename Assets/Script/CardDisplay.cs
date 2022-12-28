using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    #region Variables
    public Card card;
    public MeshRenderer MeshRenderer;
    public Material material;
    #endregion

    #region Start
    void Start()
    {
        //MeshRenderer.material.SetTexture("_BaseMap", card.artwork);
        MeshRenderer.GetComponent<MeshRenderer>().material = card.cardMaterial;
    }
    #endregion

}
