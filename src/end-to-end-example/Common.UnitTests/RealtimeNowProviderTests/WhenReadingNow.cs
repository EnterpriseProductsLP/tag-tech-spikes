using System;
using FluentAssertions;
using NUnit.Framework;

namespace Common.UnitTests.RealtimeNowProviderTests
{
    public class WhenReadingNow
    {
        private DateTime _actual;

        [SetUp]
        public void Setup()
        {
            IProvideNow nowProvider = new RealtimeNowProvider();
            _actual = nowProvider.Now;
        }

        [Test]
        public void TheDateAndTimeAreCorrect()
        {
            var allowedTimeLag = new TimeSpan(0, 0, 0, 1);
            var actualTimeLag = DateTime.Now - _actual;
            actualTimeLag.Should().BeLessOrEqualTo(allowedTimeLag);

        }
    }
}