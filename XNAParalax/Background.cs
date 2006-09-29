using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAParalax.XNATypeConverters;
using XNAParalax.XNAScroller;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Diagnostics;

namespace XNAParalax
{
    /// <summary>
    /// The Paralax Background Component.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ParalaxBackground.LayerConverter))]
    public class ParalaxBackground
    {
        private string m_textureFile;
        [NonSerialized]
        private Vector2 m_Offset;
        private bool mTileX;
        private bool mTileY;
        private IScroller mXScrollerComponent;
        private IScroller mYScrollerComponent;

        /// <summary>
        /// The offset of the texture.
        /// </summary>
        [TypeConverter(typeof(Vector2Converter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]        
        public Vector2 Offset
        {
            get { return m_Offset; }
            set { m_Offset = value; }
        }	      

        /// <summary>
        /// The scroller that is used to modify the X Position.
        /// </summary>            
        public IScroller XScrollerComponent
        {
            get { return mXScrollerComponent; }
            set { mXScrollerComponent = value; }
        }

        /// <summary>
        /// The scroller that is used to modify the Y-Position of the layer.
        /// </summary>       
        public IScroller YScrollerComponent
        {
            get { return mYScrollerComponent; }
            set { mYScrollerComponent = value; }
        }
	

        /// <summary>
        /// Should the Background Image be tiled in the Y-Axis
        /// </summary>
        public bool TileY
        {
            get { return mTileY; }
            set {
                if (value)
                {
                    mTileX = false;
                }
                mTileY = value; 
            }
        }

        /// <summary>
        /// Should the image be tiled in the X-Axis
        /// </summary>  
        public bool TileX
        {
            get { return mTileX; }
            set {
                if (value)
                {
                    mTileY = false;
                }
                mTileX = value; 
            }
        }

        /// <summary>
        /// The filename of the texture to load as the background.
        /// </summary>        
        public string FileName
        {
            get { return m_textureFile; }
            set { m_textureFile = value; }
        }

        [NonSerialized]
        private Texture2D m_texture;

        /// <summary>
        /// The Instance of the Background Texture.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
       public Texture2D BackGroundTexture
        {
           get { return m_texture; }
           set { m_texture = value; }
        }      

        public ParalaxBackground()
        {
            m_textureFile = "";
            mTileX = true;
            mTileY = false;
            m_Offset = new Vector2(0, 0);
            mXScrollerComponent = new NullScroller();
            mYScrollerComponent = new NullScroller();
        }

        public ParalaxBackground(string filename)
        {
            m_textureFile = filename;
            mTileX = true;
            mTileY = false;
            
            m_Offset = new Vector2(0, 0);
            mXScrollerComponent = new NullScroller();
            mYScrollerComponent = new NullScroller();
        }



        /// <summary>
        /// The Layer Converter is used to aid in design time serialization and thus allow easy access to editing of the layers.
        /// </summary>
        internal class LayerConverter : TypeConverter
        {
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
            {
                if (destType == typeof(InstanceDescriptor))
                    return true;
                return base.CanConvertTo(context, destType);
            }
            public override object ConvertTo(ITypeDescriptorContext context,
                System.Globalization.CultureInfo culture, object value, Type destType)
            {
                if (destType == typeof(InstanceDescriptor))
                {
                    System.Reflection.ConstructorInfo ci =
                        typeof(ParalaxBackground).GetConstructor(
                        System.Type.EmptyTypes);
                    return new InstanceDescriptor(ci, null, false);
                }
                return base.ConvertTo(context, culture, value, destType);
            }
        }
    }  
}
