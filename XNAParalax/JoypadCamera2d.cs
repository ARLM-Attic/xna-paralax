using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel;
using XNAParalax.XNATypeConverters;

namespace XNAParalax
{
    [Serializable]
    public partial class JoypadCamera2d : Camera2d
    {
        private Vector2 m_speed;

        [TypeConverter(typeof(Vector2Converter))]     
        public Vector2 Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }
        
        public JoypadCamera2d(): base()
        {                 
            InitializeComponent();
        }               

        public override void Update()
        {
            GamePadState gsp = GamePad.GetState(PlayerIndex.One);

            m_speed.X = gsp.ThumbSticks.Left.X * 100.0f;
            m_speed.Y = gsp.ThumbSticks.Left.Y * 100.0f;

            this.WorldPos += (m_speed * 1 / Game.ElapsedTime.Milliseconds);

            base.Update();
        }
        
    }
}