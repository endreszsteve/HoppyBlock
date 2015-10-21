﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Score guiManager;
    public AudioManager audio;

    private static int stateNumber;
    public static GameState currentState;                      // State Numbers
    public StateGameIntro stateGameIntro { get; set; }         // 0
    public StateGameMenu stateGameMenu { get; set; }           // 1
    public StateGamePlaying stateGamePlaying { get; set; }     // 2
    public StateGameWon stateGameWon { get; set; }             // 3
    public StateGameLost stateGameLost { get; set; }           // 4
    public StateGameLoading stateGameLoading { get; set; }     // 5
    public StateGamePaused stateGamePaused { get; set; }       // 6

    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        stateGameIntro = new StateGameIntro(this);
        stateGameMenu = new StateGameMenu(this);
        stateGamePlaying = new StateGamePlaying(this);
        stateGameWon = new StateGameWon(this);
        stateGameLost = new StateGameLost(this);
        stateGameLoading = new StateGameLoading(this);
        stateGamePaused = new StateGamePaused(this);
    }

    private void Start()
    {
        NewGameState(stateGameIntro);
        stateNumber = 0;
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.StateUpdate();
        }
    }

    public void NewGameState(GameState newState)
    {
        if (null != currentState)
        {
            currentState.OnStateExit();
        }
        currentState = newState;
        currentState.OnStateEntered();

        if (currentState == stateGameIntro)
        {
            stateNumber = 0;
        }
        else if (currentState == stateGameMenu)
        {
            stateNumber = 1;
        }
        else if (currentState == stateGamePlaying)
        {
            stateNumber = 2;
        }
        else if (currentState == stateGameWon)
        {
            stateNumber = 3;
        }
        else if (currentState == stateGameLost)
        {
            stateNumber = 4;
        }
        else if (currentState == stateGameLoading)
        {
            stateNumber = 5;
        }
        else if (currentState == stateGamePaused)
        {
            stateNumber = 6;
        }
    }
    //take out when not needed
    public static bool IsPlaying()
    {
        if (GameManager.currentState == GameManager.Instance.stateGamePlaying)
        {
            return true;
        }
        return false;
    }

    public static bool IsMenu()
    {
        if (GameManager.currentState == GameManager.Instance.stateGameMenu)
        {
            return true;
        }
        return false;
    }

    public static string WhatState()
    {
        switch (stateNumber)
        {
            case 0:
                return "intro";
            case 1:
                return "menu";
            case 2:
                return "playing";
            case 3:
                return "won";
            case 4:
                return "lost";
            case 5:
                return "loading";
            case 6:
                return "paused";
        }
        return " ";
    }

    public static void SetPlaying()
    {
        GameManager.currentState = GameManager.Instance.stateGamePlaying;
        Application.LoadLevel("Loading");
    }
}