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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
namespace Курсовой_проект
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Пользователь> ListUser;
        public static SkladEntities DataEntitiesUser { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ListUser = new ObservableCollection<Пользователь>();
            DataEntitiesUser = new SkladEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Login.Text) && !string.IsNullOrEmpty(Password.Password))
            {
                var queryUser = from user in DataEntitiesUser.Пользователь
                                where (Login.Text==user.Логин) && (Password.Password==user.Пароль)
                                select user;
                foreach (Пользователь client in queryUser)
                {
                    ListUser.Add(client);
                }
                if (ListUser.Count == 0 || ListUser.Count > 1)
                {
                    MessageBox.Show("Неверный логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Успешно прошла авторизация", "Поздравляю", MessageBoxButton.OK, MessageBoxImage.None);
                    switch (ListUser[0].Право_доступа)
                    {
                        case 1:
                            Storekeeper storekeeper = new Storekeeper(ListUser[0].Id);
                            storekeeper.Show();
                            this.Close();
                            break;
                        case 2:
                            Technologist tech = new Technologist(ListUser[0].Id);
                            tech.Show();
                            this.Close();
                            break;
                        case 3:
                            Admin admin = new Admin(ListUser[0].Id);
                            admin.Show();
                            this.Close();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
