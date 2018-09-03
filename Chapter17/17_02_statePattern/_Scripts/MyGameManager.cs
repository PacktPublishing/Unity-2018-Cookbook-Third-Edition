using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public Text textGameStateName;
    public Button buttonWinGame;
    public Button buttonLoseGame;

    [HideInInspector]
    public StateGamePlaying stateGamePlaying;

    [HideInInspector]
    public StateGameWon stateGameWon;

    [HideInInspector]
    public StateGameLost stateGameLost;

    private GameState currentState;

    private void Awake()
    {
        stateGamePlaying = new StateGamePlaying(this);
        stateGameWon = new StateGameWon(this);
        stateGameLost = new StateGameLost(this);
    }

    private void Start()
    {
        NewGameState(stateGamePlaying);
    }

    private void Update()
    {
        if (currentState != null)
            currentState.StateUpdate();
    }

    public void NewGameState(GameState newState)
    {
        if (null != currentState)
            currentState.OnMyStateExit();

        currentState = newState;
        currentState.OnMyStateEntered();
    }

    public void DisplayStateEnteredMessage(string stateEnteredMessage)
    {
        textGameStateName.text = stateEnteredMessage;
    }

    public void PublishEventToCurrentState(GameState.EventType eventType)
    {
        currentState.OnEventReceived(eventType);
        DestroyButtons();
    }

    private void DestroyButtons()
    {
        Destroy(buttonWinGame.gameObject);
        Destroy(buttonLoseGame.gameObject);
    }
}