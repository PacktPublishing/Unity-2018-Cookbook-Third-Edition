using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Decisions/GameLostDecision")]
public class GameLostDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        return GameLostActionDetected(controller.gameManager);
    }

    private bool GameLostActionDetected(MyGameManager gameManager)
    {
        return gameManager.GetTimeRemaining() <= 0;
    }
}
