using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private int coins = 0;
    public float waitToRespawn;
    public Transform respawnPoint;


    private void Awake()
    {
        instance = this;
    }

    public void AddCoins()
    {
        coins++;
        CoinsUI.instance.UpdateUI(coins);
        if (coins == 2)
        {
            StartCoroutine(EndLevel());
        }
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(waitToRespawn - (1f / 3f));
        CharecterController.instance.canMove = false;
        CharecterController.instance.theRB.velocity = new Vector2(0, 0);
        LevelChanger.instance.Fade();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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

