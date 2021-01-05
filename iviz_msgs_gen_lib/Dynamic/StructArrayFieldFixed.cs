using System;
using System.Runtime.InteropServices;
using Iviz.Msgs;
using Buffer = Iviz.Msgs.Buffer;

namespace Iviz.MsgsGen.Dynamic
{
    [Preserve]
    internal sealed class StructArrayFieldFixed<T> : IField where T : unmanaged
    {
        public uint Count { get; }

        public T[] Value { get; set; }

        object IField.Value => Value;

        public int RosMessageLength => (int) Count * Marshal.SizeOf<T>();

        public StructArrayFieldFixed(uint count)
        {
            Count = count;
            Value = new T[Count];
        }

        public void RosValidate()
        {
            if (Value == null)
            {
                throw new NullReferenceException(nameof(Value));
            }

            if (Value.Length != Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RosSerialize(ref Buffer b)
        {
            b.SerializeStructArray(Value, Count);
        }

        public void RosDeserializeInPlace(ref Buffer b)
        {
            Value = b.DeserializeStructArray<T>(Count);
        }

        public IField Generate()
        {
            return new StructArrayFieldFixed<T>(Count);
        }
    }
}