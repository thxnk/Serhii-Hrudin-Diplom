using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit2D
{
    public class HealthPickup : MonoBehaviour
    {
        public int healthAmount = 25;
        public UnityEvent OnGivingHealth;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                if (CharecterHealthController.instance.currentHealth < CharecterHealthController.instance.maxHealth)
                {
                    CharecterHealthController.instance.currentHealth += healthAmount;
                    HealthBar.instance.UpdateBar();
                    OnGivingHealth.Invoke();
                }
            }
        }
    }
}