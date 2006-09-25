using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;
using XNAParalax.XNATypeConverters;
using XNAParalax.XNAScroller;

namespace XNAParalax
{
    /// <summary>
    /// An Automatically Scrolling Camera.
    /// </summary>
    [Serializable]
    public partial class ScrollingCamera2d : Camera2d
    {
        private Vector2 m_speed;

        [TypeConverter(typeof(Vector2Converter))]
        public Vector2 Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        } 

      
        public ScrollingCamera2d()
            : base()
        {
            m_speed = new Vector2();
            InitializeComponent();
        }               

        public override void Update()
        {
            
            this.WorldPos += (m_speed * 1 / Game.ElapsedTime.Milliseconds);

            base.Update();
        }
        
    }
}