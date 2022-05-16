using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Animator animator;
    public float invincibleLength;
    private float invincibleCounter;
    public GameObject enemy;
    public GameObject hitBox;
    void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
        }
    }
    public void DealDamage(int damage)
    {
        if (invincibleCounter <= 0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                hitBox.SetActive(false);
                enemy.GetComponent<EnemyBehavior>().Disable();
                currentHealth = 0;
                AudioManager.instance.PlaySFX(5);
                animator.SetTrigger("Death");
            }
            else
            {
                invincibleCounter = invincibleLength;
                animator.SetTrigger("Hit");
                AudioManager.instance.PlaySFX(3);
            }
        }
    }
}
