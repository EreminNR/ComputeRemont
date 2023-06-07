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

namespace Recording_studio
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
            SearchTermTextBox.MaxLength = 40;
            SearchTermTextBox1.MaxLength = 20;

        }
        public static string log;
        public static string pas;
        public static string name;
        public static string lastname;
        public static int idperson;


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (check.IsChecked == true)
            {
                Pass1.Password = SearchTermTextBox1.Text;
            }
            else
            {
                SearchTermTextBox1.Text = Pass1.Password;
            }
            if (SearchTermTextBox.Text.Length > 0)      
            {
                if (SearchTermTextBox1.Text.Length > 0 || Pass1.Password.Length > 0)       
                {

                    using (StudioEntities db = new StudioEntities())
                    {
                        foreach (Администратор admin in db.Администратор)
                        {
                            if (SearchTermTextBox.Text == admin.Логин && (SearchTermTextBox1.Text == admin.Пароль || Pass1.Password == admin.Пароль))
                            {                                
                                NavigationService.Navigate(new admin());
                                return;
                            }


                        }
                        
                    }

                    using (StudioEntities db = new StudioEntities())
                    {
                        foreach (Пользователь user in db.Пользователь)
                        {
                            if (SearchTermTextBox.Text == user.Логин && (SearchTermTextBox1.Text == user.Пароль || Pass1.Password == user.Пароль))
                            {
                                name = user.Имя;
                                lastname = user.Фамилия;
                                log = SearchTermTextBox.Text;
                                pas = SearchTermTextBox1.Text;
                                idperson = user.IDПользователя;
                                NavigationService.Navigate(new Main());
                                return;
                            }
                            

                        }
                        MessageBox.Show("Неверно указан логин или пароль!");
                    }
                }
                else MessageBox.Show("Введите пароль");    
            }
            else MessageBox.Show("Введите логин"); 
            
        }

        private void myTextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void SearchTermTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void SearchTermTextBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SearchTermTextBox1.Text = Pass1.Password; // скопируем в TextBox из PasswordBox
                SearchTermTextBox1.Visibility = Visibility.Visible; // TextBox - отобразить
                Pass1.Visibility = Visibility.Hidden; // PasswordBox - скрыть

                

            }
            else
            {
                Pass1.Password = SearchTermTextBox1.Text; // скопируем в PasswordBox из TextBox 
                SearchTermTextBox1.Visibility = Visibility.Hidden; // TextBox - скрыть
                Pass1.Visibility = Visibility.Visible; // PasswordBox - отобразить
               

            }
        }

        public bool AuthorizeUser(string login, string pas2)
        {
            bool a = false;
            using (StudioEntities db = new StudioEntities())
            {
                foreach (Пользователь пользователь in db.Пользователь)
                {
                    
                        if (пользователь.Логин == login && пользователь.Пароль == pas2)
                        {
                            a = true;
                        }
                        else
                        {
                            a = false;
                        }
                    
                }
                if (a == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
                
            
        }

    }
}
