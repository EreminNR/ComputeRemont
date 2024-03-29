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
using System.Data;
using System.Data.SqlClient;

namespace Recording_studio
{
    /// <summary>
    /// Логика взаимодействия для admin2.xaml
    /// </summary>
    public partial class admin2 : Page
    {
         

        public admin2()
        {
            InitializeComponent();
            string connectionString = @"Data Source=DESKTOP-OH72CL7\MSSQLSERVER01;Initial Catalog=Studio;Integrated Security=True";
            string sql = "SELECT * FROM Услуги";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                MyData.ItemsSource = ds.Tables[0].DefaultView;
            }

            using (StudioEntities db = new StudioEntities())
            {
                foreach (Услуги id in db.Услуги)
                {
                    cb1.Items.Add(id.IDУслуги);
                    cb2.Items.Add(id.IDУслуги);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new admin());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new admin3());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (StudioEntities db = new StudioEntities())
            {
                if (text.Text != String.Empty && text1.Text != String.Empty && text3.Text != String.Empty)
                {
                    if (text.Text.Length >= 5 && text1.Text.Length >= 5)
                    {
                        Услуги услуги = new Услуги { Название = text1.Text, Описание = text1.Text, Цена = Convert.ToInt32(text3.Text)};
                        db.Услуги.Add(услуги);
                        db.SaveChanges();
                        MessageBox.Show("Данные внесены");
                        
                    }
                    else MessageBox.Show("Введите больше данных");
                }

                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (text4.Text == String.Empty || text5.Text == String.Empty || text6.Text == String.Empty)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                try
                {
                    using (StudioEntities db = new StudioEntities())
                    {
                        int str = Convert.ToInt32(cb1.Text);
                        Услуги услуги = (from t in db.Услуги where t.IDУслуги == str select t).FirstOrDefault();
                        услуги.Название = text4.Text;
                        услуги.Описание = text5.Text;
                        услуги.Цена = Convert.ToDecimal(text6.Text);
                        db.SaveChanges();
                        MessageBox.Show("Изменения внесены успешно!");
                    }
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка при заполнении!");
                }
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (StudioEntities db = new StudioEntities())
            {
                int str = Convert.ToInt32(cb1.Text);
                Услуги услуги = (from t in db.Услуги where t.IDУслуги == str select t).FirstOrDefault();
                text4.Text = услуги.Название;
                text5.Text = услуги.Описание;
                text6.Text = Convert.ToString(услуги.Цена);               
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StudioEntities db = new StudioEntities())
                {
                    int str = Convert.ToInt32(cb2.Text);
                    Услуги услуги = (from t in db.Услуги where t.IDУслуги == str select t).FirstOrDefault();
                    db.Услуги.Remove(услуги);
                    db.SaveChanges();
                    cb2.Items.Clear();
                    cb1.Items.Clear();
                    foreach (Услуги id in db.Услуги)
                    {
                        cb1.Items.Add(id.IDУслуги);
                        cb2.Items.Add(id.IDУслуги);

                    }
                }

            }
            catch { MessageBox.Show("Укажите корректный id!"); }
        }

        public bool ChangeUser(string usernameChange, string login, string pas2)
        {
            bool a = false;
            using (StudioEntities db = new StudioEntities())
            {
                Пользователь пользователь = (from t in db.Пользователь where t.Логин == login && t.Пароль == pas2 select t).FirstOrDefault();
                пользователь.Имя = usernameChange;
                db.SaveChanges();

                foreach (Пользователь user in db.Пользователь)
                {

                    if (user.Логин == login && user.Пароль == pas2 && user.Имя == usernameChange)
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

        public bool DeleteUser(string login, string pas2)
        {
            bool a = false;
            using (StudioEntities db = new StudioEntities())
            {
                Пользователь пользователь = (from t in db.Пользователь where t.Логин == login && t.Пароль == pas2 select t).FirstOrDefault();
                db.Пользователь.Remove(пользователь);
                db.SaveChanges();

                foreach (Пользователь user in db.Пользователь)
                {

                    if (user.Логин == login && user.Пароль == pas2)
                    {
                        a = false;
                    }
                    else
                    {
                        a = true;
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


