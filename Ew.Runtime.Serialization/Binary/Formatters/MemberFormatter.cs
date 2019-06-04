using System.Reflection;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Resolvers;
using Ew.Runtime.Serialization.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters
{
    internal class MemberFormatter<TParent, TMember> : BaseMemberFormatter<TParent>
    {
        private readonly PropertyAdapter<TParent, TMember> _adapter;
        private readonly BinaryFormatter<TMember> _formatter;

        public MemberFormatter(PropertyInfo info)
        {
            _adapter = new PropertyAdapter<TParent, TMember>(info);
            _formatter = (BinaryFormatter<TMember>) StandardResolver<TMember>.GetFormatter();
        }

        public override void Serialize(ref BinaryBufferWriter writer, TParent instance)
        {
            var value = _adapter.Get(instance);
            _formatter.Serialize(ref writer, value);
        }

        public override void Deserialize(ref BinaryBufferReader reader, TParent instance)
        {
            var value = _formatter.Deserialize(ref reader);
            _adapter.Set(instance, value);
        }
    }
}