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
    /// Логика взаимодействия для PageTechmologist.xaml
    /// </summary>
    public partial class PageTechmologist : Page
    {
        public ObservableCollection<Техкарта> ListTechCard;
        public static SkladEntities DataEntitiesTechCard { get; set; }
        public PageTechmologist()
        {
            InitializeComponent();
            DataEntitiesTechCard = new SkladEntities();
            ListTechCard = new ObservableCollection<Техкарта>();
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
            var queryTehcCard = from tech in DataEntitiesTechCard.Техкарта
                                select tech;
            foreach (var priemki in queryTehcCard)
            {
                ListTechCard.Add(priemki);
            }
            DataGridTehcCard.ItemsSource = ListTechCard;
                      
        }
        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var client = DataGridTehcCard.SelectedItems.Cast<Контрагент>().ToList();
            if (client != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные ", "Предупреждение", MessageBoxButton.OKCancel); ;
                if (result == MessageBoxResult.OK)
                {
                    DataEntitiesTechCard.Контрагент.RemoveRange(client);
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
            DataGridTehcCard.IsReadOnly = true;
            isDirty = true;

        }
        private void EditCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridTehcCard.IsReadOnly = false;
            DataGridTehcCard.BeginEdit();
            isDirty = true;
            MessageBox.Show("Редактировать");
        }
        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Создаем новое");
            Техкарта ведомость = new Техкарта(-1, 0, 0, 0);
            try
            {
                DataEntitiesTechCard.Техкарта.Add(ведомость);
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
            DataGridTehcCard.IsReadOnly = true;
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridTehcCard.SelectedIndex = 0;
            GetTechCard();
        }

        private void btnFindMat_Click(object sender, RoutedEventArgs e)
        {
            if (MatCombobox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали Параметр для поиска (Материал)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DataEntitiesTechCard = new SkladEntities();
                ListTechCard.Clear();
                Товар mat = MatCombobox.SelectedItem as Товар;
                var queryEmployee = from Emloyee in DataEntitiesTechCard.Техкарта
                                    where Emloyee.Материал == mat.Id
                                    orderby Emloyee.Id
                                    select Emloyee;
                foreach (Техкарта emp in queryEmployee)
                {
                    ListTechCard.Add(emp);
                }
                if (ListTechCard.Count == 0)
                {
                    MessageBox.Show("Записи не найдены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    RewriteTechCard();
                }
                else
                {
                    DataGridTehcCard.ItemsSource = ListTechCard;
                }
            }

        }

        private void btnFindProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductCombobox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали Параметр для поиска (Готовую продукцию)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DataEntitiesTechCard = new SkladEntities();
                ListTechCard.Clear();
                Товар mat = ProductCombobox.SelectedItem as Товар;
                var queryEmployee = from Emloyee in DataEntitiesTechCard.Техкарта
                                    where Emloyee.Готовая_продукция == mat.Id
                                    orderby Emloyee.Id
                                    select Emloyee;
                foreach (Техкарта emp in queryEmployee)
                {
                    ListTechCard.Add(emp);
                }
                if (ListTechCard.Count == 0)
                {
                    MessageBox.Show("Записи не найдены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    RewriteTechCard();
                }
                else
                {
                    DataGridTehcCard.ItemsSource = ListTechCard;
                }
            }
        }

        private void DataGridPriemka_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridTehcCard.SelectedIndex = 0;
            GetTechCard();
        }
    }
}
