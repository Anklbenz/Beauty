using System;
using UnityEngine;

public static class DataHolder
{
    public static event Action<int> ChosenNumberEvent;

    public static void OnChosenNumber(int obj){
        ChosenNumberEvent?.Invoke(obj);
    }



}