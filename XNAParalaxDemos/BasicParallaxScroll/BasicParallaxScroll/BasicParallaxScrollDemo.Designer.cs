using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicParallaxScrollDemo));
            this.graphics = new Microsoft.Xna.Framework.Components.GraphicsComponent();
            this.scrollingCamera2d = new XNAParalax.ScrollingCamera2d();
            this.paralaxBackground = new XNAParalax.ParalaxBackgroundComponent();
            // 
            // scrollingCamera2d
            // 
            this.scrollingCamera2d.Speed = ((Microsoft.Xna.Framework.Vector2)(resources.GetObject("scrollingCamera2d.Speed")));
            this.scrollingCamera2d.WorldPos = ((Microsoft.Xna.Framework.Vector2)(resources.GetObject("scrollingCamera2d.WorldPos")));
            // 
            // paralaxBackground
            // 
            XNAParalax.ParalaxBackground pb = new XNAParalax.ParalaxBackground("Media\\city.jpg");
            

            this.paralaxBackground.Backgrounds.Add(pb);
            this.paralaxBackground.Camera = this.scrollingCamera2d;

            this.graphics.AllowMultiSampling = false; //Sorry Guys, my Graphics Card is rubbish :)
           
            this.GameComponents.Add(this.graphics);
            this.GameComponents.Add(this.scrollingCamera2d);
            this.GameComponents.Add(this.paralaxBackground);

        }

        private Microsoft.Xna.Framework.Components.GraphicsComponent graphics;
        private XNAParalax.ScrollingCamera2d scrollingCamera2d;
        private XNAParalax.ParalaxBackgroundComponent paralaxBackground;
    }
}
