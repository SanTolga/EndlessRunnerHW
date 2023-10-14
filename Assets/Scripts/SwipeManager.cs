using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private Vector2 _fingerDownPos;
    private Vector2 _fingerUpPos;

    public bool _detectSwipeAfterRelease = false;
    public float _rotateSpeed = 20f;
    public float SWIPE_TRASHOLD = 20;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 3, Space.World);
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _fingerUpPos = touch.position;
                _fingerDownPos = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (!_detectSwipeAfterRelease)
                {
                    _fingerDownPos = touch.position;
                    DetectSwipe();
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _fingerDownPos = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (VerticalMoveValue() > SWIPE_TRASHOLD && VerticalMoveValue() > HorizontalMoveValue())
        {
            Debug.Log("vertical swipe detection");
            if (_fingerDownPos.y - _fingerUpPos.y >0)
            {
                OnSwipeUp();
            }else if (_fingerDownPos.y - _fingerUpPos.y <0 )
            {
                OnSwipeDown();
            }
        }
        else if (HorizontalMoveValue() > SWIPE_TRASHOLD && HorizontalMoveValue() > VerticalMoveValue())
        {
            Debug.Log("horizontal move detection");
            if (_fingerDownPos.x - _fingerUpPos.x >0 )
            {
                OnSwipeRight();
            }else if (_fingerDownPos.x - _fingerUpPos.x <0)
            {
                OnSwipeLeft();
            }

            _fingerUpPos = _fingerDownPos;
        }
        else
        {
            Debug.Log("no swipe detected");
        }
    }

    float VerticalMoveValue()
    {
        return Math.Abs(_fingerDownPos.y - _fingerUpPos.y);
    }

    float HorizontalMoveValue()
    {
        return Math.Abs(_fingerDownPos.x - _fingerUpPos.x);
    }

    void OnSwipeUp()
    {
    }

    void OnSwipeDown()
    {
    }

    void OnSwipeRight()
    {
        if (transform.position.x < 3f)
        {
            gameObject.transform.position = new Vector3(transform.position.x + 100 * Time.deltaTime,
                transform.position.y, transform.position.z);
        }
    }

    void OnSwipeLeft()
    {
        if (transform.position.x > -3f)
        {
            gameObject.transform.position = new Vector3(transform.position.x - 100 * Time.deltaTime,
                transform.position.y, transform.position.z);
        }
    }
}