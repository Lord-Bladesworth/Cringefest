using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;
    float speed = 0.25f;

    Vector2 _input;

    float MoveX = 0;
    float MoveZ = 0;
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
    void ReadInput()
    {
        _input = new Vector2(
           Mathf.Abs( Input.GetAxisRaw("Horizontal")) > Deadzone ? Input.GetAxis("Horizontal") : 0,
           Mathf.Abs( Input.GetAxisRaw("Vertical"))> Deadzone ? Input.GetAxis("Vertical") : 0);
    }

    private void LateUpdate()
    {
        ReadInput();
        //MoveX =Mathf.Abs( Input.GetAxis("Horizontal")) > Deadzone ?Mathf.Sign(Input.GetAxisRaw("Horizontal"))* speed : 0;
        //MoveZ =Mathf.Abs( Input.GetAxis("Vertical")) > Deadzone ? Mathf.Sign(Input.GetAxisRaw("Vertical")) * speed : 0;
        ApplyMovement();
    
    }
    void ApplyMovement()
    {
        MoveX = _input.x * speed;
        MoveZ = _input.y * speed;
        Debug.Log(_input + "" + MoveX + "" + MoveZ);
        characterController.Move(new Vector3(MoveX, 0, MoveZ));
    }
    void ApplyRotation()
    {

    }


    class FrameInput
    {
        public Vector2 move;
    }
}

