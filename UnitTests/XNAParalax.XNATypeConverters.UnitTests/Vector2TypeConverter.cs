using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using Microsoft.Xna.Framework;

namespace XNAParalax.XNATypeConverters.UnitTests
{
    [TestFixture]
    public class Vector2TypeConverter
    {
        /// <summary>
        /// Tests that a converter can be used against the object.
        /// </summary>
        [Test]
        public void TypeConverterCanConvertFromString()
        {            
            Vector2Converter vconv = new Vector2Converter();
            Assert.IsTrue(vconv.CanConvertFrom(typeof(string)));
        }

        /// <summary>
        /// Tests that a converter can be used against the object.
        /// </summary>
        [Test]
        public void TypeConverterCannotConvertFromInt()
        {
            Vector2Converter vconv = new Vector2Converter();
            Assert.IsFalse(vconv.CanConvertFrom(typeof(InstanceDescriptor)));
        }

        [Test]
        public void TypeConverterCanConvertToInstanceDescriptor()
        {
            Vector2Converter vconv = new Vector2Converter();
            Assert.IsTrue(vconv.CanConvertTo(typeof(InstanceDescriptor)));
        }

        [Test]
        public void TypeConverterCanConvertToString()
        {
            Vector2Converter vconv = new Vector2Converter();
            Assert.IsTrue(vconv.CanConvertTo(typeof(string)));
        }

        [Test]
        public void TypeConverterConvertToString()
        {
            Vector2Converter vconv = new Vector2Converter();
            Vector2 v2 = new Vector2(100, 99);

            string s = (string) vconv.ConvertTo(v2, typeof(string));

            Assert.AreEqual("{100, 99}", s);
        }

        [Test]
        public void TypeConverterConvertFromString()
        {
            Vector2Converter vconv = new Vector2Converter();
            Vector2 v2 = new Vector2(100, 99);

            Vector2 s = (Vector2)vconv.ConvertFrom("{100, 99}");

            Assert.AreEqual(v2.X, s.X);
            Assert.AreEqual(v2.Y, s.Y);
        }
    }
}
