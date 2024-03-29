﻿using System;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {

        public Registration()
        {
            InitializeComponent();
            SearchTermTextBox.MaxLength = 40;
            SearchTermTextBox1.MaxLength = 40;
            SearchTermTextBox2.MaxLength = 40;
            SearchTermTextBox3.MaxLength = 20;
            SearchTermTextBox4.MaxLength = 20;
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(check.IsChecked == true)
            {
                Pass1.Password = SearchTermTextBox3.Text;
                Pass2.Password = SearchTermTextBox4.Text;
            }
            else
            {
                SearchTermTextBox3.Text = Pass1.Password;
                SearchTermTextBox4.Text = Pass2.Password;
            }
            bool a = true;
            if (SearchTermTextBox.Text.Length > 0)
            {
                if (SearchTermTextBox1.Text.Length > 0)
                {

                    if (SearchTermTextBox2.Text.Length > 0)
                    {
                        if (SearchTermTextBox3.Text.Length > 0 || Pass1.Password.Length > 0)
                        {
                            if (SearchTermTextBox4.Text.Length > 0 || Pass2.Password.Length > 0)
                            {
                                string[] dataLogin = SearchTermTextBox2.Text.Split('@');
                                if (dataLogin.Length == 2)
                                {
                                    string[] data2Login = dataLogin[1].Split('.');
                                    if (data2Login.Length == 2)
                                    {
                                        if (SearchTermTextBox3.Text.Length >= 6 || Pass1.Password.Length >= 6)
                                        {
                                            if (SearchTermTextBox3.Text == SearchTermTextBox4.Text || Pass1.Password == Pass2.Password)
                                            {

                                                using (StudioEntities db = new StudioEntities())
                                                {
                                                    foreach (Пользователь user in db.Пользователь)
                                                    {

                                                        if (SearchTermTextBox2.Text == user.Логин)
                                                        {
                                                            a = false;

                                                        }

                                                    }
                                                    if (a == true)
                                                    {
                                                        Пользователь пользователь = new Пользователь { Имя = SearchTermTextBox.Text, Фамилия = SearchTermTextBox1.Text, Логин = SearchTermTextBox2.Text, Пароль = SearchTermTextBox4.Text };
                                                        db.Пользователь.Add(пользователь);
                                                        db.SaveChanges();
                                                        MessageBox.Show("Пользователь зарегистрирован");
                                                        NavigationService.Navigate(new Authorization());

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Email уже существует");
                                                    }

                                                }



                                            }
                                            else MessageBox.Show("Пароли не совподают");
                                        }
                                        else MessageBox.Show("Пароль слишком короткий, минимум 6 символов");
                                    }
                                    else MessageBox.Show("Укажите логин в форме х@x.x");
                                }
                                else MessageBox.Show("Укажите логин в форме х@x.x");

                            }
                            else MessageBox.Show("Повторите пароль");
                        }
                        else MessageBox.Show("Укажите пароль");
                    }
                    else MessageBox.Show("Укажите логин");
                }
                else MessageBox.Show("Укажите фамилию");
            }
            else MessageBox.Show("Укажите имя");

            

            



        }

        private void myTextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }

        private void SearchTermTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            
        }

        private void SearchTermTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!SearchTermTextBox.Text.Contains(".")
               && SearchTermTextBox.Text.Length != 0)))
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

        private void SearchTermTextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((Char.IsDigit(e.Text, 0) || (e.Text == ".")
               && (!SearchTermTextBox.Text.Contains(".")
               && SearchTermTextBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void SearchTermTextBox2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void SearchTermTextBox3_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void SearchTermTextBox4_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                SearchTermTextBox3.Text = Pass1.Password; // скопируем в TextBox из PasswordBox
                SearchTermTextBox3.Visibility = Visibility.Visible; // TextBox - отобразить
                Pass1.Visibility = Visibility.Hidden; // PasswordBox - скрыть

                SearchTermTextBox4.Text = Pass2.Password; // скопируем в TextBox из PasswordBox
                SearchTermTextBox4.Visibility = Visibility.Visible; // TextBox - отобразить
                Pass2.Visibility = Visibility.Hidden; // PasswordBox - скрыть

            }
            else
            {
                Pass1.Password = SearchTermTextBox3.Text; // скопируем в PasswordBox из TextBox 
                SearchTermTextBox3.Visibility = Visibility.Hidden; // TextBox - скрыть
                Pass1.Visibility = Visibility.Visible; // PasswordBox - отобразить

                Pass2.Password = SearchTermTextBox4.Text; // скопируем в PasswordBox из TextBox 
                SearchTermTextBox4.Visibility = Visibility.Hidden; // TextBox - скрыть
                Pass2.Visibility = Visibility.Visible; // PasswordBox - отобразить



            }
        }

        public bool RegisterUser(string username, string lastname, string login, string pas1, string pas2)
        {

            using (StudioEntities db = new StudioEntities())
            {
                if (pas1 == pas2)
                {
                    Пользователь пользователь = new Пользователь { Имя = username, Фамилия = lastname, Логин = login, Пароль = pas2 };
                    db.Пользователь.Add(пользователь);
                    db.SaveChanges();
                    
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
