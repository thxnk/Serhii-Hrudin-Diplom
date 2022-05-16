using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    protected override void Collected()
    {
        LevelManager.instance.AddCoins();
        AudioManager.instance.PlaySFX(7);
        Destroy(this.gameObject);
    }
}