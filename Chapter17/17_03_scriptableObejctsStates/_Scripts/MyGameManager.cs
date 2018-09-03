using UnityEngine;
using UnityEngine.UI;


public class MyGameManager : MonoBehaviour 
{
    public Text textCurrentState;
    public Text textStarsCollected;
    public Text textSecondsLeft;

    public float secondsLeft = 10;
    public int totalStarsToBeCollected = 2;
    private int starsColleted = 0;

	void Update()
	{
        secondsLeft -= Time.deltaTime;
        UpdateDisplays();
	}

	public void DisplayCurrentState(State currentState)
    {
        textCurrentState.text = currentState.name;
    }

    public bool HasCollectedAllStars()
    {
        return (starsColleted == totalStarsToBeCollected);
    }

    public float GetTimeRemaining()
    {
        return secondsLeft;
    }

    public void BUTTON_ACTION_PickupOneStar()
    {
        starsColleted++;
    }

    private void UpdateDisplays()
    {
        textStarsCollected.text = "stars = " + starsColleted;
        textSecondsLeft.text = "time left = " + secondsLeft;
    }

}
