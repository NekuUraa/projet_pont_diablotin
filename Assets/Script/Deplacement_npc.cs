using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.LightAnchor;

public class Deplacement_npc : MonoBehaviour
{
    public bool Direction = false;
    public float NumDirection = 3;
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

    public void UpdateIA2()
    {
        if (Direction)
        {

            transform.position += Vector3.forward * NumDirection;
        }


        else
        {
            transform.position += Vector3.back * NumDirection;
        }

        Direction = !Direction;
    }
}
