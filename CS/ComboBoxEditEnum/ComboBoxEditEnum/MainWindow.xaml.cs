using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors;
using System.ComponentModel;

namespace ComboBoxEditEnum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ObservableCollection<TaskPriority> collection = new ObservableCollection<TaskPriority>();
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public enum TaskPriority 
    {
        [Description("Low")]
        LOW,
        MEDIUM,
        HIGH 
    }

    [Flags]
    public enum Actions
    {
        [Description("Eat!")]
        Eat,
        Sleep,
        [Description("Code!")]
        Code
    }
}
