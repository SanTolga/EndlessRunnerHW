using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
   public static float _leftside=-4f; 
   public static float _rightside=4f;
   public float _internalLeft; 
   public float _internalRight;

   private void Update()
   {
      _internalLeft = _leftside;
      _internalRight = _rightside; 
   }
}
