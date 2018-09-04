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
        string message = "Win Game BUTTON clicked";
        myGameManager.PostMessage(message);
        myGameManager.NewGameState(GameStates.GameStateType.GameWon);
    }

    public void BUTTON_CLICK_ACTION_LOSE_GAME()
    {
        string message = "Lose Game BUTTON clicked";
        myGameManager.PostMessage(message);
        myGameManager.NewGameState(GameStates.GameStateType.GameLost);
    }

}