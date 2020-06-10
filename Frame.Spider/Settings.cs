using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Spider
{
    public class Settings
    {
        /// <summary>
        /// 请求队列的最大值
        /// 默认值100
        /// </summary>
        public static int QueueMaxCount = 100;

        /// <summary>
        /// 线程池深度  默认16
        /// </summary>
        public static int ThreadPoolCount = 16;

        /// <summary>
        /// 任务延迟
        /// </summary>
        public static int TaskDelay = 1000;

    }
}
