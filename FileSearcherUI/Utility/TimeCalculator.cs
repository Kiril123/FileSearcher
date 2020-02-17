using System;

namespace FileSearcherUI.Utility
{
    /// <summary>
    /// Timer class.
    /// </summary>
    public class TimeCalculator : ITimeCalculator
    {
        /// <summary>
        /// Timer used.
        /// </summary>
        private System.Windows.Forms.Timer timer;
        /// <summary>
        /// How often will the event trigger.
        /// </summary>
        private int timeInterval;
        /// <summary>
        /// How many events before main event.
        /// </summary>
        private int timeEvents;
        /// <summary>
        /// How many events were triggered.
        /// </summary>
        private int eventCounter;
        /// <summary>
        /// Time passed since start.
        /// </summary>
        private int elapsedTime;
        /// <summary>
        /// Event handler for needed event.
        /// </summary>
        public event EventHandler<int> TimerTickedEvent;
        /// <summary>
        /// How often will the event trigger.
        /// </summary>
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
        /// <summary>
        /// How many events before main event.
        /// </summary>
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
        /// <summary>
        /// Constructor.
        /// Default: interval = 1000 ms,timeEvents = 1.
        /// </summary>
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
        /// <summary>
        /// Event fired at frequency.
        /// </summary>
        /// <param name="sender">sender object.</param>
        /// <param name="e"> event args.</param>
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
        /// <summary>
        /// Pauses the timer.
        /// </summary>
        public void Pause()
        {
            timer.Enabled = false;
        }
        /// <summary>
        /// Unpauses the timer.
        /// </summary>
        public void Unpause()
        {
            timer.Enabled = true;
        }
        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void Start()
        {
            eventCounter = 0;
            elapsedTime = 0;
            Unpause();
        }
        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
        {
            Pause();
            eventCounter = 0;
            elapsedTime = 0;
        }
    }
}
