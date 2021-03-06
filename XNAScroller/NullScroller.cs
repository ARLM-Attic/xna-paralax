using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;

namespace XNAParalax.XNAScroller
{
    /// <summary>
    /// NullScroller, performs no action.  
    /// 
    /// Use this class when you need to ensure that a Layer in the XNA Background doesn't scroll.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(NullScrollerConverter))]
    public class NullScroller: GameComponent, IScroller
    {
        protected float offset;

        /// <summary>
        /// The offset that we apply at the start of the game
        /// </summary>
        public float Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        protected float m_speed;

        protected bool paused;

        /// <summary>
        /// Is the Scroller Paused
        /// </summary>
        public bool IsPaused
        {
            get { return paused; }
            set { paused = value; }
        }

        /// <summary>
        /// The speed that the scroller scrolls in pixels per second
        /// </summary>
        public float Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }
	
        /// <summary>
        /// The default construct, ensure that not much happens here.
        /// </summary>
        public NullScroller()
        {            
            offset = 0;
        }
    }

    /// <summary>
    /// The Layer Converter is used to aid in design time serialization and thus allow easy access to editing of the layers.
    /// </summary>
    internal class NullScrollerConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            if (destType == typeof(InstanceDescriptor))
                return true;
            return base.CanConvertTo(context, destType);
        }
        public override object ConvertTo(ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture, object value, Type destType)
        {
            if (destType == typeof(InstanceDescriptor))
            {
                System.Reflection.ConstructorInfo ci =
                    typeof(NullScroller).GetConstructor(
                    System.Type.EmptyTypes);
                return new InstanceDescriptor(ci, null, false);
            }
            return base.ConvertTo(context, culture, value, destType);
        }
    }
}
