using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace XNAParallax.Utils
{
    public static class TypeConverterRegistration
    {
        public static void Register<T, TC>() where TC: TypeConverter
        {
            Attribute[] attr = new Attribute[1];
            TypeConverterAttribute vConv = new TypeConverterAttribute(typeof(TC));
            attr[0] = vConv;
            TypeDescriptor.AddAttributes(typeof(T), attr);
        }
    }
}
