using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Diagram;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Data_Source_Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
    public class Employee
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string EmployeeId { get; set; }
    }

    //Employee Collection
    public class Employees : ObservableCollection<Employee>
    {

    }

    public class CustomDiagram : SfDiagram
    {
        protected override object GetNewNode(Type desiredType)
        {
            return new NodeViewModel()
            {
                UnitHeight = 60,
                UnitWidth = 120,
            };
        }

        protected override object GetNewConnector(Type desiredType)
        {
            return new ConnectorViewModel()
            {
                TargetDecoratorStyle = App.Current.Resources["TargetDecoratorStyle"] as Style,
            };
        }
    }
}
