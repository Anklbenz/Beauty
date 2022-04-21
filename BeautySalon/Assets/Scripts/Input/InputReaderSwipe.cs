using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class InputReaderSwipe : ScriptableObject
{
    public event Action<Vector2, float> StartTouchEvent, EndTouchEvent;

    private InputReceiver _inputReceiver;
    private Camera _camera;

    private void OnEnable(){
        _camera = Camera.main;
        _inputReceiver = new InputReceiver();
        _inputReceiver.Enable();
        _inputReceiver.Touch.PrimatyTouch.started += StartTouch;
        _inputReceiver.Touch.PrimatyTouch.canceled += EndTouch;
  }
    private void OnDisable() => _inputReceiver.Disable();
    private Vector3 ScreenToWord(Vector3 pos) => _camera.ScreenToWorldPoint(pos);

    private void StartTouch(InputAction.CallbackContext context){
        var touch = _inputReceiver.Touch.PrimaryPosition.ReadValue<Vector2>();
        StartTouchEvent?.Invoke(ScreenToWord(touch), (float) context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context){
        var touch = _inputReceiver.Touch.PrimaryPosition.ReadValue<Vector2>();
        EndTouchEvent?.Invoke(ScreenToWord(touch), (float) context.time);
    }
}
