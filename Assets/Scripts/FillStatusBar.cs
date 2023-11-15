using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public DewyHealthSystem dewyHealth;
    public Image fillImage;
    private Slider slider;
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillvalue = dewyHealth.currentHealth / dewyHealth.maxHealth;
        slider.value = fillvalue;
    }
}
