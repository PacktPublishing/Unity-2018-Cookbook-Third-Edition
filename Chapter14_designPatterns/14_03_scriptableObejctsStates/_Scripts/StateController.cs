using UnityEngine;

public class StateController : MonoBehaviour
{
    public State currentState;
    [HideInInspector] public MyGameManager gameManager;

    void Awake()
    {
        gameManager = GetComponent<MyGameManager>();
    }

    private void Update()
    {
        currentState.UpdateState(this);
        gameManager.DisplayCurrentState(currentState);
    }

    public void TransitionToState(State nextState)
    {
        currentState = nextState;
    }
}