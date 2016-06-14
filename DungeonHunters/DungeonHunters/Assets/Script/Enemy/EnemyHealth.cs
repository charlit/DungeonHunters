using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
    
    public AudioClip deathClip;                 // The sound to play when the enemy dies.
    public Slider ennemyHealthSlider;
    public Text ennemyDamageText;
    public bool canTakeDamage;

    private Animator anim;                              // Reference to the animator.
    private AudioSource enemyAudio;                     // Reference to the audio source.
    private ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    private CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    private bool isDead;                                // Whether the enemy is dead.
    private float waitTime = .1f;                       // Attendre xf avant affichage de la prochaine valeur de dommage


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        //ennemyHealthSlider = GetComponent<Slider>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update()
    {
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

        // Play the hurt sound effect.
        //enemyAudio.Play();

        if (canTakeDamage)
        {
            // Reduce the current health by the amount of damage sustained.
            currentHealth -= amount;

            ennemyHealthSlider.value = currentHealth;

            ennemyDamageText.text = (-1 * amount).ToString();
            StartCoroutine(Wait(waitTime));

            // Set the position of the particle system to where the hit was sustained.
            // hitParticles.transform.position = hitPoint;

            // And play the particles.
            // hitParticles.Play();
        }
        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }


    void Death()
    {
        // The enemy is dead.
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        //capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
       // anim.SetTrigger("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
        Destroy(gameObject.transform.parent.gameObject);
    }

    IEnumerator Wait(float amout)
    {
        yield return new WaitForSeconds(amout);
        ennemyDamageText.text = "";
    }
}