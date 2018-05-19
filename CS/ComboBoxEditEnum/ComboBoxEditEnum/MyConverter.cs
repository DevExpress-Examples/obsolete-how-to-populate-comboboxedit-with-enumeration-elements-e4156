using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.ComponentModel;
using System.Reflection;

namespace ComboBoxEditEnum
{
    public class MyConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value;
            DevExpress.Xpf.Core.EnumHelper.EnumItem EnVal = value as DevExpress.Xpf.Core.EnumHelper.EnumItem;
            FieldInfo fi2 = EnVal.Id.GetType().GetField(EnVal.Id.ToString());
            DescriptionAttribute[] attrs = (DescriptionAttribute[])fi2.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs.Count() == 0)
                return value;
            return attrs[0].Description;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
