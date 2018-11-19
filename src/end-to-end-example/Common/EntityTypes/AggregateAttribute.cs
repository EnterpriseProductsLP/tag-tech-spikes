// <copyright file="AggregateAttribute.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// � Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

using System;

namespace Common.EntityTypes
{
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AggregateAttribute : Attribute
    {
    }
}
