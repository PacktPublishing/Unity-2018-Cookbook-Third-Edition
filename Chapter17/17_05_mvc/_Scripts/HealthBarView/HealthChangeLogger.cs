using UnityEngine;

public class HealthChangeLogger
{
    public HealthChangeLogger()
    {
        Player.OnHealthChange += LogNewHealth;
    }

    ~HealthChangeLogger()
    {
        Player.OnHealthChange -= LogNewHealth;
    }

    public void LogNewHealth(float health)
    {
        // 1 decimal place
        string healthAsString = health.ToString("0.0");
        Debug.Log("health = " + healthAsString);
    }
}
