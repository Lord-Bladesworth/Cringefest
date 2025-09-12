using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{

    CharacterController characterController;
    GameEntity gameEntity;
    float speed = 0.11f;


    public Vector2 getInput { get { return _input; } }
    [SerializeField]
    float Deadzone = 0.32f;
   
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        gameEntity = GetComponent<GameEntity>();
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
        ControllerMove();
        MoveX = _input.x * gameEntity.getEntityStats.MovementSpeed;
        MoveZ = _input.y * gameEntity.getEntityStats.MovementSpeed;
        characterController.Move(new Vector3(MoveX, 0, MoveZ));
    }


    class FrameInput
    {
        public Vector2 move;
    }
}

