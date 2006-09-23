using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;


namespace XNAParalax.XNAScroller
{
    /// <summary>
    /// Sin Scroller is an oscilator.  It updates the offset based on a sin curve.
    /// </summary>
    [Serializable]
    public class SinScroller : GameComponent,IScroller
    {
        #region IScroller Members

        private float offset;
                
        public float Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        private double radiansPer = 2.0 * Math.PI;
        private double totalRadians = 0.0;

        #endregion

        public override void Update()
        {
            totalRadians +=  radiansPer * (Game.ElapsedTime.Milliseconds / 1000.0f);

            offset = (float)Math.Sin(totalRadians) * 1.0f;           
            base.Update();
        }

        public SinScroller()
        {
            offset = 0;
        }
    }
}
