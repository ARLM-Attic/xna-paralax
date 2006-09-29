using System;

namespace _LayerScroll
{
    partial class Game1
    {
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            XNAParalax.ParalaxBackground paralaxBackground1 = ((XNAParalax.ParalaxBackground)(new XNAParalax.ParalaxBackground()));
            XNAParalax.ParalaxBackground paralaxBackground2 = ((XNAParalax.ParalaxBackground)(new XNAParalax.ParalaxBackground()));
            this.scroller1 = ((XNAParalax.XNAScroller.Scroller)(new XNAParalax.XNAScroller.Scroller()));
            this.scroller2 = ((XNAParalax.XNAScroller.Scroller)(new XNAParalax.XNAScroller.Scroller()));
            this.graphics = new Microsoft.Xna.Framework.Components.GraphicsComponent();
            this.camera2d1 = new XNAParalax.Camera2d();
            this.paralaxBackgroundComponent1 = new XNAParalax.ParalaxBackgroundComponent();
            // 
            // scroller1
            // 
            this.scroller1.Offset = 0F;
            this.scroller1.Speed = 10F;
            // 
            // scroller2
            // 
            this.scroller2.Offset = 0F;
            this.scroller2.Speed = 10F;
            // 
            // graphics
            // 
            this.graphics.AllowMultiSampling = false;
            // 
            // camera2d1
            // 
            this.camera2d1.WorldPos = new Microsoft.Xna.Framework.Vector2(0F, 0F);
            // 
            // paralaxBackgroundComponent1
            // 
            paralaxBackground1.FileName = "Media\\cloud.dds";
            paralaxBackground1.Offset = new Microsoft.Xna.Framework.Vector2(10F, 0F);
            paralaxBackground1.TileX = true;
            paralaxBackground1.TileY = false;
            paralaxBackground1.XScrollerComponent = this.scroller1;
            paralaxBackground2.FileName = "Media\\cloud.dds";
            paralaxBackground2.Offset = new Microsoft.Xna.Framework.Vector2(0F, 0F);
            paralaxBackground2.TileX = true;
            paralaxBackground2.TileY = false;
            paralaxBackground2.XScrollerComponent = this.scroller2;
            this.paralaxBackgroundComponent1.Backgrounds.Add(paralaxBackground1);
            this.paralaxBackgroundComponent1.Backgrounds.Add(paralaxBackground2);
            this.paralaxBackgroundComponent1.Camera = this.camera2d1;
            this.GameComponents.Add(this.graphics);
            this.GameComponents.Add(this.camera2d1);
            this.GameComponents.Add(this.paralaxBackgroundComponent1);
            this.GameComponents.Add(this.scroller1);
            this.GameComponents.Add(this.scroller2);

        }

        private Microsoft.Xna.Framework.Components.GraphicsComponent graphics;
        private XNAParalax.Camera2d camera2d1;
        private XNAParalax.ParalaxBackgroundComponent paralaxBackgroundComponent1;
        private XNAParalax.XNAScroller.Scroller scroller1;
        private XNAParalax.XNAScroller.Scroller scroller2;
    }
}
