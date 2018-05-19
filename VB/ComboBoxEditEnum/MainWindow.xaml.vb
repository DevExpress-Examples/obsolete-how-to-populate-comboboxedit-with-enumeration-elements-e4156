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
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Editors.Settings
Imports DevExpress.Xpf.Editors
Imports System.ComponentModel

Namespace ComboBoxEditEnum
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		'ObservableCollection<TaskPriority> collection = new ObservableCollection<TaskPriority>();
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Enum TaskPriority
		<Description("Low")> _
		LOW
		MEDIUM
		HIGH
	End Enum

	<Flags> _
	Public Enum Actions
		<Description("Eat!")> _
		Eat
		Sleep
		<Description("Code!")> _
		Code
	End Enum
End Namespace
