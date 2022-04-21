using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class VisitorSystem
{
    public event Action VisitorsCountChanged;
    public Visitor Visitor => _visitor;

    private const int MAX_DELAY = 5000;
    private const int MIN_DELAY = 1000;
    private readonly Vector2 _createPoint, _exitPoint;
    private readonly List<Workplace> _workplaces;
    private readonly Visitor _visitor;
    private readonly ITime _time;

    public VisitorSystem(Vector2 createPoint, Vector2 exitPoint, Visitor prefab, Transform parentContainer, List<Workplace> workplaces,
        ITime time){
        _createPoint = createPoint;
        _exitPoint = exitPoint;
        _workplaces = workplaces;
        _time = time;

        _visitor = Object.Instantiate(prefab, parentContainer);
        _visitor.gameObject.SetActive(false);
        _visitor.VisitorAwayEvent += SpawnWithDelay;
    }

    public async void SpawnWithDelay(){
        var delay = Random.Range(MIN_DELAY, MAX_DELAY);
        await Task.Delay(delay);
        if (_time.CurrentGameTime.Hours < _time.DayEnd.Hours)
            Spawn();
    }

    private void Spawn(){
        var index = Random.Range(0, _workplaces.Count);
        var workplace = _workplaces[index];

        _visitor.Initialize(workplace, _createPoint, _exitPoint);
        VisitorsCountChanged?.Invoke();
    }

    public void VisitorsClear(){
        _visitor.gameObject.SetActive(false);
    }
}
