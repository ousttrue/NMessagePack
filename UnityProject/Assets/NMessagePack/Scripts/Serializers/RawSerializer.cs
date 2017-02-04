using System;
using System.Collections.Generic;


namespace NMessagePack.Serializers {
    public class RawSerializer<T> : Serializer<T>
        where T: IList<Byte>
    {
        protected override void NonNullSerialize(MsgPackWriter w, T t)
        {
            w.MsgPack(t);
        }
    }
}
