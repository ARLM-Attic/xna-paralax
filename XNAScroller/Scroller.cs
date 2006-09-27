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
    /// The basic Scroller Component.
    /// 
    /// This scroller simply returns the number of pixels the object
    /// should have moved since the last frame based on the configured speed.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ScrollerConverter))]
    public class Scroller: NullScroller, IScroller
    {
           
	
        /// <summary>
        /// The default constructor.
        /// 
        /// Initially, there is no speed or offset defined.
        /// </summary>
        public Scroller()
        {
            m_speed = 10;
            offset = 0;
        }

        /// <summary>
        /// Handles the Games Update event.
        /// 
        /// Simply moves the offset along by an interpolated amount based on the game time.
        /// </summary>
        public override void Update()
        {
            offset = (m_speed * 1 / Game.ElapsedTime.Milliseconds);
            
            base.Update();
        }
    }
}
