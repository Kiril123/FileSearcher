using System.Threading;
using System.Threading.Tasks;

namespace FileSearcherUI.Utility
{
    /// <summary>
    /// Token to pause operations.
    /// </summary>
    public class PauseTokenSource
    {
        /// <summary>
        /// Pausing task,
        /// </summary>
        private volatile TaskCompletionSource<bool> methodPaused;
        /// <summary>
        /// Static completed task.
        /// </summary>
        internal static readonly Task completedTask = Task.FromResult(true);
        /// <summary>
        /// Is it paused.
        /// </summary>
        public bool IsPaused
        {
            get{
                return methodPaused != null;
            }
            set{
                if (value)
                {
                    Interlocked.CompareExchange(ref methodPaused, new TaskCompletionSource<bool>(), null);
                }
                else
                {
                    while (true)
                    {
                        TaskCompletionSource<bool> taskCompletionSource = methodPaused;
                        if (taskCompletionSource == null)
                        {
                            return;
                        }
                        if (Interlocked.CompareExchange(ref methodPaused, null, taskCompletionSource) == taskCompletionSource)
                        {
                            taskCompletionSource.SetResult(true);
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Pausing task.
        /// </summary>
        /// <returns></returns>
        internal Task WaitWhilePausedAsync()
        {
            TaskCompletionSource<bool> current = methodPaused;
            return current != null ? current.Task : completedTask;
        }
        /// <summary>
        /// Generates a new token wrapper with this object.
        /// </summary>
        public PauseToken Token
        {
            get
            {
                return new PauseToken(this);
            }
        }
    }
}
