using UnityEngine;

public class PlayerController
{
    private Player player;

    public PlayerController()
    {
        player = new Player();
    }

    public void AddToHealth()
    {
        player.AddHealth(0.5f);
    }

    public void ReduceHealth()
    {
        player.ReduceHealth(0.1f);
    }
}
