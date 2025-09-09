using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;
    float speed = 0.11f;

    Vector2 _input;

    public Vector2 getInput { get { return _input; } }
    [SerializeField]
    float Deadzone = 0.32f;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    private void LateUpdate()
    {
        ReadInput();
        ApplyMovement();

    }
    void ReadInput()
    {
        _input = new Vector2(
           Mathf.Abs(Input.GetAxis("Horizontal")) > Deadzone ? Input.GetAxis("Horizontal") : 0,
           Mathf.Abs(Input.GetAxis("Vertical")) > Deadzone ? Input.GetAxis("Vertical") : 0);
    }
    float MoveX = 0;
    float MoveZ = 0;
    void ApplyMovement()
    {
        MoveX = _input.x * speed;
        MoveZ = _input.y * speed;
        characterController.Move(new Vector3(MoveX, 0, MoveZ));
    }

    class FrameInput
    {
        public Vector2 move;
    }
}

