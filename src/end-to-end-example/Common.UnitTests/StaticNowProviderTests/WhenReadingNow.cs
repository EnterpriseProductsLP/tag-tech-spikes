using System;
using Common.DatesAndTimes;
using FluentAssertions;
using NUnit.Framework;

namespace Common.UnitTests.StaticNowProviderTests
{
    public class WhenReadingNow
    {
        private static readonly DateTime Now = new DateTime(2000, 01, 01);
        private DateTime _now;

        [SetUp]
        public void Setup()
        {
            IProvideNow nowProvider = new StaticNowProvider(Now);
            _now = nowProvider.Now;
        }

        [Test]
        public void TheDateAndTimeAreCorrect()
        {
            _now.Should().Be(Now);
        }
    }
}