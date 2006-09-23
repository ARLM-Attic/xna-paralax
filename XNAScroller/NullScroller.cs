using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.ComponentModel.Design.Serialization;

namespace XNAParalax.XNAScroller
{
    /// <summary>
    /// NullScroller, performs no action.  
    /// 
    /// Use this class when you need to ensure that a Layer in the XNA Background doesn't scroll.
    /// </summary>
    [Serializable]
    public class NullScroller: GameComponent, IScroller
    {
        private float offset;

        /// <summary>
        /// The offset that we apply at the start of the game
        /// </summary>
        public float Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        private float m_speed;

        /// <summary>
        /// The speed that the scroller scrolls in pixels per second
        /// </summary>
        public float Speed
        {
            get { return m_speed; }            
        }
	
        /// <summary>
        /// The default construct, ensure that not much happens here.
        /// </summary>
        public NullScroller()
        {            
            offset = 0;
        }
    }
}
