using System.Threading.Tasks;

namespace FileSearcherUI.Utility
{
    /// <summary>
    /// Pause token wrapper class.
    /// </summary>
    public struct PauseToken
    {
        /// <summary>
        /// Token source (similar to cancellation token source).
        /// </summary>
        private readonly PauseTokenSource pauseToken;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="source">Token source</param>
        internal PauseToken(PauseTokenSource source)
        {
            pauseToken = source;
        }
        /// <summary>
        /// Is the token pausing the methods.
        /// </summary>
        public bool IsPaused
        {
            get
            {
                return pauseToken != null && pauseToken.IsPaused;
            }
        }
        /// <summary>
        /// Pausing task.
        /// </summary>
        /// <returns>Pausing task if its paused,else completed task.</returns>
        public Task WaitWhilePausedAsync()
        {
            return IsPaused ? pauseToken.WaitWhilePausedAsync() : PauseTokenSource.completedTask;
        }
    }
}
