using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class InputReaderWalk : ScriptableObject
{
    public event Action<Vector2> MoveEvent;
    public event Action<Workplace> WorkplaceSelectedEvent;

    private InputReceiver _inputReceiver;
    private Camera _camera;

    private void OnEnable(){
        _camera = Camera.main;
        _inputReceiver = new InputReceiver();
        _inputReceiver.Enable();
        _inputReceiver.Touch.DoubleTap.performed += _ => OnDoubleTap();
    }
    private void OnDisable() => _inputReceiver.Disable();

    private void OnDoubleTap(){
        var touchPoint = _inputReceiver.Touch.PrimaryPosition.ReadValue<Vector2>();
        touchPoint = _camera.ScreenToWorldPoint(touchPoint);

        var workplace = TouchIsWorkplace(touchPoint);

        if (workplace)
            WorkplaceSelectedEvent?.Invoke(workplace);
        else
            MoveEvent?.Invoke(touchPoint);
    }

    private Workplace TouchIsWorkplace(Vector2 point){
        var hit = Physics2D.Raycast(point, Vector2.zero);

        return hit ? hit.collider.GetComponent<Workplace>() : null;
    }
}
