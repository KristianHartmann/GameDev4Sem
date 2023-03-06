using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar; // reference to the health bar image

    private const float MAX_HEALTH = 100f; // max health of the object

    public float health = MAX_HEALTH; // current health of the object



    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>(); // get the image component of the health bar

        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / MAX_HEALTH; // update the fill amount of the health bar image
        
    }
}
