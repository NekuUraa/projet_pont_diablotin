using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clé : MonoBehaviour
{
    public Rigidbody playerRb;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(player.key);
        player.key += 1;
    }
}
