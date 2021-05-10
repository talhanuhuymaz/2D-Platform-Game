using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public static HealthBarScript instance;
    public Slider slider;
    private void Awake()
    {
        instance = GetComponent<HealthBarScript>();
    }
    // Update is called once per frame
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

}
