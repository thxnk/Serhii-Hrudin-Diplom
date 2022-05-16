using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamager : MonoBehaviour
{
    public int damage = 20;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().DealDamage(damage);
        }
    }
}
