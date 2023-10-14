using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BreakableWalls : MonoBehaviour
{
    static public float _arrowDmg = 5;
    public float _wallHp;
    public TextMeshProUGUI _wallHpDisplay;

    private void Awake()
    {
        int _randomNum1 = Random.Range(30, 150);
        _wallHp = _randomNum1; 
    }

    private void Update()

    {
        _wallHpDisplay.text = _wallHp.ToString(CultureInfo.InvariantCulture);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            if (_wallHp > _arrowDmg)
            {
                _wallHp -= _arrowDmg;
                other.gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
                other.gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
           _arrowDmg = 5; 
           CoinFlip._coinCount = 0; 
        }
    }
}