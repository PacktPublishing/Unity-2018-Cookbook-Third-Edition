using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/Decisions/GameWonDecision")]
public class GameWonDecision : Decision
{

    public override bool Decide(StateController controller)
    {
        return GameWonActionDetected(controller.gameManager);
    }

    private bool GameWonActionDetected(MyGameManager gameManager)
    {
        return gameManager.HasCollectedAllStars();
    }
}
