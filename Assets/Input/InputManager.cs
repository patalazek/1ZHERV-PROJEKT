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
    private InputAction reloadAction;
    public static bool Reload;
    private InputAction flashlightAction;
    public static bool Flashlight;
    private InputAction throwAction;
    public static bool Throw;

    private void Awake(){
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        fireAction = playerInput.actions["Fire"];
        reloadAction = playerInput.actions["Reload"];
        flashlightAction = playerInput.actions["Flashlight_toggle"];
        throwAction = playerInput.actions["Throw"];
    }
    
    private void Update(){
        Movement = moveAction.ReadValue<Vector2>();
        Fire = fireAction.triggered;
        Reload = reloadAction.triggered;
        Flashlight = flashlightAction.triggered;
        Throw = throwAction.triggered;
    }
}
