using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace _LayerScroll
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    partial class Game1 : Microsoft.Xna.Framework.Game
    {
        public Game1()
        {
            InitializeComponent();
        }

        protected override void Update()
        {
            // The time since Update was called last
            float elapsed = (float)ElapsedTime.TotalSeconds;

            // TODO: Add your game logic here

            // Let the GameComponents update
            UpdateComponents();
        }

        protected override void Draw()
        {
            // Make sure we have a valid device
            if (!graphics.EnsureDevice())
                return;

            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            graphics.GraphicsDevice.BeginScene();

            // TODO: Add your drawing code here

            // Let the GameComponents draw
            DrawComponents();

            graphics.GraphicsDevice.EndScene();
            graphics.GraphicsDevice.Present();
        }
    }
}