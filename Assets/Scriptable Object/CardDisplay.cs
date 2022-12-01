using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public MeshRenderer MeshRenderer;
    void Start()
    {
        MeshRenderer.material.SetTexture("_MainTex", card.artwork);
    }

}
