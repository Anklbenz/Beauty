using System;
using UnityEngine;

public class SwipeDetector : IDisposable
{
    public event Action SwipeLeftEvent;
    public event Action SwipeRightEvent;
    
    private const float MIN_DISTANCE = 0.2f;
    private const float DIR_THRESHOLD = 0.9f;
    private const float MAX_TIME = 1f;

    private readonly InputReaderSwipe _inputReader;
    private Vector2 _startPosition, _endPosition;
    private float _startTime, _endTime;
    private bool _swipeIsActive = true;

    public SwipeDetector(InputReaderSwipe inputReader){
        _inputReader = inputReader;
        _inputReader.StartTouchEvent += SwipeStart;
        _inputReader.EndTouchEvent += SwipeEnd;
    }

    public void Dispose(){
        _inputReader.StartTouchEvent -= SwipeStart;
        _inputReader.EndTouchEvent -= SwipeEnd;
    }

    private void SwipeStart(Vector2 startPoint, float startTime){
        _startPosition = startPoint;
        _startTime = startTime;
    }

    private void SwipeEnd(Vector2 endPoint, float endTime){
        _endPosition = endPoint;
        _endTime = endTime;
        DetectSwipe();
    }

    private void DetectSwipe(){
        if (Vector3.Distance(_endPosition, _startPosition) >= MIN_DISTANCE && (_endTime - _startTime) <= MAX_TIME){
            var dir = (_endPosition - _startPosition).normalized;
        
            SwipeDirection(dir);
            Debug.DrawLine(_startPosition, _endPosition, Color.red, 1f);
        }
    }

    private void SwipeDirection(Vector2 direction){
        if(!_swipeIsActive) return;
        
        if (Vector2.Dot(Vector2.left, direction) > DIR_THRESHOLD)
            SwipeLeftEvent?.Invoke();

        if (Vector2.Dot(Vector2.right, direction) > DIR_THRESHOLD) 
            SwipeRightEvent?.Invoke();
    }

    public void SetActive(bool state){
        _swipeIsActive = state;
    }
}