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
    /// Логика взаимодействия для Personal.xaml
    /// </summary>
    public partial class Personal : Page
    {
        public Personal()
        {
            InitializeComponent();
            SearchTermTextBox2.IsReadOnly = true;
            SearchTermTextBox2.Text = Authorization.log;
            using (StudioEntities db = new StudioEntities())
            {
                        string l = Authorization.log;
                        string p = Authorization.pas;
                        Пользователь user1 = (from t in db.Пользователь where t.Логин == l && t.Пароль == p select t).FirstOrDefault();                    
                SearchTermTextBox.Text = user1.Имя;
                SearchTermTextBox1.Text = user1.Фамилия;

            }
                but1.Visibility = Visibility.Hidden;
            using (StudioEntities db = new StudioEntities())
            {
                string l = Authorization.log;
                string p = Authorization.pas;
                Пользователь user1 = (from t in db.Пользователь where t.Логин == l && t.Пароль == p select t).FirstOrDefault();
                foreach (Запись запись in db.Запись)
                {
                    if(user1.IDПользователя == запись.IDПользователя && запись.СтатусЗаписи == "Ожидает подтверждения")
                    {
                        DateTime dateOnly = Convert.ToDateTime(запись.Дата);
                        string date = dateOnly.ToShortDateString();
                        Услуги услуги = (from t in db.Услуги where t.IDУслуги == запись.IDУслуги select t).FirstOrDefault();
                        lb1.Content = "- Услуга: " + услуги.Название + ", Дата: " + date + ", " + запись.Время + ", Cтатус: " + запись.СтатусЗаписи;
                    }
                    else if(user1.IDПользователя == запись.IDПользователя && запись.СтатусЗаписи == "Подтверждена")
                    {
                        DateTime dateOnly = Convert.ToDateTime(запись.Дата);
                        string date = dateOnly.ToShortDateString();
                        Услуги услуги = (from t in db.Услуги where t.IDУслуги == запись.IDУслуги select t).FirstOrDefault();
                        lb1.Content = "- Услуга: " + услуги.Название + ", Дата: " + date + ", " + запись.Время + ", Cтатус: " + запись.СтатусЗаписи;
                    }
                    else if(user1.IDПользователя == запись.IDПользователя && запись.СтатусЗаписи == "Отменена")
                    {
                        DateTime dateOnly = Convert.ToDateTime(запись.Дата);
                        string date = dateOnly.ToShortDateString();
                        Услуги услуги = (from t in db.Услуги where t.IDУслуги == запись.IDУслуги select t).FirstOrDefault();
                        lb1.Content = "- Услуга: " + услуги.Название + ", Дата: " + date + ", " + запись.Время + ", Cтатус: " + запись.СтатусЗаписи;
                        
                    }
                    else
                    {
                        lb1.Content = "Запись отсутствует";
                    }
                }

            }

        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Main());
        }

        private void TextBlock_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Services());
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

        private void SearchTermTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            but1.Visibility = Visibility.Visible;
        }

        private void SearchTermTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            but1.Visibility = Visibility.Visible;
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            using (StudioEntities db = new StudioEntities())
            {
                if (SearchTermTextBox.Text != String.Empty && SearchTermTextBox1.Text != String.Empty)
                {
                    if (SearchTermTextBox.Text.Length >= 3 && SearchTermTextBox1.Text.Length >= 3)
                    {
                        string l = Authorization.log;
                        string p = Authorization.pas;
                        Пользователь user1 = (from t in db.Пользователь where t.Логин == l && t.Пароль == p select t).FirstOrDefault();
                        user1.Имя = SearchTermTextBox.Text;
                        user1.Фамилия = SearchTermTextBox1.Text;                        
                        db.SaveChanges();
                        MessageBox.Show("Изменения сохранены");
                        
                    }
                    else MessageBox.Show("Введите данные длиннее");
                }

                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
