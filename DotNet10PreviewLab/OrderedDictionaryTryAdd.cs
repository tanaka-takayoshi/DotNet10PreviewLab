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
            if (!orderedDictionary.TryAdd(key, 1, out int index))
            {
                int value = orderedDictionary.GetAt(index).Value;
                orderedDictionary.SetAt(index, value + 1);
            }
        }

        private static void AddValue(OrderedDictionary<string, string[]> orderedDictionary, string key, string value)
        {
            if (!orderedDictionary.TryAdd(key, [value], out int index))
            {
                var array = orderedDictionary.GetAt(index).Value;
                orderedDictionary.SetAt(index, [.. array.Prepend(value)]);
            }
        }

        private static void DecrementValue(OrderedDictionary<string, int> orderedDictionary, string key)
        {
            if (orderedDictionary.TryGetValue(key, out int value, out int index))
            {
                //カウントが0になる場合は削除する
                if (value == 1)
                {
                    orderedDictionary.RemoveAt(index);
                }
                else
                {
                    orderedDictionary.SetAt(index, value - 1);
                }
            }//存在しない場合は何もしない
        }
    }
}
