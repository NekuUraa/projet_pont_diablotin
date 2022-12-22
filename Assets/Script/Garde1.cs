using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garde1 : MonoBehaviour
{


    public bool Direction = false;
    public float NumDirection = 3;

    public GameObject gameManager;
    public GameManager gmScript;
    public Player_scriptable player;

    [SerializeField] float amplitude = 0.1f;
    [SerializeField] float duration = 10f;


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

    IEnumerator Shake(float delay)
    {
        Camera cam = Camera.main;
        Vector3 pos = cam.transform.position;

        while(delay> 0)
        {
            cam.transform.position = new Vector3(
                pos.x + amplitude,
                pos.y + amplitude,
                pos.z + amplitude);

            yield return new WaitForSeconds(0.05f);

            cam.transform.position = new Vector3(
                pos.x - amplitude,
                pos.y - amplitude,
                pos.z - amplitude);

            yield return new WaitForSeconds(0.05f);

            delay -= 1;
        }

        cam.transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {

        

        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            StartCoroutine(Shake(duration));
            Debug.Log(Time.frameCount);

            Debug.Log("Oui je touche le joueur");
            player.ChangeLife(-1f);
            //gameManager.ChangeState();
        }
    }


    void FixedUpdate()
    {
        
    }

    }
