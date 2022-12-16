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
using Syncfusion.UI.Xaml.Diagram.Layout;

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

            // Initialize DataSourceSettings for SfDiagram
            Diagram.DataSourceSettings = new DataSourceSettings()
            {
                Id = "EmployeeId",
                ParentId = "ParentId",
                Root = "1",
                DataSource = GetData(),
            };
            // Initialize layout manager for SfDiagram
            Diagram.LayoutManager = new Syncfusion.UI.Xaml.Diagram.Layout.LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    HorizontalSpacing = 80,
                    VerticalSpacing = 50,
                    SpaceBetweenSubTrees = 20,
                    Orientation = TreeOrientation.TopToBottom,
                }
            };
        }

        // Method to initialize the value for DataSource
        private Employees GetData()
        {
            Employees employees = new Employees();

            employees.Add(new Employee()
            {
                Name = "Steve",
                EmployeeId = "1",
                ParentId = "",
                Designation = "CEO"
            });
            employees.Add(new Employee()
            {
                Name = "Kevin",
                EmployeeId = "2",
                ParentId = "1",
                Designation = "Manager"
            });
            employees.Add(new Employee()
            {
                Name = "John",
                EmployeeId = "3",
                ParentId = "1",
                Designation = "Manager"
            });
            employees.Add(new Employee()
            {
                Name = "Raj",
                EmployeeId = "4",
                ParentId = "2",
                Designation = "Team Lead"
            });
            employees.Add(new Employee()
            {
                Name = "Will",
                EmployeeId = "5",
                ParentId = "2",
                Designation = "S/w Developer"
            });
            employees.Add(new Employee()
            {
                Name = "Sarah",
                EmployeeId = "6",
                ParentId = "3",
                Designation = "TeamLead"
            });
            employees.Add(new Employee()
            {
                Name = "Mike",
                EmployeeId = "7",
                ParentId = "3",
                Designation = "Testing Engineer"
            });

            return employees;
        }
    }

    /// <summary>
    /// Business object class for creating datasource
    /// </summary>
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
 