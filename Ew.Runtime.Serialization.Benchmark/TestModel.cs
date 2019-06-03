using System;
using MessagePack;

namespace Ew.Runtime.Serialization.Benchmark
{
    [MessagePackObject]
    public class TestModel
    {
        [Key(0)] public string Member1 { get; set; }
        [Key(1)] public bool Member2 { get; set; }
        [Key(2)] public char Member3 { get; set; }
        [Key(3)] public sbyte Member4 { get; set; }
        [Key(4)] public byte Member5 { get; set; }
    }
}