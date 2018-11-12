using System;

namespace Common.EntityTypes
{
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AggregateRootAttribute : Attribute
    {
    }
}