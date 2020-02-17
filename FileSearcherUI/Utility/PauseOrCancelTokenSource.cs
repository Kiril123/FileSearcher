using System;
using System.Threading;

namespace FileSearcherUI.Utility
{
    /// <summary>
    /// Token to pause or cancel operations.
    /// </summary>
    public class PauseOrCancelTokenSource:IDisposable
    {
        /// <summary>
        /// Source of pause token.
        /// </summary>
        private PauseTokenSource pauseTokenSource;
        /// <summary>
        /// Source of cancellation token.
        /// </summary>
        private CancellationTokenSource cancellationTokenSource;
        /// <summary>
        /// Constructor.
        /// </summary>
        public PauseOrCancelTokenSource()
        {
            pauseTokenSource = new PauseTokenSource();
            cancellationTokenSource = new CancellationTokenSource();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pauseTokenSource">Paused token source to use.</param>
        /// <param name="cancellationTokenSource">Cancel token source to use.</param>
        public PauseOrCancelTokenSource(PauseTokenSource pauseTokenSource, CancellationTokenSource cancellationTokenSource)
        {
            this.pauseTokenSource = pauseTokenSource;
            this.cancellationTokenSource = cancellationTokenSource;
        }
        /// <summary>
        /// Generates a new Token wrapper from this source.
        /// </summary>
        public PauseOrCancelToken Token
        {
            get
            {
                return new PauseOrCancelToken(pauseTokenSource, cancellationTokenSource);
            }
        }
        /// <summary>
        /// Is it paused.
        /// </summary>
        /// <returns></returns>
        public bool IsPaused()
        {
            return pauseTokenSource.IsPaused;
        }
        /// <summary>
        /// Pause tasks.
        /// </summary>
        public void Pause()
        {
            pauseTokenSource.IsPaused = true;
        }
        /// <summary>
        /// Unpause tasks.
        /// </summary>
        public void Unpause()
        {
            pauseTokenSource.IsPaused = false;
        }
        /// <summary>
        /// Cancel tasks.
        /// </summary>
        public void Cancel()
        {
            if (IsPaused())
            {
                Unpause();
            }
            cancellationTokenSource.Cancel();
        }
        /// <summary>
        /// Is the cancellation token disposed.
        /// </summary>
        /// <returns></returns>
        public bool IsDisposed()
        {
            return cancellationTokenSource == null;
        }
        /// <summary>
        /// Dispose of the cancellation token.
        /// </summary>
        public void Dispose()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
            }
        }
    }
}
