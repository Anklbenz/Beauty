using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class StatSystem : IDisposable
{
    public event Action MoneyChangedEvent;
    public event Action ReputationChangedEvent;

    public float Money => _money;
    public float MoneyTotal => _moneyTotal;
    public float Reputation => _reputation;

    public float AvgReputation => _avgReputation / (_visitorCountPerDay + 1);
    public int VisitorCount => _visitorCountPerDay;

    private float _reputation, _money, _moneyTotal, _avgReputation;
    private int _visitorCountPerDay;
    private readonly VisitorSystem _visitorSystem;
    private readonly Vector2 _priceInterval, _reputationInterval;
    private readonly ITime _timeSystem;

    public StatSystem(VisitorSystem visitors, ITime timeSystem, Vector2 priceInterval, Vector2 reputationInterval){
        _visitorSystem = visitors;
        _timeSystem = timeSystem;
        _priceInterval = priceInterval;
        _reputationInterval = reputationInterval;
        _reputation = 100;
        _visitorSystem.Visitor.MoneyChangeEvent += MoneyChanged;
        _visitorSystem.Visitor.ReputationEvent += ReputationChanged;
        _visitorSystem.VisitorsCountChanged += VisitorsCounter;
        _timeSystem.DayStartEvent +=StartNewDay;
    }

    private void MoneyChanged(bool profit){
        var count = Random.Range(_priceInterval.x, _priceInterval.y);

        if (profit){
            _money += count;
            _moneyTotal += count;
        }
        else{
            _money -= count;
            _moneyTotal -= count;
        }

        MoneyChangedEvent?.Invoke();
    }

    private void ReputationChanged(bool profit){
        var count = Random.Range(_reputationInterval.x, _reputationInterval.y);
        if (profit)
            _reputation += count;
        else
            _reputation -= count;

        if (_reputation > 100) _reputation = 100;
        if (_reputation < 0) _reputation = 0;

        _avgReputation += count; 
        ReputationChangedEvent?.Invoke();
    }

    private void VisitorsCounter() => _visitorCountPerDay++;

    private void StartNewDay(){
        _visitorCountPerDay = 0;
        _money = 0;
    }

    public void Dispose(){
        _visitorSystem.Visitor.MoneyChangeEvent -= MoneyChanged;
        _visitorSystem.Visitor.ReputationEvent -= ReputationChanged;
        _visitorSystem.VisitorsCountChanged -= VisitorsCounter;
        _timeSystem.DayStartEvent -= StartNewDay;
    }
}
