// <copyright file="When_Reading_Now.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

using System;

using Common.DatesAndTimes;

using FluentAssertions;

using NUnit.Framework;

namespace Common.UnitTests.StaticNowProviderTests
{
    public class When_Reading_Now
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
        public void The_Date_And_Time_Are_Correct()
        {
            _now.Should().Be(Now);
        }
    }
}
