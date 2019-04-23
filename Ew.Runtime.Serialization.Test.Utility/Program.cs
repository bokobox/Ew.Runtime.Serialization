using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ew.Runtime.Serialization.Test.Utility
{
    internal static class Program
    {
        private static readonly List<Type> Types = new List<Type>
        {
            typeof(string),
            typeof(bool),
            typeof(char),
            typeof(sbyte),
            typeof(byte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(byte[]),
            typeof(DateTime),
            typeof(DateTimeOffset)
        };

        private static void Main(string[] args)
        {
            var modelMembersList = BuildModelMembersList();
            for (var i = 0; i < modelMembersList.Length; i++)
            {
                var members = modelMembersList[i];
                var code = BuildSourceCode($"TestModel{i + 1}", members);
                File.WriteAllText($"TestModel{i + 1}.cs", code);
            }
        }

        private static string BuildSourceCode(string name, IEnumerable<Type> memberTypes)
        {
            var head = "using System;namespace Ew.Runtime.Serialization.Test.Utility{public class " + name + "{";
            var tail = "}}";

            var members = memberTypes.Select((x, i) =>
            {
                var define = $"public {x.Name} Member{i + 1}";
                const string accessor = " { get; set; }";
                return string.Join(" ", define, accessor);
            });

            return head + string.Join("", members) + tail;
        }

        private static Type[][] BuildModelMembersList()
        {
            var modelMemberTypes = new List<Type[]> {Types.ToArray()};

            for (var i = 0; i < Types.Count; i++)
            {
                var array = Types.Skip(i).Take(3).Select(x => x.MakeArrayType()).ToArray();
                var members = Types.Except(array.Select(x => x.GetElementType())).Concat(array);

                modelMemberTypes.Add(members.ToArray());
            }

            var itemModels = modelMemberTypes.ToArray();
            for (var i = 0; i < itemModels.Length; i++)
            {
                var itemModel = itemModels[i].ToArray();
                var array = itemModel.Skip(i).Take(3).Select(x => x.MakeArrayType()).ToArray();
                var members = itemModel.Except(array.Select(x => x.GetElementType())).Concat(array);

                modelMemberTypes.Add(members.ToArray());
            }

            return modelMemberTypes.ToArray();
        }
    }
}