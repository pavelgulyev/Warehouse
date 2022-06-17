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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсовой_проект
{
    /// <summary>
    /// Логика взаимодействия для PriemkaPage.xaml
    /// </summary>
    public partial class PriemkaPage : Page
    {
        public ObservableCollection<Ведомость_прихода_на_склад> ListPriemok;
        public static SkladEntities DataEntitiesPriemka { get; set; }
        public PriemkaPage()
        {
            InitializeComponent();
            DataEntitiesPriemka = new SkladEntities();
            ListPriemok = new ObservableCollection<Ведомость_прихода_на_склад>();
            DoubleAnimation btnAnimationWidth = new DoubleAnimation();
            btnAnimationWidth.From = 0;
            btnAnimationWidth.To = 200;
            btnAnimationWidth.Duration = TimeSpan.FromSeconds(2);
            btnFindContr.BeginAnimation(Button.WidthProperty, btnAnimationWidth);
            btnFindDate.BeginAnimation(Button.WidthProperty, btnAnimationWidth);
            DoubleAnimation btnAnimationHeight = new DoubleAnimation();
            btnAnimationHeight.From = 0;
            btnAnimationHeight.To = 30;
            btnAnimationHeight.Duration = TimeSpan.FromSeconds(2);
            btnFindContr.BeginAnimation(Button.HeightProperty, btnAnimationHeight);
            btnFindDate.BeginAnimation(Button.HeightProperty, btnAnimationHeight);
        }
        private bool isDirty = true;
        private void RewritePriemka()
        {
            DataEntitiesPriemka = new SkladEntities();
            ListPriemok.Clear();
            GetPriemki();
        }
        private void GetPriemki()
        {
            var queryPriemok = from priemki in DataEntitiesPriemka.Ведомость_прихода_на_склад                                                              
                               select priemki;
            
            foreach (var priemki in queryPriemok)
            {
                ListPriemok.Add(priemki);
            }
            DataGridPriemka.ItemsSource = ListPriemok;
            
        }
        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var client = DataGridPriemka.SelectedItems.Cast<Контрагент>().ToList();
            if (client != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные ", "Предупреждение", MessageBoxButton.OKCancel); ;
                if (result == MessageBoxResult.OK)
                {
                    DataEntitiesPriemka.Контрагент.RemoveRange(client);
                    DataEntitiesPriemka.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    RewritePriemka();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RewritePriemka();
            DataGridPriemka.IsReadOnly = true;
            isDirty = true;
            
        }
        private void EditCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridPriemka.IsReadOnly = false;
            DataGridPriemka.BeginEdit();
            isDirty = true;
            MessageBox.Show("Редактировать");
        }
        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            MessageBox.Show("Создаем новое");
            Ведомость_прихода_на_склад ведомость = new Ведомость_прихода_на_склад(-1, DateTime.Now, 0,0,0,0,0);
            try
            {
                DataEntitiesPriemka.Ведомость_прихода_на_склад.Add(ведомость);
                ListPriemok.Add(ведомость);
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
            DataEntitiesPriemka.SaveChanges();
            MessageBox.Show("Сохранияем");
            DataGridPriemka.IsReadOnly = true;
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
            DataGridPriemka.SelectedIndex = 0;
            GetPriemki();
        }

        private void btnFindContr_Click(object sender, RoutedEventArgs e)
        {
            if (kontrCombobox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали Параметр для поиска (Контрагента)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DataEntitiesPriemka = new SkladEntities();
                ListPriemok.Clear();
                Контрагент title = kontrCombobox.SelectedItem as Контрагент;
                var queryEmployee = from Emloyee in DataEntitiesPriemka.Ведомость_прихода_на_склад
                                    where Emloyee.Контрагент == title.Id
                                    orderby Emloyee.Id
                                    select Emloyee;
                foreach (Ведомость_прихода_на_склад emp in queryEmployee)
                {
                    ListPriemok.Add(emp);
                }
                if (ListPriemok.Count == 0)
                {
                    MessageBox.Show("Записи не найдены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    RewritePriemka();
                }
                else
                {
                    DataGridPriemka.ItemsSource = ListPriemok;
                }
            }
        }
        private void btnFindDate_Click(object sender, RoutedEventArgs e)
        {
            DataEntitiesPriemka = new SkladEntities();
            ListPriemok.Clear();
            var queryEmployee = from Emloyee in DataEntitiesPriemka.Ведомость_прихода_на_склад
                                where Emloyee.Дата == FindDate.SelectedDate
                                orderby Emloyee.Id
                                select Emloyee;
            foreach (Ведомость_прихода_на_склад emp in queryEmployee)
            {
                ListPriemok.Add(emp);
            }
            if (ListPriemok.Count == 0)
            {
                MessageBox.Show("Записи не найдены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                RewritePriemka();
            }
            else
            {
                DataGridPriemka.ItemsSource = ListPriemok;
            }
        }
    }
}
