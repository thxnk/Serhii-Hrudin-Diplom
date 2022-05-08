using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterHealthController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public int maxHealth;
    public int currentHealth;
    public float invincibleLength;
    private float invincibleCounter;
    public Animator animator;

    private SpriteRenderer theSR;
    public static CharecterHealthController instance;
    public HealthBar healthBar;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        theRB = GetComponent<Rigidbody2D>();
        theSR = GetComponent<SpriteRenderer>();
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if (invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }
    public void DealDamage(int damage)
    {
        if (invincibleCounter <= 0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                healthBar.SetHealth(currentHealth);
                currentHealth = 0;
                CharecterController.instance.canMove = false;
                theRB.velocity = new Vector2(0, 0);
                AudioManager.instance.PlaySFX(4);
                animator.SetTrigger("Death");
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                healthBar.SetHealth(currentHealth);
                AudioManager.instance.PlaySFX(3);
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
            }
        }
    }
}
