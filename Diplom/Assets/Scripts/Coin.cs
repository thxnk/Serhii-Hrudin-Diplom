using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    protected override void Collected()
    {
        LevelManager.instance.AddCoins();
        Destroy(this.gameObject);
    }
}