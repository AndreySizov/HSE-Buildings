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
        List<Data.ResponseTemplates.Section> section;
        bool b;
        public SimpleWindow(List<RoomWay> spisok,List<Data.ResponseTemplates.Section> sect)
        {
            InitializeComponent();
            //i = spisok.Count();
            list = spisok;
            section = sect;
            if(list.TrueForAll(x=> x.link != "1 1.jpg"))
            {
                b = false;
            }else
            {
                b = true;
            }
            image.Source = new BitmapImage(new Uri(String.Format("Resources/{0}",list[0].link), UriKind.Relative));
            i = 1;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (i == list.Count - 1)
            {
                button.Content = "Конец!";
                if (b==false)
                {
                    if((section[0].DirectionId == 1) || (section[0].DirectionId == 3))
                    {
                        MessageBox.Show("Если Вы выбрали левые лифты, то поверните направо. Если Вы выбрали правые лифты, то поверните налево.");
                    }
                    if ((section[0].DirectionId == 2) || (section[0].DirectionId == 4))
                    {
                        MessageBox.Show("Если Вы выбрали левые лифты, то поверните налево. Если Вы выбрали правые лифты, то поверните направо.");
                    }
                }else
                {
                    if ((section[0].DirectionId == 1) || (section[0].DirectionId == 3))
                    {
                        MessageBox.Show("Поверните налево.");
                    }
                    if ((section[0].DirectionId == 2) || (section[0].DirectionId == 4))
                    {
                        MessageBox.Show("Поверните направо.");
                    }
                }

            }
            if ((i == 3)&&(b==false))
            {
                    MessageBox.Show("Выберите сторону лифтов: левая или правая");

                
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
