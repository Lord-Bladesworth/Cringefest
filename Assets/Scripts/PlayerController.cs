using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;
    float speed = 0.11f;

    Vector2 _input;


    [SerializeField]
    float Deadzone = 0.32f;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void LateUpdate()
    {
        ReadInput();
        ApplyMovement();
    
    }
    void ReadInput()
    {
        _input = new Vector2(
           Mathf.Abs(Input.GetAxisRaw("Horizontal")) > Deadzone ? Input.GetAxis("Horizontal") : 0,
           Mathf.Abs(Input.GetAxisRaw("Vertical")) > Deadzone ? Input.GetAxis("Vertical") : 0);
    }
    float MoveX = 0;
    float MoveZ = 0;
    void ApplyMovement()
    {
        MoveX = _input.x * speed;
        MoveZ = _input.y * speed;
        characterController.Move(new Vector3(MoveX, 0, MoveZ));
    }
    float RotateY = 0;
    void ApplyRotation()
    {
        //transform.rotation = new Vector3();
    }
    class FrameInput
    {
        public Vector2 move;
    }
}

