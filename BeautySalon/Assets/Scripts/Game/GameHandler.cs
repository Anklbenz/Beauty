
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using  UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [Header("TimeSystem")]
    [SerializeField] private Vector2Int dayStart;
    [SerializeField] private Vector2Int dayEnd, lengthGameDayRealTime;
    private TimeSystem _timeSystem;

    [Header("UI")]
    [SerializeField] private Text timeLabel;
    [SerializeField] private Text reputationLabel, moneyLabel;
    [Space]
    [SerializeField] private Text resMoneyLbl;
    [SerializeField] private Text resMoneyTotalLbl, resCountLbl, resReputationLbl, resAverageLbl;
    private UIDrawer _uiDrawer;
    private UIResultPanelDrawer _uiResultPanelDrawer;

    [Header("Visitors")]
    [SerializeField] private Visitor prefabVisitor;
    [SerializeField] private Transform parentContainer, createPoint, exitPoint;
    private VisitorSystem _visitorSystem;

    [Header("Character")]
    [SerializeField] private Character prefabCharacter;
    [SerializeField] private Tilemap walkingArea;
    [SerializeField] private Transform playerCreatePoint, playerParent;
    private CharacterSystem _characterSystem;
   
    [Header("StatSystem")]
    [SerializeField] private Vector2 priceInterval;
    [SerializeField] private Vector2Int reputationInterval;
    [SerializeField] private GameObject uiResultPanel;
    private StatSystem _statSystem;
    
    [Header("Object System")]
    [SerializeField] private List<Workplace> listOfObj;
   
    [SerializeField] private string swipeSceneName;
    private readonly SceneLoader _sceneLoader = new SceneLoader();

    private void Awake(){
        _timeSystem = new TimeSystem(lengthGameDayRealTime, dayStart, dayEnd);
        _visitorSystem = new VisitorSystem(createPoint.position, exitPoint.position, prefabVisitor, parentContainer, listOfObj, _timeSystem);
        _statSystem = new StatSystem(_visitorSystem, _timeSystem, priceInterval, reputationInterval);
        _uiDrawer = new UIDrawer(_timeSystem, _statSystem, timeLabel, reputationLabel, moneyLabel);
        _characterSystem = new CharacterSystem(prefabCharacter, playerCreatePoint.position, playerParent, walkingArea);
        _uiResultPanelDrawer = new UIResultPanelDrawer(_statSystem, resMoneyLbl, resMoneyTotalLbl, resCountLbl, resReputationLbl, resAverageLbl);
        
        _timeSystem.EndOfDayEvent += LoadResultScreen;
        
        StartNewDay();
    }
    public void StartNewDay(){
        _timeSystem.Start();
        _characterSystem.Spawn(); 
        _visitorSystem.SpawnWithDelay();
        uiResultPanel.SetActive(false);
        }

    private void FixedUpdate(){
        _timeSystem.Tick();
    }

    public void LoadSwipeScene(){
        _sceneLoader.LoadScene(swipeSceneName);
    }

    private void LoadResultScreen(){
        _timeSystem.Stop();
        _visitorSystem.VisitorsClear();
        
        _uiResultPanelDrawer.UpdateStatsLabels();
        uiResultPanel.SetActive(true);
    }
}