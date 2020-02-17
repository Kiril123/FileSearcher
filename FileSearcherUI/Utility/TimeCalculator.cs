using System;
using System.Timers;

namespace FileSearcherUI.Utility
{
    public class TimeCalculator : ITimeCalculator
    {
        private System.Windows.Forms.Timer timer;
        private int timeInterval;
        private int timeEvents;
        private int eventCounter;
        private int elapsedTime;
        public event EventHandler<int> TimerTickedEvent;

        public int TimeInterval
        {
            get
            {
                return timeInterval;
            }
            set
            {
                timeInterval = value;
                timer.Interval = value;
            }
        }
        public int TimeEvents
        {
            get
            {
                return timeEvents;
            }
            set
            {
                timeEvents = value;
            }
        }
        public TimeCalculator()
        {
            timeInterval = 1000;
            timeEvents = 1;
            eventCounter = 0;
            elapsedTime = 0;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = TimeInterval;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            eventCounter++;
            if (eventCounter == TimeEvents)
            {
                eventCounter = 0;
                elapsedTime++;
                TimerTickedEvent?.Invoke(this,elapsedTime);
            }
        }
        public void Pause()
        {
            timer.Enabled = false;
        }
        public void Unpause()
        {
            timer.Enabled = true;
        }
        public void Start()
        {
            eventCounter = 0;
            elapsedTime = 0;
            Unpause();
        }
        public void Stop()
        {
            Pause();
            eventCounter = 0;
            elapsedTime = 0;
        }
    }
}
