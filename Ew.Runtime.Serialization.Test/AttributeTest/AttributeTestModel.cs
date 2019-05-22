using System;

namespace Ew.Runtime.Serialization.Test.AttributeTest
{
    public class AttributeTestModel
    {
        public sbyte Member1 { get; set; }
        public byte Member2 { get; set; }
        public short Member3 { get; set; }
        public ushort Member4 { get; set; }
        public int Member5 { get; set; }
        public uint Member6 { get; set; }
        public long Member7 { get; set; }
        public ulong Member8 { get; set; }
        public float Member9 { get; set; }
        public decimal Member10 { get; set; }
        public byte[] Member11 { get; set; }
        public DateTime Member12 { get; set; }
        [Attributes.IgnoreMember] public DateTimeOffset Member13 { get; set; }
        public string[] Member14 { get; set; }
        public bool[] Member15 { get; set; }
        public char[] Member16 { get; set; }
    }
}