using System;
using UnityEngine;

public class Motor
{

    public event Action CameToTargetEvent;
    
    private const float MIN_DISTANCE = 0.01f;
    private readonly float _speed;
    private readonly Transform _transform;
    private Vector2 _destination;
    private bool _cameToTarget;

    public Motor(Transform transform, float speed){
        _speed = speed;
        _transform = transform;
        _cameToTarget = true;
    }

    public void Moving(){
        if (_cameToTarget) return;
    
        _cameToTarget = CheckDistanceToDestination();
        _transform.position = Vector3.MoveTowards(_transform.position, _destination, _speed * Time.fixedDeltaTime);
    }

    private bool CheckDistanceToDestination(){
        var res =Vector3.Distance(_transform.position, _destination) <= MIN_DISTANCE;
        if (res) CameToTargetEvent?.Invoke();
        
        return res;
    }

    public void SetDestination(Vector2 point){
        _destination = point;
        _cameToTarget = false;
    }
}