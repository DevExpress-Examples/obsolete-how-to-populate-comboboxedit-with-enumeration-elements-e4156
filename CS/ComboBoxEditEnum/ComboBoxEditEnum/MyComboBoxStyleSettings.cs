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
            if(HasFlagsAttribute())
                return (Style)cb.FindResource(new EditorListBoxThemeKeyExtension() { ResourceKey = EditorListBoxThemeKeys.CheckBoxItemStyle, ThemeName = ThemeHelper.GetEditorThemeName(cb) });
            return (Style)cb.FindResource(new EditorListBoxThemeKeyExtension() { ResourceKey = EditorListBoxThemeKeys.DefaultItemStyle, ThemeName = ThemeHelper.GetEditorThemeName(cb) });
        }

        protected override SelectionMode SelectionMode
        {
            get 
            {
                if(HasFlagsAttribute())
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
        protected override SelectionEventMode GetSelectionEventMode(LookUpEditBase ce)
        {
            if(HasFlagsAttribute())
                return SelectionEventMode.MouseUp;
            if (!ce.AllowItemHighlighting)
                return SelectionEventMode.MouseDown;
            return SelectionEventMode.MouseEnter;
        }
        public override PopupFooterButtons GetPopupFooterButtons(PopupBaseEdit editor) 
        {
            if(HasFlagsAttribute())
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
