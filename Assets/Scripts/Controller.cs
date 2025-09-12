using System;
using UnityEngine;

public abstract class Controller : MonoBehaviour 
{
    [HideInInspector]
    public Vector2 _input;
    public Action<Vector2> OnMovement;
    
    public void ControllerMove()
    {
        if (OnMovement != null) OnMovement(_input);
    }
    
}
