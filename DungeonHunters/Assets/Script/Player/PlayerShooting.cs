using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 10f;                      // The distance the gun can fire.
    public bool canAttack;
    public Image imgSkill1BG;
    public Image imgSkill2BG;
    public Image imgSkill3BG;
    public Image imgSkill4BG;

    float timer;                                    // A timer to determine when to fire.
    Ray shootRay;                                   // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
    private bool canUseSkill1;
    private bool canUseSkill2;
    private bool canUseSkill3;
    private bool canUseSkill4;

    void Awake()
    {

    }

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
        // If the Fire1 button is being press and it's time to fire...
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            // ... shoot the gun.
            Shoot();
        }

        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }

        #region Skills

        // Skill 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (canUseSkill1)
            {
                Debug.Log("Skill 1 used");
            }
            canUseSkill1 = false;
        }

        if (!canUseSkill1)
        {
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                if (imgSkill1BG.fillAmount < 1)
                    imgSkill1BG.fillAmount += 1.0f / 5.0f * Time.deltaTime;
                else
                {
                    imgSkill1BG.fillAmount = 0f;
                    canUseSkill1 = true;
                }
            }
        }

        // Skill 2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (canUseSkill2)
            {
                Debug.Log("Skill 2 used");
            }
            canUseSkill2 = false;
        }

        if (!canUseSkill2)
        {
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                if (imgSkill2BG.fillAmount < 1)
                    imgSkill2BG.fillAmount += 1.0f / 5.0f * Time.deltaTime;
                else
                {
                    imgSkill2BG.fillAmount = 0f;
                    canUseSkill2 = true;
                }
            }
        }

        // Skill 3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (canUseSkill3)
            {
                Debug.Log("Skill 3 used");
            }
            canUseSkill3 = false;
        }

        if (!canUseSkill3)
        {
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                if (imgSkill3BG.fillAmount < 1)
                    imgSkill3BG.fillAmount += 1.0f / 5.0f * Time.deltaTime;
                else
                {
                    imgSkill3BG.fillAmount = 0f;
                    canUseSkill3 = true;
                }
            }
        }

        // Skill 4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (canUseSkill4)
            {
                Debug.Log("Skill 4 used");
            }

            canUseSkill4 = false;
        }

        if (!canUseSkill4)
        {
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                if (imgSkill4BG.fillAmount < 1)
                    imgSkill4BG.fillAmount += 1.0f/3.0f * Time.deltaTime;
                else
                {
                    imgSkill4BG.fillAmount = 0f;
                    canUseSkill4 = true;
                }
            }
        }

        #endregion
    }

    public void DisableEffects()
    {
    }

    void Shoot()
    {
        // Reset the timer.
        timer = 0f;


        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if (Physics.Raycast(shootRay, out shootHit, range))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }


        }
    }
}