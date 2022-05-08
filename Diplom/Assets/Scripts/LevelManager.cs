using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;
    public Transform respawnPoint;


    private void Awake()
    {
        instance = this;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(waitToRespawn - (1f / 3f));

        LevelChanger.instance.Fade();

        yield return new WaitForSeconds((1f / 3f) + 3f);



        CharecterController.instance.transform.position = respawnPoint.position;

        CharecterHealthController.instance.currentHealth = CharecterHealthController.instance.maxHealth;
        CharecterController.instance.canMove = true;
        CharecterHealthController.instance.animator.SetTrigger("Alive");
        LevelChanger.instance.UnFade();
        CharecterHealthController.instance.healthBar.SetHealth(CharecterHealthController.instance.currentHealth);
    }
}
