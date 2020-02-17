using System.Threading;
using System.Threading.Tasks;

namespace FileSearcherUI.Utility
{
    /// <summary>
    /// Token to pause or cancel an operation wrapper.
    /// </summary>
    public struct PauseOrCancelToken
    {
        /// <summary>
        /// Pause token wrapper.
        /// </summary>
        private PauseToken pauseToken;
        /// <summary>
        /// Cancel token wrapper.
        /// </summary>
        private CancellationToken cancellationToken;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pauseSource"> Pause token wrapper.</param>
        /// <param name="cancellationSource">Cancel token wrapper.</param>
        public PauseOrCancelToken(PauseTokenSource pauseSource,CancellationTokenSource cancellationSource)
        {
            this.pauseToken = pauseSource.Token;
            this.cancellationToken = cancellationSource.Token;
        }
        /// <summary>
        /// Pause operations.
        /// </summary>
        /// <returns></returns>
        public async Task PauseIfRequested()
        {
            await pauseToken.WaitWhilePausedAsync();
        }
        /// <summary>
        /// Cancel operations.
        /// </summary>
        public void CancelIfRequested()
        {
            cancellationToken.ThrowIfCancellationRequested();
        }
        /// <summary>
        /// Pause or cancel if requested.
        /// </summary>
        /// <returns></returns>
        public async Task PauseOrCancel()
        {
            cancellationToken.ThrowIfCancellationRequested();
            await pauseToken.WaitWhilePausedAsync();
        }
    }
}
