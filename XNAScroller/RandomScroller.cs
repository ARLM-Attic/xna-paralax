using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;


namespace XNAParalax.XNAScroller
{
    /// <summary>
    /// Sin Scroller is an oscilator.  It updates the offset based on a sin curve.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(RandomScrollerConverter))]
    public class RandomScroller : NullScroller, IScroller
    {
        #region IScroller Members
        
        private float m_magnitude;

        /// <summary>
        /// The Magnitude of the Oscillation.
        /// </summary>
        public float Magnitude
        {
            get { return m_magnitude; }
            set { m_magnitude = value; }
        }
	

        private double totalRadians = 0.0;

        #endregion

        private Random r;

        private bool isPositive;

        public bool IsPositive
        {
            get { return isPositive; }
            set { isPositive = value; }
        }
	

        /// <summary>
        /// Handles the update to the game status.
        /// </summary>
        public override void Update()
        {
            if (!paused)
            {
                if (isPositive)
                {
                    offset = (r.Next((int)m_magnitude) * 1 / Game.ElapsedTime.Milliseconds);
                }
                else
                {
                    offset = (-(r.Next((int)m_magnitude)) * 1 / Game.ElapsedTime.Milliseconds);
                }
            }
            base.Update();
        }

        /// <summary>
        /// Ensures that all the correct variables are set up before the Game Starts
        /// </summary>
        public override void Start()
        {
            totalRadians = offset; //Ensure that the offset is applied.
        }

        public RandomScroller()
        {
            r= new Random();
            isPositive = true;
            offset = 0;
            m_speed = 2.0f * (float) Math.PI;  //Once complete oscillation in 1 second
            m_magnitude = 1.0f; //Don't multiply the scale of the change.
        }

        /// <summary>
        /// The Layer Converter is used to aid in design time serialization and thus allow easy access to editing of the layers.
        /// </summary>
        internal class RandomScrollerConverter : TypeConverter
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
                        typeof(RandomScroller).GetConstructor(
                        System.Type.EmptyTypes);
                    return new InstanceDescriptor(ci, null, false);
                }
                return base.ConvertTo(context, culture, value, destType);
            }
        }
    }
}
