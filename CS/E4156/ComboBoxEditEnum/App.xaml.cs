// Developer Express Code Central Example:
// How to populate ComboBoxEditor with enumeration elements.
// 
// This example demonstrates how to populate ComboBoxEditor with enumeration
// elements. All logic is encapsulated in the BaseComboBoxStyleSettings descendant
// which is defined in the MyComboBoxStyleSettings.cs(vb) file. The representation
// of items in the popup window depends on the enumeration items kind. E.g., if
// enumeration items have description attributes they will display the description
// text instead of item names. If the enumeration definition is decorated with the
// FlagsAttribute attribute, items will be represented as check editors with the
// TextBlock element used as description.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4156

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ComboBoxEditEnum
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }
}
