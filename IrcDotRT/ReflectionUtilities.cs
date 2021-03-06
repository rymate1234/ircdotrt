﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IrcDotRT
{
    // Utilities for reflection of managed entities.
    internal static class ReflectionUtilities
    {
        public static IEnumerable<Tuple<TAttribute, TDelegate>> GetAttributedMethods<TAttribute, TDelegate>(this object obj)
            where TAttribute : Attribute
            where TDelegate : class
        {
            // Find all methods in class that are marked by one or more instances of given attribute.
            var messageProcessorsMethods = obj.GetType().GetRuntimeMethods();
            foreach (var methodInfo in messageProcessorsMethods)
            {
                var methodAttributes = (TAttribute[])methodInfo.GetCustomAttributes(typeof(TAttribute), true);

                if (methodAttributes.Length > 0)
                {
                    TDelegate methodDelegate = (TDelegate)(object)methodInfo.CreateDelegate(typeof(TDelegate), obj);

                    // Get each attribute applied to method.
                    foreach (var attribute in methodAttributes)
                        yield return Tuple.Create(attribute, methodDelegate);
                }
            }
        }
    }
}
