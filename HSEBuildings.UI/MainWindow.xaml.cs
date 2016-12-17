using HSEBuildings.Data;
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

namespace HSEBuildings.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            Repository repo = new Repository();
            
            using (var c = new Context()) {
                c.Campus.AddRange(repo.Campuses);
                c.Flor.AddRange(repo.Flors);
                c.Room.AddRange(repo.Rooms);
                c.Photo.AddRange(repo.Photos);
            }
            InitializeComponent();
            System.Timers.Timer t = new System.Timers.Timer(); 
            t.Interval = 2000;
            t.Start();
            t.AutoReset = false;
            t.Elapsed += new System.Timers.ElapsedEventHandler(timer_Tick);
            

        }
        void timer_Tick(object sender, EventArgs e)
        {
            var form = new Map();
            form.ShowDialog();

        }
    }
}
