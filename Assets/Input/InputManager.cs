using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction fireAction;
    public static bool Fire;

    private void Awake(){
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        fireAction = playerInput.actions["Fire"];
    }
    
    private void Update(){
        Movement = moveAction.ReadValue<Vector2>();
        Fire = fireAction.triggered;
    }
}
