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

namespace Курсовой_проект
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {

        public Admin(int idAd)
        {
            InitializeComponent();
            Пользователь autUser = null;
            Manager.MainFrame = TexMain;
            using (SkladEntities context = new SkladEntities())
            {
                autUser = context.Пользователь.Where(b => b.Id ==
                idAd).FirstOrDefault();
            }
            TX_Name.Text = autUser.Фамилия;
            TX_Name1.Text = autUser.Имя;
        }

        private void btnContr_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPage2());
            TX_2.Text = "База Данных Контрагентов";
        }

      

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPage());
            TX_2.Text = "База Данных Пользователей";
        }

        private void btnSklad_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminPage1());
            TX_2.Text = "База Данных Склада";
        }
    }
}
