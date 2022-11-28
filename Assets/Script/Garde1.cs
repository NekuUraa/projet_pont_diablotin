using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde1 : MonoBehaviour
{


    public bool Direction = false;
    public int distanceRay = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateIA()
    {
        if (Direction)
        {
            
            transform.position += Vector3.right * 1f;
        }


        else
        {
            transform.position += Vector3.left * 1f;
        }

        Direction = !Direction;
    }

    void FixedUpdate()
    {

    }

    }
