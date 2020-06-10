using System;
using System.Collections.Generic;
using System.Text;

namespace DataCenterFactory.BasicSpiderAbstraction.Schedualer
{
    // 处理数据流向
    public class Schedualer
    {
        private static Schedualer _Instance = null;
        public static Schedualer Instance
        {
            get
            {
                return _Instance == null ? new Schedualer() : _Instance;
            }
        }




    }
}
