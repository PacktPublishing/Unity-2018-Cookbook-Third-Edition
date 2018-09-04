using UnityEngine;

public class StateGamePlaying : GameState
{
    public StateGamePlaying(MyGameManager manager) : base(manager) { }

    public override void OnMyStateEntered()
    {
        string stateEnteredMessage = "ENTER state: StateGamePlaying";
        gameManager.DisplayStateEnteredMessage(stateEnteredMessage);
        Debug.Log(stateEnteredMessage);
    }

    public override void OnEventReceived(EventType eventType)
    {
        switch(eventType){
            case (EventType.ButtonWinGame):
                gameManager.NewGameState(gameManager.stateGameWon);
                break;
            case (EventType.ButtonLoseGame):
            case (EventType.TimerFinished):
                gameManager.NewGameState(gameManager.stateGameLost);
                break;                   
        }
    }
}