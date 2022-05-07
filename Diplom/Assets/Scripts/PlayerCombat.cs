using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    bool canSecondAttack = true;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CharecterController.instance.canMove)
        {
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    canSecondAttack = true;
                    Attack(false);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
            else if (canSecondAttack)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Attack(true);
                    canSecondAttack = false;
                }
            }
        }
    }
    void Attack(bool second)
    {
        if (!second)
        {
            animator.SetTrigger("Attack");
        }
        else animator.SetTrigger("Attack2");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
}
