using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterHealthController : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public float invincibleLength;
    private float invincibleCounter;
    private Animator animator;

    private SpriteRenderer theSR;
    public static CharecterHealthController instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        theSR = GetComponent<SpriteRenderer>();
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
                currentHealth = 0;
                CharecterController.instance.canMove = false;
                animator.SetTrigger("Death");
            }
            else
            {
                invincibleCounter = invincibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
            }
        }
    }
}
