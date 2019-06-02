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
        [Key(5)] public short Member6 { get; set; }
        [Key(6)] public ushort Member7 { get; set; }
        [Key(7)] public int Member8 { get; set; }
        [Key(8)] public uint Member9 { get; set; }
        [Key(9)] public long Member10 { get; set; }
        [Key(10)] public ulong Member11 { get; set; }
        [Key(11)] public float Member12 { get; set; }
        [Key(12)] public DateTimeOffset Member13 { get; set; }
        [Key(13)] public decimal[] Member14 { get; set; }
        [Key(14)] public byte[][] Member15 { get; set; }
        [Key(15)] public DateTime[] Member16 { get; set; }
    }
}