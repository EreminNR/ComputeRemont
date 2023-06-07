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
    /// Логика взаимодействия для Recording.xaml
    /// </summary>
    public partial class Recording : Page
    {
        public Recording()
        {
            InitializeComponent();
            Services services = new Services();

            SearchTermTextBox.MaxLength = 11;
            using (StudioEntities db = new StudioEntities())
            {
                foreach (Услуги id in db.Услуги)
                {
                    cb1.Items.Add(id.Название);

                }
                //Услуги услуги = (from t in db.Услуги where t.IDУслуги == services.skinId select t).FirstOrDefault();
                //usluga.Text = услуги.Название;
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



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Personal());
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
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            ViborData.DisplayDateStart = DateTime.Now.AddDays(1);
            ViborData.DisplayDateEnd = DateTime.Now + TimeSpan.FromDays(14);

            var minDate = ViborData.DisplayDateStart ?? DateTime.MinValue;
            var maxDate = ViborData.DisplayDateEnd ?? DateTime.MaxValue;

            for (var d = minDate; d <= maxDate && DateTime.MaxValue > d; d = d.AddDays(1))
            {
                if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday)
                {
                    ViborData.BlackoutDates.Add(new CalendarDateRange(d));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StudioEntities db = new StudioEntities())
                {
                    string l = Authorization.log;
                    string p = Authorization.pas;
                    Пользователь user1 = (from t in db.Пользователь where t.Логин == l && t.Пароль == p select t).FirstOrDefault();
                    bool a = false;
                    foreach (Запись запись in db.Запись)
                    {
                        if (запись.IDПользователя == user1.IDПользователя)
                        {
                            a = true;
                        }
                    }
                    if (a == false)
                    {
                        if (SearchTermTextBox.Text.Length == 11)
                        {
                            if (ViborData.SelectedDate.Value != Convert.ToDateTime("01.01.0001"))
                            {
                                string str = (cb1.Text);
                                Услуги услуги = (from t in db.Услуги where t.Название == str select t).FirstOrDefault();
                                Запись запись = new Запись { IDПользователя = Authorization.idperson, IDУслуги = услуги.IDУслуги, Телефон = SearchTermTextBox.Text, Дата = (ViborData.SelectedDate), Время = "14:00", СтатусЗаписи = "Ожидает подтверждения" };
                                db.Запись.Add(запись);
                                db.SaveChanges();
                                MessageBox.Show("Запись создана");
                                NavigationService.Navigate(new Personal());
                            }
                            else
                            {
                                MessageBox.Show("Выберите Дату!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Корректно введите номер телефона!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы уже записаны, проверьте статус записи в личном кабинете!");

                    }

                }
            }

            catch
            {

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StudioEntities db = new StudioEntities())
                {
                    string l = Authorization.log;
                    string p = Authorization.pas;
                    Пользователь user1 = (from t in db.Пользователь where t.Логин == l && t.Пароль == p select t).FirstOrDefault();
                    bool a = false;
                    foreach (Запись запись in db.Запись)
                    {
                        if (запись.IDПользователя == user1.IDПользователя)
                        {
                            a = true;
                        }
                    }
                    if (a == false)
                    {
                        if (SearchTermTextBox.Text.Length == 11)
                        {
                            if (ViborData.SelectedDate.Value != Convert.ToDateTime("01.01.0001"))
                            {
                                string str = (cb1.Text);
                                Услуги услуги = (from t in db.Услуги where t.Название == str select t).FirstOrDefault();
                                Запись запись = new Запись { IDПользователя = Authorization.idperson, IDУслуги = услуги.IDУслуги, Телефон = SearchTermTextBox.Text, Дата = (ViborData.SelectedDate), Время = "16:00", СтатусЗаписи = "Ожидает подтверждения" };
                                db.Запись.Add(запись);
                                db.SaveChanges();
                                MessageBox.Show("Запись создана");
                                NavigationService.Navigate(new Personal());
                            }
                            else
                            {
                                MessageBox.Show("Выберите Дату!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Корректно введите номер телефона!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы уже записаны, проверьте статус записи в личном кабинете!");

                    }
                }
            }

            catch
            {

            }
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StudioEntities db = new StudioEntities())
                {
                    string l = Authorization.log;
                    string p = Authorization.pas;
                    Пользователь user1 = (from t in db.Пользователь where t.Логин == l && t.Пароль == p select t).FirstOrDefault();
                    bool a = false;
                    foreach (Запись запись in db.Запись)
                    {
                        if (запись.IDПользователя == user1.IDПользователя)
                        {
                            a = true;
                        }
                    }
                    if (a == false)
                    {
                        if (SearchTermTextBox.Text.Length == 11)
                        {
                            if (ViborData.SelectedDate.Value != Convert.ToDateTime("01.01.0001"))
                            {
                                string str = (cb1.Text);
                                Услуги услуги = (from t in db.Услуги where t.Название == str select t).FirstOrDefault();
                                Запись запись = new Запись { IDПользователя = Authorization.idperson, IDУслуги = услуги.IDУслуги, Телефон = SearchTermTextBox.Text, Дата = (ViborData.SelectedDate), Время = "18:00", СтатусЗаписи = "Ожидает подтверждения" };
                                db.Запись.Add(запись);
                                db.SaveChanges();
                                MessageBox.Show("Запись создана");
                                NavigationService.Navigate(new Personal());
                            }
                            else
                            {
                                MessageBox.Show("Выберите Дату!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Корректно введите номер телефона!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы уже записаны, проверьте статус записи в личном кабинете!");

                    }
                }
            }

            catch
            {

            }
        }

        private void bt4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StudioEntities db = new StudioEntities())
                {
                    string l = Authorization.log;
                    string p = Authorization.pas;
                    Пользователь user1 = (from t in db.Пользователь where t.Логин == l && t.Пароль == p select t).FirstOrDefault();
                    bool a = false;
                    foreach (Запись запись in db.Запись)
                    {
                        if (запись.IDПользователя == user1.IDПользователя)
                        {
                            a = true;
                        }
                    }
                    if (a == false)
                    {
                        if (SearchTermTextBox.Text.Length == 11)
                        {
                            if (ViborData.SelectedDate.Value != Convert.ToDateTime("01.01.0001"))
                            {
                                string str = (cb1.Text);
                                Услуги услуги = (from t in db.Услуги where t.Название == str select t).FirstOrDefault();
                                Запись запись = new Запись { IDПользователя = Authorization.idperson, IDУслуги = услуги.IDУслуги, Телефон = SearchTermTextBox.Text, Дата = (ViborData.SelectedDate), Время = "20:00", СтатусЗаписи = "Ожидает подтверждения" };
                                db.Запись.Add(запись);
                                db.SaveChanges();
                                MessageBox.Show("Запись создана");
                                NavigationService.Navigate(new Personal());
                            }
                            else
                            {
                                MessageBox.Show("Выберите Дату!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Корректно введите номер телефона!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы уже записаны, проверьте статус записи в личном кабинете!");

                    }

                }
            }

            catch
            {

            }
        }

        private void ViborData_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            bool a = false;
            bool b = false;
            bool c = false;
            bool d = false;

            using (StudioEntities db = new StudioEntities())
            {
                DateTime selectedDate = (DateTime)ViborData.SelectedDate;
                foreach (Запись id in db.Запись)
                {
                    if (selectedDate == id.Дата && id.Время == "14:00")
                    {
                        a = true;
                    }

                    if (selectedDate == id.Дата && id.Время == "16:00")
                    {
                        b = true;
                    }

                    if (selectedDate == id.Дата && id.Время == "18:00")
                    {
                        c = true;
                    }

                    if (selectedDate == id.Дата && id.Время == "20:00")
                    {
                        d = true;
                    }

                }

                if (a == true)
                {
                    bt1.Visibility = Visibility.Hidden;
                }
                else
                {
                    bt1.Visibility = Visibility.Visible;
                }

                if (b == true)
                {
                    bt2.Visibility = Visibility.Hidden;
                }
                else
                {
                    bt2.Visibility = Visibility.Visible;
                }

                if (c == true)
                {
                    bt3.Visibility = Visibility.Hidden;
                }
                else
                {
                    bt3.Visibility = Visibility.Visible;
                }

                if (d == true)
                {
                    bt4.Visibility = Visibility.Hidden;
                }
                else
                {
                    bt4.Visibility = Visibility.Visible;
                }
            }
        }


        public bool Record(string phone)
        {

            using (StudioEntities db = new StudioEntities())
            {
                string l = Authorization.log;
                string p = Authorization.pas;
                Пользователь user1 = (from t in db.Пользователь where t.Логин == l && t.Пароль == p select t).FirstOrDefault();
                bool a = false;

                if (phone.Length == 11)
                {
                    if (ViborData.SelectedDate.Value != Convert.ToDateTime("01.01.0001"))
                    {
                        string str = (cb1.Text);
                        Услуги услуги = (from t in db.Услуги where t.Название == str select t).FirstOrDefault();
                        Запись запись = new Запись { IDПользователя = Authorization.idperson, IDУслуги = услуги.IDУслуги, Телефон = SearchTermTextBox.Text, Дата = (ViborData.SelectedDate), Время = "16:00", СтатусЗаписи = "Ожидает подтверждения" };
                        db.Запись.Add(запись);
                        db.SaveChanges();
                        MessageBox.Show("Запись создана");
                        NavigationService.Navigate(new Personal());
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Выберите Дату!");
                        return false;
                    }
                }
                else
                {
                    
                    return true;
                }
            }

        }
    }


 }
    

