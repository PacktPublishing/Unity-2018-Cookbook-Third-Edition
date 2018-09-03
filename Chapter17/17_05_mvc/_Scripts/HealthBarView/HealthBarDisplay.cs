using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour 
{
    private Image healthMeterFiller;

	private void Start()
	{
        healthMeterFiller = GetComponent<Image>();
	}

	private void OnEnable()
    {
        Player.OnHealthChange += UpdateHealthBar;
    }

    private void OnDisable()
    {
        Player.OnHealthChange -= UpdateHealthBar;
    }

    public void UpdateHealthBar(float health)
    {
        healthMeterFiller.fillAmount = health;
    }
}
