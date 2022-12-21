using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player_tactile : MonoBehaviour
{

    public Player_scriptable player;
    public Camera cameraL;
    public Vector3 cameraTargetPos;

    // Start is called before the first frame update
    void Start()
    {
        cameraTargetPos = cameraL.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void movementCam()
    {
       
    }
    public void moveDroite()
    {
        Vector2 _targetPos = Vector2.zero;

        _targetPos.x = 1;


        transform.position = new Vector3(transform.position.x + _targetPos.x * 3f, transform.position.y, transform.position.z + _targetPos.y * 3f);
        cameraTargetPos = new Vector3(cameraTargetPos.x + _targetPos.x * 3f, cameraTargetPos.y, cameraTargetPos.z + _targetPos.y * 3f);
    }
    
}
