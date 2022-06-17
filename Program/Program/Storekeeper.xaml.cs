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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Курсовой_проект
{
    /// <summary>
    /// Логика взаимодействия для Storekeeper.xaml
    /// </summary>
    public partial class Storekeeper : Window
    {
        public ObservableCollection<Пользователь> ListUser;
        public static SkladEntities DataEntitiesUser { get; set; }
        public Storekeeper(int idKlad)
        {
            InitializeComponent();
            ListUser = new ObservableCollection<Пользователь>();
            DataEntitiesUser = new SkladEntities();
            Пользователь autUser = null;
            using (SkladEntities context = new SkladEntities())
            {
                autUser = context.Пользователь.Where(b => b.Id ==
                idKlad).FirstOrDefault();
            }
            TX_Name.Text = autUser.Фамилия;
            TX_Name1.Text = autUser.Имя;
        }
    }
}
