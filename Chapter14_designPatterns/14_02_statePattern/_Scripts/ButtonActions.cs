using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    private MyGameManager myGameManager;

	private void Start()
	{
        myGameManager = GetComponent<MyGameManager>();
	}

	public void BUTTON_CLICK_ACTION_WIN_GAME()
    {
        myGameManager.PublishEventToCurrentState(GameState.EventType.ButtonWinGame);
    }

    public void BUTTON_CLICK_ACTION_LOSE_GAME()
    {
        myGameManager.PublishEventToCurrentState(GameState.EventType.ButtonLoseGame);
    }
}