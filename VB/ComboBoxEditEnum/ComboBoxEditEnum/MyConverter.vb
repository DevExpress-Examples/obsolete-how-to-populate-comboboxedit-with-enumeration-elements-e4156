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
