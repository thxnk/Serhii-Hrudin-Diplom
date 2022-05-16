using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    public Text txtCoins;
    public static CoinsUI instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public void UpdateUI(int coins)
    {
        txtCoins.text = coins + "/2";
    }
}
