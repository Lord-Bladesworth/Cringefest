using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playerRotator : MonoBehaviour
{
    [SerializeField]
    Transform playermodel;

    PlayerController controller;

    Vector2 input { get { return controller.getInput; } }
    float RotateY;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       // ApplyRotation();

    }
    private void FixedUpdate()
    {
        ApplyRotationToModel(); //deal with this for now
        //ApplyRotation();
    }
    Vector3 lookAtPoint;
    void ApplyRotationToModel()
    {
        Vector3 lookAtPoint = new Vector3(transform.position.x+ input.x, transform.position.y, transform.position.z + input.y);
        playermodel.LookAt(lookAtPoint);
    }

  
    Vector3 Direction;
    Quaternion toRotation;
    void ApplyRotation()
    {
        lookAtPoint = new Vector3(transform.position.x + input.x, transform.position.y, transform.position.z + input.y);
        Direction = new Vector3(transform.position.x - lookAtPoint.x, transform.position.y, transform.position.z - lookAtPoint.y);
        toRotation= Quaternion.FromToRotation(playermodel.transform.forward, Direction);
        
        playermodel.rotation = Quaternion.Lerp(playermodel.rotation, toRotation, 9);
    }
    private void OnGUI()
    {
        if (toRotation == null)
            return;
        GUI.Label(new Rect(50,50, 320, 80),lookAtPoint+""+Direction+" "+toRotation.ToString());
    }


}
