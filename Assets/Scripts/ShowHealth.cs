using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int health = 100;

    public float repeatDamagePeriod = 2f;       // How frequently the player can be damaged.
    private GameObject healthBarObject;
    private SpriteRenderer healthBar;           // Reference to the sprite renderer of the health bar.
    private float lastHitTime;                  // The time at which the player was last hit.
    private Vector3 healthScale = new Vector3(1, 1, 1);               // The local scale of the health bar initially (with full health).
    private GameObject objectTracking;
    //private Animator anim;                      // Reference to the Animator on the player
    //PlayerController tracking;
    public GameObject deathAnimObj;
	public GameObject deathSFXPlayer;
	public int deathSFXIndex;

    void Awake()
    {
        // Setting up references.

        //tracking = objectTracking.GetComponent<PlayerController>();
        objectTracking = this.gameObject;
        healthBarObject = GameObject.Instantiate(Resources.Load("Health") as GameObject);
        healthBar = healthBarObject.GetComponent<SpriteRenderer>();

        // Getting the intial scale of the healthbar (whilst the player has full health).
        healthScale = healthBar.transform.localScale;
    }




    public void Update()
    {
        if (health < 0)
        {
			GameObject tmp = Instantiate (deathSFXPlayer, this.transform.position, Quaternion.identity);
			tmp.GetComponent<PlayDeathSoundHere> ().PlayAudioByIndex (deathSFXIndex);

			if (objectTracking.tag == "Player") {
				FindObjectOfType<Pause> ().QuitToMenu (3.0f);
			}

            GameObject.Destroy(objectTracking);
            GameObject.Destroy(healthBarObject);
            GameObject dead = GameObject.Instantiate(deathAnimObj);
			dead.transform.rotation = transform.rotation;
            dead.transform.position = transform.position;
            return;
        }
        UpdateHealthBar();
        
    }

    public void Injure(int amount)
    {
        if(amount>0)
        health = health - amount;
    }


    public float Health
    {
        get
        {
            return health;
        }
    }
    public float MaxHealth
    {
        get
        {
            return maxHealth;
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

		Color tmp = healthBar.material.color;
		SpriteRenderer tmpSR = this.gameObject.GetComponent<SpriteRenderer> ();

		tmp.a = tmpSR.color.a;
		healthBar.material.color = tmp;


        // Set the scale of the health bar to be proportional to the player's health.
        healthBar.transform.localScale = new Vector3(healthScale.x * HealthPercentage, 1, 1);
    }



}
