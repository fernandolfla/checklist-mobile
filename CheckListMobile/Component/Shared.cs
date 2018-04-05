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
using CheckVTR.Entity;

namespace CheckListMobile.Component
{
    static class Shared
    {
        static Check check;



        public static void Set(Check checker)
        {
            check = checker;
        }

        public static Check Get()
        {
            return check;
        }

        public static bool Clean()
        {
            check = null;
            return true;
        }

    }
}