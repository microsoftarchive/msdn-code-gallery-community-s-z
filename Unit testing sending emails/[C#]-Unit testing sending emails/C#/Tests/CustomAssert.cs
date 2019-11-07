namespace EmailValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class CustomAssert
    {
        internal static void IsTrue(
            Func<string, bool> method, IEnumerable<string> examples, IEnumerable<string> exceptions = null)
        {
            exceptions = exceptions ?? Enumerable.Empty<string>();
            AssertIt(method, examples.Except(exceptions), Assert.IsTrue, "False negative: {0}");
        }

        internal static void IsFalse(
            Func<string, bool> method, IEnumerable<string> examples, IEnumerable<string> exceptions = null)
        {
            exceptions = exceptions ?? Enumerable.Empty<string>();
            AssertIt(method, examples.Except(exceptions), Assert.IsFalse, "False positive: {0}");
        }

        private static void AssertIt<T>(
            Func<T, bool> method, IEnumerable<T> items, Action<bool, string> assert, string message)
        {
            items.ToList().ForEach(item => assert(method(item), string.Format(message, item)));
        }
    }
}