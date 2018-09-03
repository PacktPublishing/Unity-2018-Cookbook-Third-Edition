using UnityEngine;

public class StateGameLost : GameState
{
    public StateGameLost(MyGameManager manager) : base(manager) { }

    public override void OnMyStateEntered()
    {
        string stateEnteredMessage = "ENTER state: StateGameLost";
        gameManager.DisplayStateEnteredMessage(stateEnteredMessage);
        Debug.Log(stateEnteredMessage);
    }
}