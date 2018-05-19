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
Imports System.Windows.Data
Imports System.Globalization
Imports System.ComponentModel
Imports System.Reflection

Namespace ComboBoxEditEnum
	Public Class MyConverter
		Implements IValueConverter

		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			If value Is Nothing Then
				Return value
			End If
			Dim EnVal As DevExpress.Xpf.Core.EnumHelper.EnumItem = TryCast(value, DevExpress.Xpf.Core.EnumHelper.EnumItem)
			Dim fi2 As FieldInfo = EnVal.Id.GetType().GetField(EnVal.Id.ToString())
			Dim attrs() As DescriptionAttribute = CType(fi2.GetCustomAttributes(GetType(DescriptionAttribute), True), DescriptionAttribute())
			If attrs.Count() = 0 Then
				Return value
			End If
			Return attrs(0).Description
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return value
		End Function
	End Class
End Namespace
