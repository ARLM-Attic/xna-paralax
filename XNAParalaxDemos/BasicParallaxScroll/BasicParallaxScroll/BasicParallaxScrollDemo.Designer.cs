using System;
using XNAParalax.XNAScroller;

namespace BasicParallaxScroll
{
    partial class BasicParallaxScrollDemo
    {
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            XNAParalax.ParalaxBackground paralaxBackground1 = new XNAParalax.ParalaxBackground();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicParallaxScrollDemo));
            this.graphics = new Microsoft.Xna.Framework.Components.GraphicsComponent();
            this.paralaxBackground = new XNAParalax.ParalaxBackgroundComponent();
            this.scrollingCamera2d1 = new XNAParalax.ScrollingCamera2d();
            // 
            // graphics
            // 
            this.graphics.AllowMultiSampling = false;
            // 
            // paralaxBackground
            // 
            paralaxBackground1.FileName = "Media\\city.jpg";
            paralaxBackground1.TileX = true;
            paralaxBackground1.TileY = false;
            this.paralaxBackground.Backgrounds.Add(paralaxBackground1);
            this.paralaxBackground.Camera = this.scrollingCamera2d1;
            // 
            // scrollingCamera2d1
            // 
            this.scrollingCamera2d1.Speed = ((Microsoft.Xna.Framework.Vector2)(resources.GetObject("scrollingCamera2d1.Speed")));
            this.scrollingCamera2d1.WorldPos = ((Microsoft.Xna.Framework.Vector2)(resources.GetObject("scrollingCamera2d1.WorldPos")));
            this.GameComponents.Add(this.graphics);
            this.GameComponents.Add(this.paralaxBackground);
            this.GameComponents.Add(this.scrollingCamera2d1);

        }

        private Microsoft.Xna.Framework.Components.GraphicsComponent graphics;
        private XNAParalax.ParalaxBackgroundComponent paralaxBackground;
        private XNAParalax.ScrollingCamera2d scrollingCamera2d1;
    }
}
