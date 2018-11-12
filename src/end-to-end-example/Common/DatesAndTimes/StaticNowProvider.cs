using System;

namespace Common.DatesAndTimes
{
    public class StaticNowProvider : IProvideNow
    {
        public StaticNowProvider(DateTime now)
        {
            Now = now;
        }

        public DateTime Now { get; }
    }
}