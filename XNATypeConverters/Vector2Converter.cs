using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Diagnostics;
using System.IO;


namespace XNAParalax.XNATypeConverters
{

    public class Vector2Converter: ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(String))
                return true;

            return base.CanConvertFrom(context, sourceType);
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
                  
                if ( sValue.Length != 0 )
                {
                    sValue = sValue.Replace("{","");
                    sValue = sValue.Replace("}","");
                    
                    // Parse the string
                    if ( null == culture )
                        culture = CultureInfo.CurrentCulture ;

                    // Split the string based on the cultures list separator
                    string[]    parms = sValue.Split ( new char[] { culture.TextInfo.ListSeparator[0] } ) ;

                    if ( parms.Length == 2 )
                    {
                        // Should have an integer and a string.
                        float x = Convert.ToSingle (parms[0]) ;
                        float y = Convert.ToSingle(parms[1]);

                        // And finally create the object
                        retVal = new Vector2 ( x , y ) ;
                    }
                }
            }
            else
                retVal = base.ConvertFrom ( context , culture , value ) ;

            return retVal ;
            
        }

        public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
        {
            return new Vector2((float) propertyValues["X"], (float) propertyValues["Y"]);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            else if (destinationType == typeof(string))
            {
                return true;
            }

            // Always call the base to see if it can perform the conversion.
            return base.CanConvertTo(context, destinationType);
        }


        // This code performs the actual conversion from a Triangle to an InstanceDescriptor.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            object returnValue = null;
            Vector2 v2 = (Vector2) value ;

            if (destinationType == typeof(InstanceDescriptor))
            {
                System.Type[] argTypes = new System.Type[2];

                argTypes[0] = typeof(float);
                argTypes[1] = typeof(float);

                // Lookup the appropriate Doofer constructor
                ConstructorInfo constructor = typeof(Vector2).GetConstructor(argTypes);

                object[] arguments = new object[2];

                arguments[0] = v2.X;
                arguments[1] = v2.Y;

                returnValue = new InstanceDescriptor(constructor, arguments);
            }
            else if (destinationType == typeof(string))
            {
                // If it's a string, return one to the caller
                if (null == culture)
                    culture = CultureInfo.CurrentCulture;

                string[] values = new string[2];

                // I'm a bit of a culture vulture - do it properly!
                TypeConverter numberConverter = TypeDescriptor.GetConverter(typeof(int));

                values[0] = v2.X.ToString();
                values[1] = v2.Y.ToString();

                // A useful method - join an array of strings using a separator, in this instance the culture specific one
                returnValue = "{" + String.Join(culture.TextInfo.ListSeparator + " ", values) + "}";
           
            }
            return returnValue;
        }


        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value, attributes);

            string[] sortOrder = new string[2];

            sortOrder[0] = "X";
            sortOrder[1] = "Y";

            // Return a sorted list of properties
            return properties.Sort(sortOrder);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }    
}
