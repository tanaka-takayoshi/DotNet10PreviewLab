using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;

namespace DotNet10PreviewLab
{
    internal class OrderedDictionaryTryAdd
    {
        public static void Execute()
        {
            //指定された文字列が何回出現したかをカウントする
            var text = "apple banana apple cherry banana apple";
            var orderedDictionary = new OrderedDictionary<string, int>();
            foreach (var word in text.Split(' '))
            {
                IncrementValue(orderedDictionary, word);
            }
            foreach (var pair in orderedDictionary)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        private static void IncrementValue(OrderedDictionary<string, int> orderedDictionary, string key)
        {
            // Try to add a new key with value 1.
            if (!orderedDictionary.TryAdd(key, 1, out int index))
            {
                // Key was present, so increment the existing value instead.
                int value = orderedDictionary.GetAt(index).Value;
                orderedDictionary.SetAt(index, value + 1);
            }
        }

    }
}
