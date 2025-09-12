using System;
using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    public Vector2 _input;
    public Action<Vector2> OnMovement;
    
    public void ControllerMove()
    {
        if (OnMovement != null) OnMovement(_input);
    }
    
}
