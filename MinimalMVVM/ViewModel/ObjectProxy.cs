using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MinimalMVVM.ViewModel
{
    class ObjectProxy :DependencyObject
    {
        public object RefObject
        {
            get { return GetValue(RefObjectProperty); }
            set { SetValue(RefObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RefObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RefObjectProperty =
            DependencyProperty.Register("RefObject", typeof(object), typeof(ObjectProxy), new PropertyMetadata(null));


    }
}
