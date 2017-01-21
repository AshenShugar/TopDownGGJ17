using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHealth : MonoBehaviour
{



    public float repeatDamagePeriod = 2f;       // How frequently the player can be damaged.
    public GameObject healthBarObject;
    private SpriteRenderer healthBar;           // Reference to the sprite renderer of the health bar.
    private float lastHitTime;                  // The time at which the player was last hit.
    private Vector3 healthScale = new Vector3(1, 1, 1);               // The local scale of the health bar initially (with full health).
    public GameObject objectTracking;
    //private Animator anim;                      // Reference to the Animator on the player
    PlayerController playerController;

    void Awake()
    {
        // Setting up references.

        playerController = objectTracking.GetComponent<PlayerController>();
        healthBarObject = this.gameObject;
        healthBar = healthBarObject.GetComponent<SpriteRenderer>();

        // Getting the intial scale of the healthbar (whilst the player has full health).
        healthScale = healthBar.transform.localScale;
    }




    public void Update()
    {
        UpdateHealthBar();

    }

    
    public float Health
    {
        get
        {
            return playerController.health;
        }
    }
    public float MaxHealth
    {
        get
        {
            return playerController.maxHealth;
        }
    }

    public float HealthPercentage
    {
        get {
            return Health / MaxHealth;
        }
    }


    public void UpdateHealthBar()
    {

        healthBarObject.transform.position = new Vector3(objectTracking.transform.position.x - 0.04f, objectTracking.transform.position.y + 0.84f, 0);

        // Set the health bar's colour to proportion of the way between green and red based on the player's health.
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - HealthPercentage );

        // Set the scale of the health bar to be proportional to the player's health.
        healthBar.transform.localScale = new Vector3(healthScale.x * HealthPercentage, 1, 1);
    }


}
