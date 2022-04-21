using System;

public interface  ITime
{
     event Action MinutePassEvent;
     event Action EndOfDayEvent;
    event Action DayStartEvent;
     
     TimeSpan CurrentGameTime{ get; }
     TimeSpan DayEnd{ get; }
}