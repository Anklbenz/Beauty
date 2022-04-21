using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResultPanelDrawer
{
    private readonly Text _money, _moneyTotal, _count, _reputation, _average;
    private readonly StatSystem _stat;
    
    public UIResultPanelDrawer(StatSystem stat, Text money, Text moneyTotal, Text count, Text reputation, Text average){
        _stat = stat;
        _count = count;
        _money = money;
        _average = average;
        _moneyTotal = moneyTotal;
        _reputation = reputation;
        _average = average;
    }

    public void UpdateStatsLabels(){
        _count.text = _stat.VisitorCount.ToString();
        _money.text = $"${_stat.Money:f}";
        _moneyTotal.text =  $"${_stat.MoneyTotal:f}";
        _reputation.text = $"{_stat.Reputation:f0}%";
        _average.text = $"{_stat.AvgReputation:f}";

    }
    
}
