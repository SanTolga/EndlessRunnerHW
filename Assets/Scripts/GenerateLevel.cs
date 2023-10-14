using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] _selection;
    public int _zpos = 100;
    public bool _createingSelection;
    public int _secNum;
    public int _ypos = 7; 

    private void Update()
    {
        if (_createingSelection == false)
        {
            _createingSelection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        _secNum = Random.Range(0, 4);
        Instantiate(_selection[_secNum] , new Vector3 (0,_ypos,_zpos), Quaternion.identity);
        _zpos += 100;
        yield return new WaitForSeconds(15);
        _createingSelection = false;
    }
}
