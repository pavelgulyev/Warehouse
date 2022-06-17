using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Services.Client;
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

namespace Курсовой_проект
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public ObservableCollection<Пользователь> ListTechCard;
        public static SkladEntities DataEntitiesTechCard { get; set; }
        public AdminPage()
        {
            InitializeComponent();
            DataEntitiesTechCard = new SkladEntities();
            ListTechCard = new ObservableCollection<Пользователь>();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridUser.SelectedIndex = 0;
            GetTechCard();
        }
        private bool isDirty = true;
        private void RewriteTechCard()
        {
            DataEntitiesTechCard = new SkladEntities();
            ListTechCard.Clear();
            GetTechCard();
        }
        private void GetTechCard()
        {
            var queryTehcCard = from tech in DataEntitiesTechCard.Пользователь
                                select tech;
            foreach (var priemki in queryTehcCard)
            {
                ListTechCard.Add(priemki);
            }
            DataGridUser.ItemsSource = ListTechCard;

        }
        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var client = DataGridUser.SelectedItems.Cast<Пользователь>().ToList();
            if (client != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные ", "Предупреждение", MessageBoxButton.OKCancel); ;
                if (result == MessageBoxResult.OK)
                {
                    DataEntitiesTechCard.Пользователь.RemoveRange(client);                    
                    DataEntitiesTechCard.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    RewriteTechCard();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RewriteTechCard();
            DataGridUser.IsReadOnly = true;
            isDirty = true;

        }
        private void EditCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridUser.IsReadOnly = false;
            DataGridUser.BeginEdit();
            isDirty = true;
            MessageBox.Show("Редактировать");
        }
        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Создаем новое");
            Пользователь ведомость = new Пользователь(-1, "no", "no", "no", "no", "no",0);
            try
            {
                DataEntitiesTechCard.Пользователь.Add(ведомость);
                ListTechCard.Add(ведомость);
                isDirty = true;
            }
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException(
               "Ошибка добавления данных" + ex.ToString());
            }
        }
        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataEntitiesTechCard.SaveChanges();
            MessageBox.Show("Сохранияем");
            DataGridUser.IsReadOnly = true;
        }
        private void UndoCommandBinding_CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void FindCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void EditCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void DeleteCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void SaveCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void NewCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

       
        private void btnFindSurname_Click(object sender, RoutedEventArgs e)
        {
            if (txtSurname.Text == null)
            {
                MessageBox.Show("Введите фамилию",
                         "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string surname = txtSurname.Text;
                DataEntitiesTechCard = new SkladEntities();
                ListTechCard.Clear();
                var queryEmployee = from employee in DataEntitiesTechCard.Пользователь
                                    where employee.Фамилия.Contains(surname)
                                    select employee;
                foreach (Пользователь emp in queryEmployee)
                {
                    ListTechCard.Add(emp);
                }
                if (ListTechCard.Count > 0)
                {
                    DataGridUser.ItemsSource = ListTechCard;
                }
                else
                    MessageBox.Show("Пользователь с фамилией \n" + surname + "\n не найдан",
                         "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == null)
            {
                MessageBox.Show("Введите логин",
                         "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string login = Login.Text;
                DataEntitiesTechCard = new SkladEntities();
                ListTechCard.Clear();
                var queryEmployee = from employee in DataEntitiesTechCard.Пользователь
                                    where employee.Логин.Contains(login)
                                    select employee;
                foreach (Пользователь emp in queryEmployee)
                {
                    ListTechCard.Add(emp);
                }
                if (ListTechCard.Count > 0)
                {
                    DataGridUser.ItemsSource = ListTechCard;
                }
                else
                    MessageBox.Show("Пользователь с логином \n" + login + "\n не найдан",
                         "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
