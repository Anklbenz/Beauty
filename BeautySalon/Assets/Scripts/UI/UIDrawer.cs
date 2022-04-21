using System;
using UnityEngine.UI;

public class UIDrawer : IDisposable
{
    private readonly ITime _time;
    private readonly Text _timeLabel;
    private readonly StatSystem _statSystem;
    private readonly Text _moneyLabel, _reputationLabel;

    public UIDrawer(ITime time, StatSystem statSystem, Text timeLabel, Text reputationLabel, Text moneyLabel){
        _reputationLabel = reputationLabel;
        _statSystem = statSystem;
        _moneyLabel = moneyLabel;
        _timeLabel = timeLabel;
        _time = time;

        _time.MinutePassEvent += TimeLabelUpdate;
        _statSystem.MoneyChangedEvent += MoneyLabelUpdate;
        _statSystem.ReputationChangedEvent += ReputationLabelUpdate;
    }

    private void TimeLabelUpdate() => _timeLabel.text = $"{_time.CurrentGameTime.Hours:00} : {_time.CurrentGameTime.Minutes:00}";

    private void MoneyLabelUpdate() => _moneyLabel.text = $"${_statSystem.Money:f}";

    private void ReputationLabelUpdate() => _reputationLabel.text = $"{_statSystem.Reputation:f0}%";

    public void Dispose() => _time.MinutePassEvent -= TimeLabelUpdate;
}
