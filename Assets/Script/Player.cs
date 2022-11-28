using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float distanceRay = 1f;
    public bool RaycastForTouche = false;
    public bool desacMouvFor = false;
    public bool desacMouvBack = false;
    public bool desacMouvRight = false;
    public bool desacMouvLeft = false;


    public GameObject[] gardes;

    public int key = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //AVANCER
        if (Input.GetKeyDown(KeyCode.UpArrow) && desacMouvFor == false)
        {
            transform.position += Vector3.forward * 1.2f;
            AfterMovementLogic();
        }

        //RECULER
        if (Input.GetKeyDown(KeyCode.DownArrow) && desacMouvBack == false)
        {
            transform.position += Vector3.forward * -1.2f;
            AfterMovementLogic();
        }

        //DROITE
        if (Input.GetKeyDown(KeyCode.RightArrow) && desacMouvRight == false)
        {
            transform.position += Vector3.right * 1f;
            AfterMovementLogic();
        }

        //GAUCHE
        if (Input.GetKeyDown(KeyCode.LeftArrow) && desacMouvLeft == false)
        {
            transform.position += Vector3.left * 1f;
            AfterMovementLogic();
        }

        
    }


    void AfterMovementLogic() {
        for (int i = 0; i < gardes.Length; i++)
        {
            gardes[i].GetComponent<Garde1>().UpdateIA();
        }
    }
    void FixedUpdate()
    {

        RaycastHit hit;
        
        //RAYCAST DEVANT

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceRay * hit.distance, Color.green);
            //.Log("Did Hit");
            desacMouvFor = true;

            if (hit.transform.tag == "Porte" && key>= 1)
            {
                Destroy(GameObject.FindWithTag("Porte"));   
                    
            }

            if (hit.transform.tag == "Brique")
            {
                Destroy(GameObject.FindWithTag("Brique"));

                for (int i = 0; i < gardes.Length; i++)
                {
                    gardes[i].SetActive(true);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* distanceRay, Color.red);
            //Debug.Log("Did not Hit");
            desacMouvFor = false;

        }

        //RAYCAST DROITE
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * distanceRay * hit.distance, Color.green);
            //Debug.Log("Did Hit");
            desacMouvRight = true;

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * distanceRay, Color.red);
            //Debug.Log("Did not Hit");
            desacMouvRight = false;

        }

        //RAYCAST GAUCHE
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * distanceRay * hit.distance, Color.green);
            //Debug.Log("Did Hit");
            desacMouvLeft = true;

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * distanceRay, Color.red);
            //Debug.Log("Did not Hit");
            desacMouvLeft = false;

        }

        //RAYCAST DERRIERE
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, distanceRay))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * distanceRay * hit.distance, Color.green);
            //Debug.Log("Did Hit");
            desacMouvBack = true;

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * distanceRay, Color.red);
            //Debug.Log("Did not Hit");
            desacMouvBack = false;

        }




    }

}
