using UnityEngine;

public class StateGameWon : GameState
{
    public StateGameWon(MyGameManager manager) : base(manager) { }

    public override void OnMyStateEntered()
    {
        string stateEnteredMessage = "ENTER state: StateGameWon";
        gameManager.DisplayStateEnteredMessage(stateEnteredMessage);
        Debug.Log(stateEnteredMessage);
    }
}