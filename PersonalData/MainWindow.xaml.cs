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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonalData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            vm = new ViewModel();

            this.DataContext = vm;

            this.Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            addPerson.Click += AddPerson_Click;

            addPerson.MouseEnter += AddPerson_MouseEnter;
            addPerson.MouseLeave += AddPerson_MouseLeave;

            lb_persons.SelectionChanged += Lb_persons_SelectionChanged;

            deletePerson.Click += DeletePerson_Click;
            deletePerson.MouseEnter += DeletePerson_MouseEnter;
            deletePerson.MouseLeave += DeletePerson_MouseLeave;

            brightTheme.Checked += BrightTheme_Checked;
            darkTheme.Checked += BrightTheme_Checked;

        }

        /// <summary>
        /// Событие выбора радио кнопки - изменение оформления приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrightTheme_Checked(object sender, RoutedEventArgs e)
        {
            if (brightTheme.IsChecked == true)
            {
                ResourceDictionary nDictionary = new ResourceDictionary();
                nDictionary.Source = new Uri("s_dic.xaml", UriKind.Relative);
                this.Resources.MergedDictionaries[0] = nDictionary;
            }
            else if (darkTheme.IsChecked == true)
            {
                ResourceDictionary nDictionary = new ResourceDictionary();
                nDictionary.Source = new Uri("s_dic_dark.xaml", UriKind.Relative);
                this.Resources.MergedDictionaries[0] = nDictionary;
            }
        }

        /// <summary>
        /// Курсор мыши покинул пределы кнопки удаления сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePerson_MouseLeave(object sender, MouseEventArgs e)
        {
            deletePerson.Opacity = 1;
        }

        /// <summary>
        /// Обработка нажатия кнопки удаления сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePerson_MouseEnter(object sender, MouseEventArgs e)
        {
            deletePerson.Opacity = 0.6;
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            if (lb_persons.SelectedIndex != -1)
            {
                vm.Persons.Remove(lb_persons.SelectedItem as Person);
                Message("Сотрудник успешно удален!", false);
            }
        }

        /// <summary>
        /// Событие изменения выбранного элемента в ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lb_persons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb_persons.SelectedIndex != -1)
            {
                deletePerson.IsEnabled = true;
                deletePerson.Style = (Style)FindResource("delB");
            }
            else
            {
                deletePerson.Style = (Style)FindResource("delB_dis");
                deletePerson.IsEnabled = false;
            }
        }

        /// <summary>
        /// Курсор мыши покинул пределы кнопки добавления нового сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPerson_MouseLeave(object sender, MouseEventArgs e)
        {
            addPerson.Opacity = 1;
        }

        /// <summary>
        /// Курсор мыши над кнопкой добавления нового сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPerson_MouseEnter(object sender, MouseEventArgs e)
        {
            addPerson.Opacity = 0.5;
        }

        /// <summary>
        /// Обработка нажатия кнопки Добавления нового сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (tba_firstName.Text == "" ||
                tba_middleName.Text == "" ||
                tba_lastName.Text == "" ||
                tba_age.Text == "" ||
                tba_inn.Text == "")
            {
                Message("Ошибка добавления!\rНе все обязательные поля заполнены!", true);
                return;
            }

            int age = 0;
            long inn = 0;

            try
            {
                age = Convert.ToInt16(tba_age.Text);
            }
            catch (Exception)
            {
                Message("Ошибка добавления!\rПроверьте правильность заполнения поля Возраст!", true);
                return;
            }

            try
            {
                inn = Convert.ToInt64(tba_inn.Text);
            }
            catch (Exception)
            {
                Message("Ошибка добавления!\rПроверьте правильность заполнения поля ИНН!", true);
                return;
            }

            if (tba_avatar.Text == "")
            {
                tba_avatar.Text = "user.ico";
            }

            Person p = new Person
            {
                FirstName = tba_firstName.Text,
                MiddleName = tba_middleName.Text,
                LastName = tba_lastName.Text,
                Age = age,
                Inn = inn,
                Avatar = tba_avatar.Text
            };

            vm.Persons.Add(p);

            ClearFields();

        }

        /// <summary>
        /// Отображение сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <param name="error"></param>
        private void Message(string message, bool error)
        {
            if (error)
            {
                MessageBox.Show(message, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(message, this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Очистить поля
        /// </summary>
        private void ClearFields()
        {
            foreach (var item in sp_addPerson.Children)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }
        }
    }
}
