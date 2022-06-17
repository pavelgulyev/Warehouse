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
    /// Логика взаимодействия для PageTechmologist1.xaml
    /// </summary>
    public partial class PageTechmologist1 : Page
    {
        public ObservableCollection<ТехЗадание> ListTechCard;
        public static SkladEntities DataEntitiesTechCard { get; set; }
        public PageTechmologist1()
        {
            InitializeComponent();
            DataEntitiesTechCard = new SkladEntities();
            ListTechCard = new ObservableCollection<ТехЗадание>();
        }

        private void btnFindMat_Click(object sender, RoutedEventArgs e)
        {

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
            var queryTehcCard = from tech in DataEntitiesTechCard.ТехЗадание
                                select tech;
            foreach (var priemki in queryTehcCard)
            {
                ListTechCard.Add(priemki);
            }
            DataGridTehcCard.ItemsSource = ListTechCard;

        }
        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var client = DataGridTehcCard.SelectedItems.Cast<ТехЗадание>().ToList();
            if (client != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные ", "Предупреждение", MessageBoxButton.OKCancel); ;
                if (result == MessageBoxResult.OK)
                {
                    DataEntitiesTechCard.ТехЗадание.RemoveRange(client);
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
            ТехЗадание ведомость = new ТехЗадание(-1, 0, 0, 0);
            try
            {
                DataEntitiesTechCard.ТехЗадание.Add(ведомость);
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
        private void btnFindSkladMat_Click(object sender, RoutedEventArgs e)
        {
           
            if (MatSkladCombobox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали Параметр для поиска (Склад для материала)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            { 
                DataEntitiesTechCard = new SkladEntities();
                ListTechCard.Clear();
                Склад mat = MatSkladCombobox.SelectedItem as Склад;
                var queryEmployee = from Emloyee in DataEntitiesTechCard.ТехЗадание
                                    where Emloyee.Склад_материала == mat.Id
                                    orderby Emloyee.Id
                                    select Emloyee;
                foreach (ТехЗадание emp in queryEmployee)
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

        private void btnFindSkladProduct_Click(object sender, RoutedEventArgs e)
        {
            DataEntitiesTechCard = new SkladEntities();
            ListTechCard.Clear();
            Склад mat = ProductSkladCombobox.SelectedItem as Склад;
            var queryEmployee = from Emloyee in DataEntitiesTechCard.ТехЗадание
                                where Emloyee.Склад_для_продукции == mat.Id
                                orderby Emloyee.Id
                                select Emloyee;
            foreach (ТехЗадание emp in queryEmployee)
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
}
