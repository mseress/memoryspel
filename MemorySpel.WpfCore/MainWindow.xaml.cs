using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemorySpel.WpfCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int NumberOfRows { get; set; }

        public int NumberOfColumns { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.NumberOfRows = 5;
            this.NumberOfColumns = 5;
            this.AddCards();
        }

        private void AddCards()
        {
            this.SetupMainGrid();
            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    throw new NotImplementedException();
                }
            }
        }

        private void SetupMainGrid()
        {
            throw new NotImplementedException();
        }
    }
}
