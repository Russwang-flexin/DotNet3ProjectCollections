using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace Frame.Spider
{
    /// <summary>
    ///  先这么拿本地的队列用着
    /// </summary>
    public class PriorityQueue<T>
    {
        static Queue<T> TaskQueue = new Queue<T>(Settings.QueueMaxCount);
        readonly static object _locker = new object();
        static EventWaitHandle _wh = new AutoResetEvent(false);

        public static void EnqueueTask(T task)
        {
            lock (_locker) 
            {
                TaskQueue.Enqueue(task);
            }
            _wh.Set();  
        }

        public static void Dispose()
        {
            TaskQueue.Clear();
        }

        public static T  DeQueue()
        {
            lock (_locker)
            {
                if (TaskQueue.Count > 0)
                {
                    T work = TaskQueue.Dequeue();
                    return work;
                }
                else 
                {
                    throw new IndexOutOfRangeException("Empty Queue！");
                }
            }
        }
    }
}
