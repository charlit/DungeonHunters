using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Text healthNumberText;
    //public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public bool canTakeDamage;

    private Animator anim;                                              // Reference to the Animator component.
    private AudioSource playerAudio;                                    // Reference to the AudioSource component.
    private bool isDead;                                                // Whether the player is dead.
    private bool damaged;                                               // True when the player gets damaged.



    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        // Set the initial health of the player.
        currentHealth = startingHealth;

        healthNumberText.text = currentHealth.ToString() + '/' + startingHealth.ToString();
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            //damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        if (canTakeDamage)
        {         // Set the damaged flag so the screen will flash.
            damaged = true;

            // Reduce the current health by the damage amount.
            currentHealth -= amount;

            // Set the health bar's value to the current health.
            LoadHealthBar(100, currentHealth);
            healthSlider.value = currentHealth;
            healthNumberText.text = currentHealth.ToString() + '/' + startingHealth.ToString();

            // Play the hurt sound effect.
            //playerAudio.Play();

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                currentHealth = 0;
                Death();
            }
            else if (currentHealth >= startingHealth)
            {
                currentHealth = startingHealth;
            }
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;


        // Tell the animator that the player is dead.
        //anim.SetTrigger("Die");

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        // playerAudio.clip = deathClip;
        //playerAudio.Play();  
        Debug.Log("You are dead...");      
    }

    public void LoadHealthBar(float maxHealth, float curHealth)
    {
        Image fill = GameObject.Find("PlayerHealthFill").GetComponent<Image>();

        if (curHealth > maxHealth / 2)
        {
            fill.color = new Color32((byte)MapValues(curHealth, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
        }
        else
        {
            fill.color = new Color32(255, (byte)MapValues(curHealth, 0, maxHealth / 2, 0, 255), 0, 255);
        }
    }

    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}