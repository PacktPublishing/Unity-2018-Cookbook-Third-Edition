public class GameState
{
    public enum EventType
    {
        ButtonWinGame,
        ButtonLoseGame,
        TimerFinished
    }

    protected MyGameManager gameManager;
    public GameState(MyGameManager manager)
    {
        gameManager = manager;
    }

    public virtual void OnMyStateEntered() {}
    public virtual void OnMyStateExit() {}
    public virtual void StateUpdate() {}
    public virtual void OnEventReceived(EventType eventType) {}
}