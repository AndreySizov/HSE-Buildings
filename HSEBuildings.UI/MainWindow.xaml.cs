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

            //using (var c = new Context())
            //{
            //    //c.Campus.ToList();
            //    c.Campus.AddRange(repo.Campuses);
            //    c.Flor.AddRange(repo.Flors);
            //    c.Room.AddRange(repo.Rooms);
            //    c.Photo.AddRange(repo.Photos);
            //    c.SaveChanges();
            //}

            //string room = "505";
            //var res1 = repo.getLocation(loc);
            //foreach (var item in res1)
            //{
            //    Console.WriteLine(item.Latitude + " " + item.Longitude);
            //}
            //var res2 = repo.getPhotoSet(room);
            //foreach (var item in res2)
            //{
            //    Console.WriteLine(item.link);
            //}
            //var res3 = repo.getAllCampuses();
            //foreach (var item in res3)
            //{
            //    Console.WriteLine(item.Name + " " + item.Longitude + " " + item.Latitude + " " + item.CampusPhoto);
            //}

            InitializeComponent();
            System.Timers.Timer t = new System.Timers.Timer(); 
            t.Interval = 2500;
            t.Start();
            t.AutoReset = false;
            t.Elapsed += new System.Timers.ElapsedEventHandler(timer_Tick);

        }
        void timer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(delegate { Close(); }));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var form = new Map();
            form.ShowDialog();
        }
    }
}
