using HSEBuildings.Data.ResponseTemplates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
using System.Windows.Shapes;

namespace HSEBuildings.UI
{
    /// <summary>
    /// Interaction logic for SimpleWindow.xaml
    /// </summary>
    public partial class SimpleWindow : Window
    {
        int i;
        List<RoomWay> list;
        public SimpleWindow(List<RoomWay> spisok)
        {
            InitializeComponent();
            //i = spisok.Count();
            list = spisok;
            image.Source = new BitmapImage(new Uri(String.Format("Resources/{0}",list[0].link), UriKind.Relative));
            i = 1;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (i == list.Count - 1)
            {
                button.Content = "Конец!";
            }
            if (i < list.Count)
            {
                image.Source = new BitmapImage(new Uri(String.Format("Resources/{0}", list[i].link), UriKind.Relative));
                i++;
            }else
            {
                Close();
            }
        }
    }
}
