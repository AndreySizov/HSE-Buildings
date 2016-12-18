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
using System.Windows.Shapes;

namespace HSEBuildings.UI
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
            dBConnection();
            textBox.IsEnabled = false;
            comboBox.IsEnabled = false;
        }
        void dBConnection()
        {
            //image.Source = new BitmapImage(new Uri("Resources/placeholder.png", UriKind.Relative));
            comboBox.Items.Add("Библиотека");
            comboBox.Items.Add("Столовая");
            comboBox.Items.Add("Диспетчерская");
            comboBox.Items.Add("Камера хранения");
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                textBox.IsEnabled = true;
                checkBoxspecial.IsChecked = false;
                comboBox.IsEnabled = false;
                
            }else
            {
                textBox.IsEnabled = false;
                textBox.Clear();
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //textBox.Text = comboBox.SelectedItem.ToString();
        }

        private void checkBoxspecial_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxspecial.IsChecked == true)
            {
                comboBox.IsEnabled = true;
                checkBox.IsChecked = false;
                textBox.IsEnabled = false;
            }
            else
            {
                comboBox.IsEnabled = false;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string g = "";
            if (!String.IsNullOrEmpty(textBox.Text))
            {
                g = textBox.Text;
                Repository repo = new Repository();
                var res2 = repo.getPhotoSet(g);
                if (res2.Count != 0)
                {
                    Close();
                    SimpleWindow sw = new SimpleWindow(res2);
                    sw.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Такое место не найдено");
                }
            }
            else if((comboBox.SelectedItem != null)&&(checkBoxspecial.IsChecked != false))
            {
                g = comboBox.SelectedItem.ToString();
                
                Repository repo = new Repository();
                var res2 = repo.getPhotoSet(g);
                if (res2.Count != 0)
                {
                    Close();
                    SimpleWindow sw = new SimpleWindow(res2);
                    sw.ShowDialog();
                }else
                {
                    MessageBox.Show("Такое место не найдено");
                }
                
            }
            else
            {
                MessageBox.Show("Задайте поле для поиска!");
            }
        }
    }
}
