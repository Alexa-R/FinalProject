using System;
using System.Linq;

namespace FinalProject.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random Random = new Random();
        private const string WithoutSpacesPattern = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GetRandomString(int length) =>
            new string(Enumerable.Repeat(WithoutSpacesPattern, length).Select(s => s[Random.Next(s.Length)]).ToArray());
    }
}