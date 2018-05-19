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
