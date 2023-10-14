using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    public bool boolDead = false;

    private void FixedUpdate()
    {
        if (boolDead == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            if (boolDead == false)
            {
                boolDead = true;
                BreakableWalls._arrowDmg = 5;
                CoinFlip._coinCount = 0; 
            }
        }
    }
}
