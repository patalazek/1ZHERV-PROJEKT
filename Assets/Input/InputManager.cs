using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public GameObject Menu_overlay;
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
    private InputAction menuAction;
    public static bool Menu;
    public static bool GameOver = false;
    GameObject menuObject;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        fireAction = playerInput.actions["Fire"];
        reloadAction = playerInput.actions["Reload"];
        flashlightAction = playerInput.actions["Flashlight_toggle"];
        throwAction = playerInput.actions["Throw"];
        menuAction = playerInput.actions["Menu"];
    }

    private void Update()
    {
        Movement = moveAction.ReadValue<Vector2>();
        Fire = fireAction.triggered;
        Reload = reloadAction.triggered;
        Flashlight = flashlightAction.triggered;
        Throw = throwAction.triggered;
        Menu = menuAction.triggered;
        if (Menu)
        {
            if (Menu_overlay.activeSelf)
            {
                Menu_overlay.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Menu_overlay.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (GameOver)
        {
            Menu_overlay.SetActive(true);
            Time.timeScale = 0;
            GameOver = false;
        }
    }
}
