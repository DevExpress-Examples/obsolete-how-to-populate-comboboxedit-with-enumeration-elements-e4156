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
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Windows

Namespace ComboBoxEditEnum
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>
	Partial Public Class App
		Inherits Application
	End Class
End Namespace
