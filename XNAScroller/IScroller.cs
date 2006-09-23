using System;
using System.Collections.Generic;
using System.Text;

namespace XNAParalax.XNAScroller
{
    /// <summary>
    /// The IScroller interface is a generic interface that helps in the creation and managament of Scroller Components
    /// </summary>
    public interface IScroller
    {
        float Offset
        {
            get;
            set;
        }             
    }
}
