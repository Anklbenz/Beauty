using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Visitor : AvatarBase
{
    public event Action VisitorAwayEvent;
    public event Action<bool> ReputationEvent, MoneyChangeEvent;

    [SerializeField] private Animator popupAnimator;
    [SerializeField] private Text popupText;
    private Popup _popup;
    private Vector2 _enterPoint, _exitPoint;
    private int _serviceNumber;

    private void OnEnable(){
        DataHolder.ChosenNumberEvent += CompareNumbers;
        _popup = new Popup(popupText, popupAnimator);
    }

    private void OnDisable()=> DataHolder.ChosenNumberEvent += CompareNumbers;
    
    public void Initialize(Workplace wishWorkplace, Vector2 enterPoint, Vector2 exitPoint){
        _serviceNumber = Random.Range(1, 4);
        _enterPoint = enterPoint;
        _exitPoint = exitPoint;

        transform.position = _enterPoint;
        gameObject.SetActive(true);

        WalkToTable(wishWorkplace);
        ShowPopup(_serviceNumber.ToString());
    }

    private void ShowPopup(string txt){
        _popup.SetNumber(txt);
        _popup.Show(true);
    }

    private void CompareNumbers(int number){
        if (number == _serviceNumber){
            ReputationEvent?.Invoke(true);
            MoneyChangeEvent?.Invoke(true);
            ShowPopup("Ok!");
        }
        else{
            ReputationEvent?.Invoke(false);
            MoneyChangeEvent?.Invoke(false);
            ShowPopup("@#!");
        }

        GoAway();
    }

    public void Disable(){
        gameObject.SetActive(false);
        VisitorAwayEvent?.Invoke();
    }

    private void WalkToTable(Workplace wishWorkplace) => Motor.SetDestination(wishWorkplace.VisitorPosition);
    private void GoAway() => Motor.SetDestination(_exitPoint);
}