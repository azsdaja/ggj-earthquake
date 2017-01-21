using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerBar : MonoBehaviour
{
    public int startingHealth = 100, startingPower = 100;                            // The amount of health the player starts the game with.
    public int currentHealth, currentPower;                                   // The current health the player has.
    public Slider healthSlider, powerSlider;                                 // Reference to the UI's health bar.
    public Image healthDamageImage, powerDamageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.



                               
    bool isDead;                                                // Whether the player is dead.
    bool damagedHealth, damagedPower;                                               // True when the player gets damaged.


    void Awake()
    {
        currentPower = startingPower;
        currentHealth = startingHealth;
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown("e"))
        {
            TakePower(10);
        }
        if (damagedHealth)
        {
            healthDamageImage.color = flashColour;
        }
        else if(damagedPower == false)
        {
            healthDamageImage.color = Color.Lerp(healthDamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        if (damagedPower)
        {
            powerDamageImage.color = flashColour;
        }
        else if(damagedHealth == false)
        {
            powerDamageImage.color = Color.Lerp(healthDamageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damagedHealth = false;
        damagedPower = false;
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damagedHealth = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }

    public void TakePower(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damagedPower = true;

        // Reduce the current health by the damage amount.
        currentPower -= amount;

        // Set the health bar's value to the current health.
        powerSlider.value = currentPower;

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentPower <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        
        
    }
}