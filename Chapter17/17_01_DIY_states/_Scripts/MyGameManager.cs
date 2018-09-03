using UnityEngine;
using System;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public Text textStateMessages;
    public Button buttonWinGame;
    public Button buttonLoseGame;

    private GameStates.GameStateType currentState;
    private float timeGamePlayingStarted;
    private float timeToPressAButton = 5;

    void Start()
    {
        currentState = GameStates.GameStateType.GamePlaying;
    }

    public void NewGameState(GameStates.GameStateType newState)
    {
        // (1) state EXIT actions
        OnMyStateExit(currentState);

        // (2) change current state
        currentState = newState;

        // (3) state ENTER actions
        OnMyStateEnter(currentState);

        PostMessageDivider();
    }

    public void PostMessageDivider()
    {
        string newLine = "\n";
        string divider = "--------------------------------";
        textStateMessages.text += newLine + divider;
    }

    public void PostMessage(string message)
    {
        string newLine = "\n";
        string timeTo2DecimalPlaces =
String.Format("{0:0.00}", Time.time);
        textStateMessages.text += newLine +
timeTo2DecimalPlaces + " :: " + message;
    }

    private void DestroyButtons()
    {
        Destroy(buttonWinGame.gameObject);
        Destroy(buttonLoseGame.gameObject);
    }

    //--------- OnMyStateEnter[ S ] - state specific actions
    private void OnMyStateEnter(GameStates.GameStateType state)
    {
        string enterMessage = "ENTER state: " +
state.ToString();
        PostMessage(enterMessage);

        switch (state)
        {
            case GameStates.GameStateType.GamePlaying:
                OnMyStateEnterGamePlaying();
                break;
            case GameStates.GameStateType.GameWon:
                // do nothing
                break;
            case GameStates.GameStateType.GameLost:
                // do nothing
                break;
        }
    }

    private void OnMyStateEnterGamePlaying()
    {
        // record time we enter state
        timeGamePlayingStarted = Time.time;
    }

    //--------- OnMyStateExit[ S ] - state specific actions
    private void OnMyStateExit(GameStates.GameStateType state)
    {
        string exitMessage = "EXIT state: " + state.ToString();
        PostMessage(exitMessage);

        switch (state)
        {
            case GameStates.GameStateType.GamePlaying:
                OnMyStateExitGamePlaying();
                break;
            case GameStates.GameStateType.GameWon:
                // do nothing
                break;
            case GameStates.GameStateType.GameLost:
                // do nothing
                break;
        }
    }

    private void OnMyStateExitGamePlaying()
    {
        // if leaving gamePlaying state then destroy the 2 buttons
        DestroyButtons();
    }

    //--------- Update[ S ] - state specific actions
    void Update()
    {
        switch (currentState)
        {
            case GameStates.GameStateType.GamePlaying:
                UpdateStateGamePlaying();
                break;
            case GameStates.GameStateType.GameWon:
                // do nothing
                break;
            case GameStates.GameStateType.GameLost:
                // do nothing
                break;
        }
    }

    private void UpdateStateGamePlaying()
    {
        float timeSinceGamePlayingStarted =
Time.time - timeGamePlayingStarted;
        if (timeSinceGamePlayingStarted > timeToPressAButton)
        {
            string message = "User waited too long - automatically going to Game LOST state";
              PostMessage(message);
            NewGameState(GameStates.GameStateType.GameLost);
        }
    }
}