using System;
using UnityEngine;

public class TimeSystem : ITime
{
    public event Action MinutePassEvent;
    public event Action EndOfDayEvent;
    public event Action DayStartEvent;
    public TimeSpan CurrentGameTime{ get; private set; }
    public TimeSpan DayEnd => _dayEnd;
    
    private readonly TimeSpan _minute = new TimeSpan(0, 1, 0);
    private readonly TimeSpan _dayStart, _dayEnd;
    private readonly float _minuteToRealTime;
    private float _timer;
    private bool _isActive;

    public TimeSystem(Vector2Int gameDayRealTime, Vector2Int dayStart, Vector2Int dayEnd){

        _dayStart = new TimeSpan(dayStart.x, dayStart.y, 0);
        _dayEnd = new TimeSpan(dayEnd.x, dayEnd.y, 0);

        var totalSecondsToGameDay = (new TimeSpan(gameDayRealTime.x, gameDayRealTime.y, 0)).TotalSeconds;
        var totalMinutesToGameTime = (_dayEnd - _dayStart).TotalMinutes;
        _minuteToRealTime = (float)(totalSecondsToGameDay/totalMinutesToGameTime);
    }

    public void Tick(){
        if (!_isActive) return;

        _timer -= Time.deltaTime;
        
        if (_timer > 0) return;
        _timer = _minuteToRealTime;
        
        CurrentGameTime = CurrentGameTime.Add(_minute);
        MinutePassEvent?.Invoke();
        EndOfDayNotify();
    }

  private  void EndOfDayNotify(){
       if (CurrentGameTime >= _dayEnd)
            EndOfDayEvent?.Invoke();
    }

    public void Start(){
        CurrentGameTime = _dayStart;
        _timer = _minuteToRealTime;
        _isActive = true;
        DayStartEvent?.Invoke();
    }

    public void Stop() => _isActive = false;
}