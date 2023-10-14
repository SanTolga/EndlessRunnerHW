using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class PowerUpDoors : MonoBehaviour
{
    public TextMeshProUGUI _buffDisplay;
    public float _buffs;


    private void Awake()
    {
        int _randomNum = Random.Range(2, 5);
        _buffs = _randomNum;
    }

    private void Update()
    {
        _buffDisplay.text = _buffs + "X";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BreakableWalls._arrowDmg = _buffs * BreakableWalls._arrowDmg;
            Destroy(gameObject);
        }
    }
}