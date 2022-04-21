using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Enums;
using UnityEngine.SceneManagement;

public class SwiperSceneHandler : MonoBehaviour
{
    private const int TOP = 1;
    private const int BOTTOM = 0;
    private const int CARD_CHOOSE_DELAY = 1500;

    [SerializeField] private InputReaderSwipe inputReader;
    [SerializeField] private Text noLabel, yesLabel;
    [SerializeField] private Card[] cards;
    private SwipeDetector _swipeDetector;
    private Queue<Card> _deck;
    private Card _firstCard, _secondCard;

    private void Awake(){
        _swipeDetector = new SwipeDetector(inputReader);
        _deck = new Queue<Card>();

        foreach (var card in cards) _deck.Enqueue(card);
        WaitToChoose();
    }

    private void OnEnable(){
        _swipeDetector.SwipeLeftEvent += ChooseNo;
        _swipeDetector.SwipeRightEvent += ChooseYes;
    }

    private void OnDisable(){
        _swipeDetector.SwipeLeftEvent -= ChooseNo;
        _swipeDetector.SwipeRightEvent -= ChooseYes;
    }

    private void WaitToChoose(){
        _firstCard = _deck.Dequeue();
        _firstCard.SetOrderInLayer(TOP);

        _secondCard = _deck.Peek();
        _secondCard.Visible(true);
        _secondCard.SetOrderInLayer(BOTTOM);

        noLabel.enabled = false;
        yesLabel.enabled = false;
    }

    private async void ChooseYes(){
        _swipeDetector.SetActive(false);
        _firstCard.CardTurn(TurnSide.Right);
        yesLabel.enabled = true;

        await Task.Delay(CARD_CHOOSE_DELAY);
        _swipeDetector.SetActive(true);
        DataHolder.OnChosenNumber(_firstCard.CardValue);
        SceneManager.UnloadSceneAsync("SwipeScene");
    }

    private async void ChooseNo(){
        _swipeDetector.SetActive(false);
        _firstCard.CardTurn(TurnSide.Left);
        noLabel.enabled = true;

        await Task.Delay(CARD_CHOOSE_DELAY);
        _swipeDetector.SetActive(true);
        BackToDeck();
        WaitToChoose();
    }

    private void BackToDeck(){
        _firstCard.Visible(false);
        _firstCard.CardTurn(TurnSide.None);
        _firstCard.SetOrderInLayer(0);
        _deck.Enqueue(_firstCard);
    }
}