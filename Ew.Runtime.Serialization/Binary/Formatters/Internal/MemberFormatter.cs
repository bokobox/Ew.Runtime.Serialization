using System.Reflection;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;
using Ew.Runtime.Serialization.Binary.Resolvers;
using Ew.Runtime.Serialization.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Internal
{
    public class MemberFormatter<TParent, TMember> : IMemberFormattable<TParent>
    {
        private readonly PropertyAdapter<TParent, TMember> _adapter;
        private readonly IBinaryFormatable<TMember> _formatter;

        public MemberFormatter(PropertyInfo info)
        {
            _adapter = new PropertyAdapter<TParent, TMember>(info);
            _formatter = (IBinaryFormatable<TMember>)StandardResolver<TMember>.GetFormatter();
        }

        public void Serialize(ref InternalBufferWriter writer, TParent instance)
        {
            var value = _adapter.Get(instance);
            _formatter.Serialize(ref writer, value);
        }

        public void Deserialize(ref InternalBufferReader reader, TParent instance)
        {
            var value = _formatter.Deserialize(ref reader);
            _adapter.Set(instance, value);
        }
    }
}