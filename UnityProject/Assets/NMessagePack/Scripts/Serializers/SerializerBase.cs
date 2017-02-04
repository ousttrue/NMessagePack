using System;

namespace NMessagePack.Serializers
{
    public abstract class Serializer<T> : ISerializer
    {
        public void Serialize(MsgPackWriter w, object o)
        {
            if (o == null)
            {
                w.MsgPackNil();
            }
            else
            {
                NonNullSerialize(w, (T)o);
            }
        }

        public void Serialize(MsgPackWriter w, T t)
        {
            if (t == null)
            {
                w.MsgPackNil();
            }
            else
            {
                NonNullSerialize(w, t);
            }
        }

        protected abstract void NonNullSerialize(MsgPackWriter w, T t);
    }

    public class NullSerializer : Serializer<Object>
    {
        protected override void NonNullSerialize(MsgPackWriter w, object t)
        {
            throw new NotImplementedException();
        }
    }
}
