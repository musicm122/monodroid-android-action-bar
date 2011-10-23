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
    public interface IAction
    {
        /**
     * Definition of an action that could be performed, along with a icon to
     * show.
     */
        public int GetDrawable();
        public void GerformAction(View view);
    }
}