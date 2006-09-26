using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.ComponentModel;
using XNAParalax.XNATypeConverters;
    
namespace XNAParalax
{
    [Serializable]
    public class ParalaxBackgroundComponent : GameComponent
    {
        private List<ParalaxBackground> m_backgrounds;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]       
        public List<ParalaxBackground> Backgrounds
        {
            get { return m_backgrounds; }               
        }

        private Camera2d myCamera;

        public Camera2d Camera
        {
            get { return myCamera; }
            set { myCamera = value; }
        }

        public ParalaxBackgroundComponent()
        {
            m_backgrounds = new List<ParalaxBackground>();                
        }

        protected override void OnGameChanging(Game previousGame)
        {
            base.OnGameChanging(previousGame);
        }

        /// <summary>
        /// Load the textures that are configured
        /// </summary>
        public override void Start()
        {
            foreach (ParalaxBackground texture in m_backgrounds)
            {
                texture.BackGroundTexture = Texture2D.FromFile(this.Game.GameServices.GetService<IGraphicsDeviceService>().GraphicsDevice, texture.FileName);
            }
            base.Start();
        }

        public override void Draw()
        {
            SpriteBatch sb = new SpriteBatch(this.Game.GameServices.GetService<IGraphicsDeviceService>().GraphicsDevice);

            sb.Begin(SpriteBlendMode.AlphaBlend);

            foreach (ParalaxBackground layer in m_backgrounds)
            {
                layer.Offset += new Vector2(layer.XScrollerComponent.Offset, layer.YScrollerComponent.Offset);
              
                Texture2D texture = layer.BackGroundTexture;

                int width = layer.BackGroundTexture.Width;
                int height = layer.BackGroundTexture.Height;
                
                //The amount to cut
                Vector2 vCut = new Vector2(0, 0);
                Vector2 vEdge = new Vector2(0, 0);
                
                //The amount to cut from the start    
                                   
                if (Camera.ViewPort.X > 0.0f && layer.TileX )
                {
                    vCut.X = (int)Math.Abs(Camera.ViewPort.X + layer.Offset.X) % width;
                }
                else if (layer.TileX && Camera.ViewPort.Width > width)
                {
                    vCut.X = width + ((int)(Camera.ViewPort.X + layer.Offset.X )% width);
                }                
                else
                {
                    vCut.X = 0;
                }

                if (Camera.ViewPort.Y > 0.0f && layer.TileY)
                {                        
                    vCut.Y = (int)Math.Abs(Camera.ViewPort.Y) % height;
                }
                else if (layer.TileY)
                {
                    vCut.Y = height + ((int)Camera.ViewPort.Y % height);
                }
                else
                {
                    vCut.Y = 0;
                }

                int tilesXCount = (Game.Window.ClientWidth + (int) vCut.X) / width;
                int tilesYCount = (Game.Window.ClientHeight + (int) vCut.Y) / height;

                int edge = (int)Game.Window.ClientWidth + (int)vCut.X - ( tilesXCount * width) ;
                
                vEdge.X = (int)Game.Window.ClientWidth + vCut.X - (tilesXCount * width);
                vEdge.Y = (int)Game.Window.ClientHeight + vCut.Y - (tilesYCount * height);


                Rectangle leftCut;
                Rectangle destCut;

                leftCut = new Rectangle((int)vCut.X, (int) vCut.Y, width - (int) vCut.X, height - (int) vCut.Y);
                if (layer.TileX)
                {
                    destCut = new Rectangle(0, (int)layer.Offset.Y + Camera.ViewPort.Y, width - (int)vCut.X, height - (int)vCut.Y);
                }
                else
                {
                    destCut = new Rectangle((int)layer.Offset.X + Camera.ViewPort.X,0 , width - (int)vCut.X, height - (int)vCut.Y);
                }
                                      
                //Always draw the tile at least once
                sb.Draw(texture, destCut, leftCut, Color.White);


                if (layer.TileX)
                {
                    for (int j = 1; j < tilesXCount; j++)
                    {
                        Vector2 v = new Vector2((j * width) - vCut.X, (int)layer.Offset.Y + Camera.ViewPort.Y);
                        sb.Draw(texture, v, Color.White);
                    }
                }
                else if (layer.TileY)
                {
                    for (int j = 1; j < tilesYCount; j++)
                    {
                        Vector2 v = new Vector2((int)layer.Offset.X + Camera.ViewPort.X, (j * height) - vCut.Y);
                        sb.Draw(texture, v, Color.White);
                    }
                }

                Rectangle right = new Rectangle() ;
                Rectangle destRightCut = new Rectangle();

                //Add the last one on but trim it.
                if (layer.TileX)
                {
                    right = new Rectangle(0, 0, (int) vEdge.X, height);
                    destRightCut = new Rectangle((tilesXCount * width) - (int)vCut.X, (int)layer.Offset.Y + Camera.ViewPort.Y, (int)vEdge.X, height);
                }
                else if (layer.TileY)
                {
                    right = new Rectangle(0, 0, width, (int)vEdge.Y);
                    destRightCut = new Rectangle((int)layer.Offset.X + Camera.ViewPort.X, (tilesYCount * height) - (int)vCut.Y, width, (int)vEdge.Y);
                }

                sb.Draw(texture, destRightCut, right, Color.White);                    
            }

            sb.End();


            sb.Dispose();

            base.Draw();
        }
    }

   

}


    
