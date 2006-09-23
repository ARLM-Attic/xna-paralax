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

namespace XNAParalax
{
    [Serializable]
    [TypeConverter(typeof(ParalaxBackground.LayerConverter))]
    public class ParalaxBackground
    {
        private string m_textureFile;
        private Vector2 m_Offset;
        private bool mTileX;
        private bool mTileY;
        private IScroller mXScrollerComponent;
        private IScroller mYScrollerComponent;

        [TypeConverter(typeof(Vector2Converter))]
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
	

        [DefaultValue("false")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

        [DefaultValue("true")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

        [DefaultValue("Test")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string FileName
        {
            get { return m_textureFile; }
            set { m_textureFile = value; }
        }

        [NonSerialized]
        private Texture2D m_texture;

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
            mTileX = false;
            mTileY = false;
        }

        public ParalaxBackground(string filename)
        {
            m_textureFile = filename;
            mTileX = true;
            mTileY = false;
            mXScrollerComponent = new NullScroller(); 
            mYScrollerComponent = new NullScroller(); 
            m_Offset = new Vector2(0, 100);
        }

        /// <summary>
        /// The Layer Converter is used to aid in design time serialization and thus allow easy access to editing of the layers.
        /// </summary>
        public class LayerConverter : ExpandableObjectConverter 
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string);
            }

            public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
            {
                return true;
            }

            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                string sValue = value as string;
                object retVal = null;
                
                if (sValue != null)
                {
                    sValue = sValue.Trim();

                    if (sValue.Length != 0)
                    {   
                        // And finally create the object
                        retVal = new ParalaxBackground(sValue);
                        
                    }
                }
                else
                    retVal = base.ConvertFrom(context, culture, value);

                return retVal;

            }

            public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
            {
                return new ParalaxBackground(propertyValues["FileName"] as string);
            }

            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(InstanceDescriptor))
                {
                    return true;
                }

                // Always call the base to see if it can perform the conversion.
                return base.CanConvertTo(context, destinationType);
            }


            // This code performs the actual conversion from a Triangle to an InstanceDescriptor.
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                ParalaxBackground v2 = (ParalaxBackground)value;

                if (destinationType == typeof(InstanceDescriptor))
                {
                    System.Type[] argTypes = new System.Type[1];

                    argTypes[0] = typeof(string);

                    // Lookup the appropriate Doofer constructor
                    ConstructorInfo constructor = typeof(ParalaxBackground).GetConstructor(argTypes);

                    object[] arguments = new object[1];

                    arguments[0] = v2.FileName;

                    return new InstanceDescriptor(constructor, arguments);
                }
                else if (destinationType == typeof(string))
                {
                    return v2.FileName;
                }

                // Always call base, even if you can't convert.
                return base.ConvertTo(context, culture, value, destinationType);
            }


            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value, attributes);
                
                // Return a sorted list of properties
                return properties;
            }

            public override bool GetPropertiesSupported(ITypeDescriptorContext context)
            {
                return true;
            }

        }
    }

}
