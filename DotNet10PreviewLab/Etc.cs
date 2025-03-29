using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet10PreviewLab
{
    internal class Etc
    {
        delegate int DR(string s);
        delegate void DO(string s, out int i);

        public static void Execute()
        {
            //unbound generic types in nameof
            var t = typeof(List<>);
            var n = nameof(List<>);

            DR w1 = (s) => s.Length;
            DO w2 = (s, out i) => i = s.Length;

            var f = new Fields2 { FirstName = "  First  ", FieldProperty = "  FieldProperty  ", AutoProperty = "  AutoProperty  " };
            Console.WriteLine($"{f.field}");

        }
    }

    class Fields
    {
        public string? FirstName { get; set; }
        public string? LastName { get => field; set => field = value.Trim(); }
    }

    class Fields2
    {
        public string? field;
        public string? FirstName { get; set; }
        public string? FieldProperty { get => @field; set => @field = value.Trim(); }
        public string? AutoProperty { get => field; set => field = value.Trim(); }
    }
}
