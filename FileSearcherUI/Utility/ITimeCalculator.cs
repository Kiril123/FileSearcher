using System;

namespace FileSearcherUI.Utility
{
    /// <summary>
    /// Timer iterface.
    /// </summary>
    public interface ITimeCalculator
    {
        /// <summary>
        /// How many events before main event.
        /// </summary>
        int TimeEvents { get; set; }
        /// <summary>
        /// How often will the event trigger.
        /// </summary>
        int TimeInterval { get; set; }
        /// <summary>
        /// Event handler for needed event.
        /// </summary>
        event EventHandler<int> TimerTickedEvent;
        /// <summary>
        /// Pauses the timer.
        /// </summary>
        void Pause();
        /// <summary>
        /// Unpauses the timer.
        /// </summary>
        void Unpause();
        /// <summary>
        /// Starts the timer.
        /// </summary>
        void Start();
        /// <summary>
        /// Stops the timer.
        /// </summary>
        void Stop();

    }
}