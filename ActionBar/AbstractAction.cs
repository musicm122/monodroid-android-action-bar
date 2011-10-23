    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ActionBar
{
    public abstract class BaseAction:Action
    {
       
        public BaseAction(int drawable) 
        {
            this.mDrawable= drawable;
        }

        public int  GetDrawable()
        {
            return this.mDrawable;
        }

        public void  PerformAction(View view)
        {
 	        throw new NotImplementedException();
        }
}
}