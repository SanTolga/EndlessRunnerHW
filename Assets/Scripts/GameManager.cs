using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI _coinCount;
    public TextMeshProUGUI _arrowDmg; 
    
    void Update()
    {
        _coinCount.text = "Coins: " + CoinFlip._coinCount;
        _arrowDmg.text = "Your Damage: " + BreakableWalls._arrowDmg;
    }

   
}
