using System;

namespace Common
{
    public class RealtimeNowProvider : IProvideNow
    {
        public DateTime Now => DateTime.Now;
    }
}