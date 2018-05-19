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
using System.Linq;
using System.Text;
using DevExpress.Xpf.Editors;
using System.Windows;
using DevExpress.Xpf.Editors.Themes;
using DevExpress.Xpf.Editors.Helpers;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Core;
using System.Windows.Controls;
using DevExpress.Xpf.Editors.Popups;
using System.Windows.Data;
using DevExpress.Xpf.Editors.Internal;

namespace ComboBoxEditEnum
{
    class MyComboBoxStyleSettings : BaseComboBoxStyleSettings
    {
        public Type EnumType
        {
            get;
            set;
        }
        public override void ApplyToEdit(BaseEdit editor)
        {
            base.ApplyToEdit(editor);
            LookUpEditBase cb = editor as LookUpEditBase;
            cb.ItemsSource = EnumHelper.GetEnumSource(EnumType, false);
            cb.ItemTemplate = (DataTemplate)Application.Current.FindResource("whithAttributeItemTemplate");
            cb.DisplayTextConverter = (IValueConverter)Application.Current.FindResource("myConverter");
        }
        protected override Style GetItemContainerStyle(LookUpEditBase cb)
        {
            if (HasFlagsAttribute())
                return (Style)cb.FindResource(new EditorListBoxThemeKeyExtension() { ResourceKey = EditorListBoxThemeKeys.CheckBoxItemStyle, ThemeName = ThemeHelper.GetEditorThemeName(cb) });
            return (Style)cb.FindResource(new EditorListBoxThemeKeyExtension() { ResourceKey = EditorListBoxThemeKeys.DefaultItemStyle, ThemeName = ThemeHelper.GetEditorThemeName(cb) });
        }

        protected override SelectionMode SelectionMode
        {
            get
            {
                if (HasFlagsAttribute())
                    return SelectionMode.Multiple;
                return SelectionMode.Single;
            }
        }
        protected override bool CloseOnMouseUp
        {
            get { return !HasFlagsAttribute(); }
        }
        protected override bool ShowCustomItem(LookUpEditBase editor)
        {
            return HasFlagsAttribute();
        }

        protected override SelectionEventMode GetSelectionEventMode(ISelectorEdit ce)
        {
            if (HasFlagsAttribute())
                return SelectionEventMode.MouseUp;
            if (!((LookUpEditBase)ce).AllowItemHighlighting)
                return SelectionEventMode.MouseDown;
            return SelectionEventMode.MouseEnter;
        }
        public override PopupFooterButtons GetPopupFooterButtons(PopupBaseEdit editor)
        {
            if (HasFlagsAttribute())
                return PopupFooterButtons.OkCancel;
            return PopupFooterButtons.None;
        }
        bool HasFlagsAttribute()
        {
            FlagsAttribute[] fa = (FlagsAttribute[])EnumType.GetCustomAttributes(typeof(FlagsAttribute), true);
            int c = fa.Count();
            if (c == 0)
                return false;
            return true;
        }
    }
}
