using System;

namespace FileSearcherUI.Utility
{
    public interface ITimeCalculator
    {
        int TimeEvents { get; set; }
        int TimeInterval { get; set; }

        event EventHandler<int> TimerTickedEvent;

        void Pause();
        void Start();
        void Stop();
        void Unpause();
    }
}