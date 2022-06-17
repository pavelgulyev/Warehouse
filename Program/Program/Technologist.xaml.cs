using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Курсовой_проект
{
    /// <summary>
    /// Логика взаимодействия для Technologist.xaml
    /// </summary>
    public partial class Technologist : Window
    {
        public ObservableCollection<Пользователь> ListUser;
        public static SkladEntities DataEntitiesUser { get; set; }
        public Technologist(int idTech)
        {
            InitializeComponent();
            Manager.MainFrame = TexMain;
            Пользователь autUser = null;
            using (SkladEntities context = new SkladEntities())
            {
                autUser = context.Пользователь.Where(b => b.Id ==
                idTech).FirstOrDefault();
            }
            TX_Name.Text = autUser.Фамилия;
            TX_Name1.Text = autUser.Имя;
        }
        private void btnTexcard_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageTechmologist());
            TX_2.Text = "База Данных Тех. Карт";
        }
        private void btnTexExample_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageTechmologist1());
            TX_2.Text = "База Данных Тех. Заданий";
        }
    }    
}

