using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public MeshRenderer MeshRenderer;
    public Material material;
    void Start()
    {
        MeshRenderer.material.SetTexture("_BaseMap", card.artwork);

       

    }

}
