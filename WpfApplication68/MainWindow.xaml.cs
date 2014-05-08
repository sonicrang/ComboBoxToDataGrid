using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApplication68
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<Component> lstComponent;

        public List<Component> LstComponent
        {
            get { return lstComponent; }
            set
            {
                lstComponent = value;
                OnPropertyChanged("LstComponent");
            }
        }

        private List<LotInformation> lstLot;

        public List<LotInformation> LstLot
        {
            get { return lstLot; }
            set
            {
                lstLot = value;
                OnPropertyChanged("LstLot");
            }
        }

        private LotInformation selectedLot;

        public LotInformation SelectedLot
        {
            get { return selectedLot; }
            set
            {
                selectedLot = value;
                var lot = value as LotInformation;
                if(lot != null)
                {
                    LstComponent = lstDataContext.Where(l => l.Num == lot.Num).ToList();
                }
            }
        }

        private List<Component> lstDataContext = new List<Component>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            SetData();
        }

        private void SetData()
        {
            LstLot = new List<LotInformation>();
            for (int i = 0; i < 10; i++)
            {
                LotInformation lot = new LotInformation();
                lot.Num = i;
                LstLot.Add(lot);

                for (int j = 0; j < 5; j++)
                {
                    Component c = new Component();
                    c.Num = lot.Num;
                    c.Name = j.ToString();
                    lstDataContext.Add(c);
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
