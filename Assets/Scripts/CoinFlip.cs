using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinFlip : MonoBehaviour
{
    public Vector3 _rotate;
    public float _speed = 5f;
    static public int _coinCount;
    
    void Update()
    {
        transform.Rotate(_rotate*Time.deltaTime*_speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _coinCount ++;
            Destroy(gameObject);
            
        }
    }
   
}
