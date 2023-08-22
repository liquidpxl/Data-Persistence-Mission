using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

using System.IO;

public class MenuUIManager : MonoBehaviour
{
    public InputField playerNameInputField;
    public static MenuUIManager Instance;

    // Store the player name as a member variable
    public string playerName;

    public Text menuBestScoreText; // Reference to the menu's best score text UI element


    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // add code here to get the best score on load
        LoadBestScoreData();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SetPlayerName()
    {
        // Get the player name from the input field
        playerName = playerNameInputField.text;
    }

    private void LoadBestScoreData()
    {
        int bestScore = BestScoreManager.Instance.bestScoreData.bestScore;
        menuBestScoreText.text = $"Best Score: {BestScoreManager.Instance.bestScoreData.playerName} : {bestScore}";
    }
}
