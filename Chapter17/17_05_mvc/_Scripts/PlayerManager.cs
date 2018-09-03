using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerController playerController;
    private HealthChangeLogger healthChangeLogger;

    void Start()
    {
        playerController = new PlayerController();
        healthChangeLogger = new HealthChangeLogger();
    }

    void Update()
    {
        if (Input.GetKeyDown("up"))
            playerController.AddToHealth();

        if (Input.GetKeyDown("down"))
            playerController.ReduceHealth();
    }
}
