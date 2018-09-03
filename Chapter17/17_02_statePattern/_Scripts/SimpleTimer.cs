using UnityEngine;

public class SimpleTimer : MonoBehaviour 
{
    private float timeGamePlayingStarted;
    private float timeToPressAButton = 5;

    private MyGameManager myGameManager;

    private void Start()
    {
        myGameManager = GetComponent<MyGameManager>();
        timeGamePlayingStarted = Time.time;
    }

	void Update () 
    {
        float timeSinceGamePlayingStarted = Time.time - timeGamePlayingStarted;

        if (timeSinceGamePlayingStarted > timeToPressAButton)
        {
            myGameManager.PublishEventToCurrentState(GameState.EventType.TimerFinished);
        }
    }
}
