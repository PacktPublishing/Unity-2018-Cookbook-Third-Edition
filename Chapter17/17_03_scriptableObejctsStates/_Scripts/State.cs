using UnityEngine;

[CreateAssetMenu(menuName = "MyGame/State")]
public class State : ScriptableObject
{
    public Transition[] transitions;

    public void UpdateState(StateController controller)
    {
        CheckTransitions(controller);
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
        }
    }
}


