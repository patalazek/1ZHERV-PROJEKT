using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public VisualElement ui;
    public UnityEngine.UIElements.Button continueButton;
    public UnityEngine.UIElements.Button restartButton;
    public UnityEngine.UIElements.Button quitButton;
    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void OnEnable(){
        ui = GetComponent<UIDocument>().rootVisualElement;
        continueButton = ui.Q<UnityEngine.UIElements.Button>("ContinueButton");
        continueButton.clicked += OnContinueClicked;
        restartButton = ui.Q<UnityEngine.UIElements.Button>("RestartButton");
        restartButton.clicked += OnRestartClicked;
        quitButton = ui.Q<UnityEngine.UIElements.Button>("QuitButton");
        quitButton.clicked += OnQuitClicked;
        Debug.Log("Menu Enabled");
    }

    private void OnContinueClicked()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Debug.Log("Continue Clicked");
    }

    private void OnRestartClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnQuitClicked()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
