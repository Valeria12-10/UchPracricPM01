using OfficeOpenXml.Export.HtmlExport.StyleCollectors.StyleContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace WM
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private readonly Пользователи _user;
        public OrderWindow()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            using (var bd = new СкладыEntities())
            {
                cbProductOrder.ItemsSource = bd.Товары.ToList();
                cbProductOrder1.ItemsSource = bd.Товары.ToList();
                cbProductOrder.DisplayMemberPath = "Название";
                cbProductOrder.SelectedValuePath = "IDТовара";
                cbProductOrder1.DisplayMemberPath = "Название";
                cbProductOrder1.SelectedValuePath = "IDТовара";
                cbPostav.ItemsSource = bd.Поставщики.ToList();
                cbPostav.DisplayMemberPath = "Название";
                cbPostav.SelectedValuePath = "IDПоставщика";
                cbClient.ItemsSource = bd.Клиенты.ToList();
                cbClient.DisplayMemberPath = "Название";
                cbClient.SelectedValuePath = "IDКлиента";
            }
        }
        //заказ клиенту
        private void ClientOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new СкладыEntities())
            {
                // Проверка заполненности полей
                if (cbProductOrder1.SelectedItem == null || cbClient.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantityOrder.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                // Получение выбранных данных
                var selectedProduct1 = cbProductOrder1.SelectedItem as Товары;
                var selectedClient1 = cbClient.SelectedItem as Клиенты;
                int quantity1 = int.Parse(txtQuantityOrder1.Text);
                DateTime date1 = dpDateOrder1.SelectedDate ?? DateTime.Now;

                // Получение типа заказа
                string orderType1 = (cbOrderType1.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Создание нового заказа
                var order1 = new Заказы
                {
                    ТипЗаказа = orderType1,
                    ДатаЗаказа = date1,
                    IDПоставщика = selectedClient1.IDКлиента,
                    СтатусЗаказа = "В процессе", // Начальный статус заказа
                    ОбщаяСумма = selectedProduct1.Цена * quantity1
                };

                // Добавление заказа в контекст
                bd.Заказы.Add(order1);
                bd.SaveChanges(); // Сохранение изменений в базе данных

                // Создание элемента заказа
                var orderItem = new ЭлементыЗаказа
                {
                    IDЗаказа = order1.IDЗаказа, // Связываем элемент с только что созданным заказом
                    IDТовара = selectedProduct1.IDТовара,
                    Количество = quantity1,
                    Цена = selectedProduct1.Цена
                };

                // Добавление элемента заказа в контекст
                bd.ЭлементыЗаказа.Add(orderItem);
                bd.SaveChanges(); // Сохранение изменений в базе данных

                MessageBox.Show("Заказ клиенту оформлен.");
            }
        }
        //заказ поставщику
        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new СкладыEntities())
            {
                // Проверка заполненности полей
                if (cbProductOrder.SelectedItem == null || cbPostav.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantityOrder.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                // Получение выбранных данных
                var selectedProduct = cbProductOrder.SelectedItem as Товары;
                var selectedPostav = cbPostav.SelectedItem as Поставщики;
                int quantity = int.Parse(txtQuantityOrder.Text);
                DateTime date = dpDateOrder.SelectedDate ?? DateTime.Now;

                // Получение типа заказа
                string orderType = (cbOrderType.SelectedItem as ComboBoxItem)?.Content.ToString();

                // Создание нового заказа
                var order = new Заказы
                {
                    ТипЗаказа = orderType,
                    ДатаЗаказа = date,
                    IDПоставщика = selectedPostav.IDПоставщика,
                    СтатусЗаказа = "В процессе", // Начальный статус заказа
                    ОбщаяСумма = selectedProduct.Цена * quantity
                };

                // Добавление заказа в контекст
                bd.Заказы.Add(order);
                bd.SaveChanges(); // Сохранение изменений в базе данных

                // Создание элемента заказа
                var orderItem = new ЭлементыЗаказа
                {
                    IDЗаказа = order.IDЗаказа, // Связываем элемент с только что созданным заказом
                    IDТовара = selectedProduct.IDТовара,
                    Количество = quantity,
                    Цена = selectedProduct.Цена
                };

                // Добавление элемента заказа в контекст
                bd.ЭлементыЗаказа.Add(orderItem);
                bd.SaveChanges(); // Сохранение изменений в базе данных

                MessageBox.Show("Заказ поставщику оформлен.");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var qwWindow = new Sales_Manager(_user.IDПользователя);
            qwWindow.Show();
            this.Close();
        }

        private void Exit1_Click(object sender, RoutedEventArgs e)
        {
            var qwWindow = new Sales_Manager(_user.IDПользователя);
            qwWindow.Show();
            this.Close();
        }
    }
}
