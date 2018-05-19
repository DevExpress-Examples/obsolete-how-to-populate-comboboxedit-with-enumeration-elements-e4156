' Developer Express Code Central Example:
' How to populate ComboBoxEditor with enumeration elements.
' 
' This example demonstrates how to populate ComboBoxEditor with enumeration
' elements. All logic is encapsulated in the BaseComboBoxStyleSettings descendant
' which is defined in the MyComboBoxStyleSettings.cs(vb) file. The representation
' of items in the popup window depends on the enumeration items kind. E.g., if
' enumeration items have description attributes they will display the description
' text instead of item names. If the enumeration definition is decorated with the
' FlagsAttribute attribute, items will be represented as check editors with the
' TextBlock element used as description.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4156


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Editors
Imports System.Windows
Imports DevExpress.Xpf.Editors.Themes
Imports DevExpress.Xpf.Editors.Helpers
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Core
Imports System.Windows.Controls
Imports DevExpress.Xpf.Editors.Popups
Imports System.Windows.Data
Imports DevExpress.Xpf.Editors.Internal

Namespace ComboBoxEditEnum
	Friend Class MyComboBoxStyleSettings
		Inherits BaseComboBoxStyleSettings
		Public Property EnumType() As Type
		Public Overrides Sub ApplyToEdit(ByVal editor As BaseEdit)
			MyBase.ApplyToEdit(editor)
			Dim cb As LookUpEditBase = TryCast(editor, LookUpEditBase)
			cb.ItemsSource = EnumHelper.GetEnumSource(EnumType, False)
			cb.ItemTemplate = CType(Application.Current.FindResource("whithAttributeItemTemplate"), DataTemplate)
			cb.DisplayTextConverter = CType(Application.Current.FindResource("myConverter"), IValueConverter)
		End Sub
		Protected Overrides Function GetItemContainerStyle(ByVal cb As LookUpEditBase) As Style
			If HasFlagsAttribute() Then
				Return CType(cb.FindResource(New EditorListBoxThemeKeyExtension() With {.ResourceKey = EditorListBoxThemeKeys.CheckBoxItemStyle, .ThemeName = ThemeHelper.GetEditorThemeName(cb)}), Style)
			End If
			Return CType(cb.FindResource(New EditorListBoxThemeKeyExtension() With {.ResourceKey = EditorListBoxThemeKeys.DefaultItemStyle, .ThemeName = ThemeHelper.GetEditorThemeName(cb)}), Style)
		End Function

		Protected Overrides ReadOnly Property SelectionMode() As SelectionMode
			Get
				If HasFlagsAttribute() Then
					Return SelectionMode.Multiple
				End If
				Return SelectionMode.Single
			End Get
		End Property
		Protected Overrides ReadOnly Property CloseOnMouseUp() As Boolean
			Get
				Return Not HasFlagsAttribute()
			End Get
		End Property
		Protected Overrides Function ShowCustomItem(ByVal editor As LookUpEditBase) As Boolean
			Return HasFlagsAttribute()
		End Function

		Protected Overrides Function GetSelectionEventMode(ByVal ce As ISelectorEdit) As SelectionEventMode
			If HasFlagsAttribute() Then
				Return SelectionEventMode.MouseUp
			End If
			If Not(CType(ce, LookUpEditBase)).AllowItemHighlighting Then
				Return SelectionEventMode.MouseDown
			End If
			Return SelectionEventMode.MouseEnter
		End Function
		Public Overrides Function GetPopupFooterButtons(ByVal editor As PopupBaseEdit) As PopupFooterButtons
			If HasFlagsAttribute() Then
				Return PopupFooterButtons.OkCancel
			End If
			Return PopupFooterButtons.None
		End Function
		Private Function HasFlagsAttribute() As Boolean
			Dim fa() As FlagsAttribute = CType(EnumType.GetCustomAttributes(GetType(FlagsAttribute), True), FlagsAttribute())
			Dim c As Integer = fa.Count()
			If c = 0 Then
				Return False
			End If
			Return True
		End Function
	End Class
End Namespace
