using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebuffWall : MonoBehaviour
{
   
    public float _debuffs;
    public TextMeshProUGUI _Debufftext; 

    private void Awake()
    {
        int _randomNum = Random.Range(2, 5);
        _debuffs = -_randomNum;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BreakableWalls._arrowDmg = _debuffs * BreakableWalls._arrowDmg;
            Destroy(gameObject);
        }
    }
}
