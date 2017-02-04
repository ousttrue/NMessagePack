using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using System.IO;

namespace NMessagePack
{
    [TestFixture]
    public class BooleanTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void nil()
        {
            {
                var ms = new MemoryStream();
                var w = new MsgPackWriter(ms); ;
                w.MsgPackNil();
                var bytes = ms.ToArray();
                Assert.AreEqual(new Byte[] { 0xC0 }, bytes);

                Object j = Deserializer.Deserialize<Object>(bytes);
                Assert.AreEqual(null, j);
            }

            {
                var bytes = Serializer.Pack((object)null);
                Assert.AreEqual(new Byte[] { (byte)MsgPackType.NIL }, bytes);

                Object j = Deserializer.Deserialize<Object>(bytes);
                Assert.AreEqual(null, j);
            }
        }

        [Test]
        public void True()
        {
            var bytes = Serializer.Pack(true);
            Assert.AreEqual(new Byte[] { 0xC3 }, bytes);

            var value = MsgPackValue.Parse(bytes);
            var j = value.GetValue<Boolean>();
            Assert.AreEqual(true, j);
        }

        [Test]
        public void False()
        {
            var bytes = Serializer.Pack(false);
            Assert.AreEqual(new Byte[] { 0xC2 }, bytes);

            var value = MsgPackValue.Parse(bytes);
            var j = value.GetValue<Boolean>();
            Assert.AreEqual(false, j);
        }
    }
}
