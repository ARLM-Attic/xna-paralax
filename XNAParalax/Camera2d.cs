using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.ComponentModel;

namespace TypeConverters
{
    public partial class Camera2d : Microsoft.Xna.Framework.GameComponent
    {
        private Vector2 mWorldPosistion;

        [TypeConverter(typeof(Vector2Converter))]
        public Vector2 WorldPos
        {
            get { return mWorldPosistion; }
            set { mWorldPosistion = value; }
        }

        private Rectangle mView;

        public Rectangle ViewPort
        {
            get { 
                mView.X = (int) mWorldPosistion.X;
                mView.Y = (int) mWorldPosistion.Y;
               
                return mView;
            }            
        }
	
	
        
        public Camera2d()
        {
            InitializeComponent();
        }

        public override void Start()
        {
            //The following 2 lines could be put in start.
            mView.Width = Game.Window.ClientWidth;
            mView.Height = Game.Window.ClientHeight;

            // TODO: Handle Resize Event
        }

        public override void Update()
        {
            // TODO: Add your update code here
        }
                    
    }
}