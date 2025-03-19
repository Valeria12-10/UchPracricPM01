using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace WM
{
    /// <summary>
    /// Логика взаимодействия для Sales_Manager.xaml
    /// </summary>
    public partial class Sales_Manager : Window
    {
        private Пользователи _currentUser;
        private int _currentUserId;
        public Sales_Manager(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            LoadCurrentUserProfile();
            DisplayUserInfo();
            DisplayUserPhoto();
            LoadProductsToComboBox();
            LoadData();
            LoadClients();
            LoadSuppliers();
            LoadProducts();

        }
        private void LoadProductsToComboBox()
        {
            using (var bd = new СкладыEntities())
            {
                var products = bd.Товары.Select(p => new
                {
                    p.IDТовара,
                    p.Название
                }).ToList();

                ProductComboBox.ItemsSource = products;
                ProductComboBox.DisplayMemberPath = "Название"; // Отображаем название товара
                ProductComboBox.SelectedValuePath = "IDТовара"; // Устанавливаем ID товара как значение
            }
        }
        //загрузка складов
        private void LoadData()
        {
            using (var bd = new СкладыEntities())
            {
                var warehouses = from w in bd.Склады
                                 select new
                                 {
                                     w.IDСклада,
                                     w.Название,
                                     w.Адрес,
                                     w.ТипСклада,
                                     w.ЗонаХранения,
                                     w.IDТовара,
                                     w.Количество
                                 };

                grid.ItemsSource = warehouses.ToList();
            }
        }
        //загрузка клиентов
        private void LoadClients()
        {
            using (var bd = new СкладыEntities())
            {
                var clients = from c in bd.Клиенты
                              select new
                              {
                                  c.IDКлиента,
                                  c.Название,
                                  c.КонтактныйТелефон,
                                  c.КонтактныйEmail,
                                  c.Адрес
                              };

                grid2.ItemsSource = clients.ToList();
            }
        }
        //загрузка поставщиков
        private void LoadSuppliers()
        {
            using (var bd = new СкладыEntities())
            {
                var suppliers = from s in bd.Поставщики
                                select new
                                {
                                    s.IDПоставщика,
                                    s.Название,
                                    s.ИНН,
                                    s.КПП,
                                    s.КонтактныйТелефон,
                                    s.КонтактныйEmail,
                                    s.Адрес
                                };

                grid3.ItemsSource = suppliers.ToList();
            }
        }


        private void LoadCurrentUserProfile()
        {
            using (var bd = new СкладыEntities())
            {
                _currentUser = bd.Пользователи.FirstOrDefault(u => u.IDПользователя == _currentUserId);

                if (_currentUser != null)
                {
                    UserNameTextBox.Text = _currentUser.ИмяПользователя;
                    EmailTextBox.Text = _currentUser.Email;
                    if (_currentUser.Фото != null)
                    {
                        var image = new BitmapImage();
                        using (var stream = new MemoryStream(_currentUser.Фото))
                        {
                            image.BeginInit();
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.StreamSource = stream;
                            image.EndInit();
                        }
                        UserPhoto.Source = image;
                    }
                }
            }
        }
        private void UploadPhoto_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png",
                Title = "Выберите фотографию"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var imagePath = openFileDialog.FileName;
                var image = new BitmapImage(new Uri(imagePath));
                UserPhoto.Source = image;
                _currentUser.Фото = File.ReadAllBytes(imagePath);
            }
        }
        private void SaveProfile_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Пользователь не найден.");
                return;
            }

            using (var bd = new СкладыEntities())
            {
                var user = bd.Пользователи.FirstOrDefault(u => u.IDПользователя == _currentUserId);
                if (user != null)
                {
                    user.ИмяПользователя = UserNameTextBox.Text;
                    user.Email = EmailTextBox.Text;
                    if (!string.IsNullOrEmpty(PasswordBox.Password))
                    {
                        user.ХэшПароля = HashPassword(PasswordBox.Password);
                    }
                    if (_currentUser.Фото != null)
                    {
                        user.Фото = _currentUser.Фото;
                    }
                    bd.SaveChanges();
                    MessageBox.Show("Профиль успешно обновлен.");

                }
            }
        }
        private void DisplayUserInfo()
        {
            if (_currentUser != null)
            {
                UserInfoLabel.Text = $"Текущий пользователь: {_currentUser.ИмяПользователя} ({_currentUser.Роль})";
            }
            else
            {
                UserInfoLabel.Text = "Пользователь не найден.";
            }
        }
        private string HashPassword(string password)
        {
            return password.GetHashCode().ToString();
        }
        private void DisplayUserPhoto()
        {
            if (_currentUser != null && _currentUser.Фото != null)
            {
                var image = new BitmapImage();
                using (var stream = new MemoryStream(_currentUser.Фото))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                }
                UserPhoto.Source = image;
            }
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
        //загрузка товаров
        private void LoadProducts()
        {
            using (var bd = new СкладыEntities())
            {
                var prod = from r in bd.Товары
                           select new
                           {
                               r.IDТовара,
                               r.Название,
                               r.Артикул,
                               r.Штрихкод,
                               r.Категория,
                               r.ЕдиницаИзмерения,
                               r.Цена,
                               r.СерийныйНомер,
                               r.МинимальныйЗапас
                           };

                grid1.ItemsSource = prod.ToList();
            }
        }
        private void Sb_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St.Text.ToLower();

            using (var bd = new СкладыEntities())
            {
                var filteredWarehouses = from w in bd.Склады
                                         where w.Название.ToLower().Contains(searchText) ||
                                               w.Адрес.ToLower().Contains(searchText) ||
                                               w.ТипСклада.ToLower().Contains(searchText) ||
                                               w.ЗонаХранения.ToLower().Contains(searchText)
                                         select new
                                         {
                                             w.IDСклада,
                                             w.Название,
                                             w.Адрес,
                                             w.ТипСклада,
                                             w.ЗонаХранения,
                                             w.IDТовара,
                                             w.Количество
                                         };

                grid.ItemsSource = filteredWarehouses.ToList();
            }
        }
        private void Sb1_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St1.Text.ToLower();

            using (var bd = new СкладыEntities())
            {
                var filteredProducts = from r in bd.Товары
                                       where r.Название.ToLower().Contains(searchText) ||
                                             r.Артикул.ToLower().Contains(searchText) ||
                                             r.Штрихкод.ToLower().Contains(searchText) ||
                                             r.Категория.ToLower().Contains(searchText) ||
                                             r.ЕдиницаИзмерения.ToLower().Contains(searchText) ||
                                             r.СерийныйНомер.ToLower().Contains(searchText)
                                       select new
                                       {
                                           r.IDТовара,
                                           r.Название,
                                           r.Артикул,
                                           r.Штрихкод,
                                           r.Категория,
                                           r.ЕдиницаИзмерения,
                                           r.Цена,
                                           r.СерийныйНомер,
                                           r.МинимальныйЗапас
                                       };

                grid1.ItemsSource = filteredProducts.ToList();
            }
        }
        private void Sb2_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St2.Text.ToLower();

            using (var bd = new СкладыEntities())
            {
                var filteredClients = from c in bd.Клиенты
                                      where c.Название.ToLower().Contains(searchText) ||
                                            c.КонтактныйТелефон.ToLower().Contains(searchText) ||
                                            c.КонтактныйEmail.ToLower().Contains(searchText) ||
                                            c.Адрес.ToLower().Contains(searchText)
                                      select new
                                      {
                                          c.IDКлиента,
                                          c.Название,
                                          c.КонтактныйТелефон,
                                          c.КонтактныйEmail,
                                          c.Адрес
                                      };

                grid2.ItemsSource = filteredClients.ToList();
            }
        }
        private void Sb3_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St3.Text.ToLower();

            using (var bd = new СкладыEntities())
            {
                var filteredSuppliers = from s in bd.Поставщики
                                        where s.Название.ToLower().Contains(searchText) ||
                                              s.ИНН.ToLower().Contains(searchText) ||
                                              s.КПП.ToLower().Contains(searchText) ||
                                              s.КонтактныйТелефон.ToLower().Contains(searchText) ||
                                              s.КонтактныйEmail.ToLower().Contains(searchText) ||
                                              s.Адрес.ToLower().Contains(searchText)
                                        select new
                                        {
                                            s.IDПоставщика,
                                            s.Название,
                                            s.ИНН,
                                            s.КПП,
                                            s.КонтактныйТелефон,
                                            s.КонтактныйEmail,
                                            s.Адрес
                                        };

                grid3.ItemsSource = filteredSuppliers.ToList();
            }
        }
        //добавление поставщика
        private void Add1Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(naz.Text) || string.IsNullOrEmpty(inn.Text) || string.IsNullOrEmpty(kpp.Text) ||
                    string.IsNullOrEmpty(phone.Text) || string.IsNullOrEmpty(emaill.Text) || string.IsNullOrEmpty(adress.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                using (var bd = new СкладыEntities())
                {
                    var newSupplier = new Поставщики
                    {
                        Название = naz.Text,
                        ИНН = inn.Text,
                        КПП = kpp.Text,
                        КонтактныйТелефон = phone.Text,
                        КонтактныйEmail = emaill.Text,
                        Адрес = adress.Text
                    };

                    bd.Поставщики.Add(newSupplier);
                    bd.SaveChanges();

                    // Обновляем DataGrid
                    grid3.ItemsSource = bd.Поставщики.ToList();

                    // Очищаем поля
                    naz.Clear();
                    inn.Clear();
                    kpp.Clear();
                    phone.Clear();
                    emaill.Clear();
                    adress.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSupplier = grid3.SelectedItem as dynamic;
            if (selectedSupplier != null)
            {
                naz.Text = selectedSupplier.Название;
                inn.Text = selectedSupplier.ИНН;
                kpp.Text = selectedSupplier.КПП;
                phone.Text = selectedSupplier.КонтактныйТелефон;
                emaill.Text = selectedSupplier.КонтактныйEmail;
                adress.Text = selectedSupplier.Адрес;
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                naz.Text = "";
                inn.Text = "";
                kpp.Text = "";
                phone.Text = "";
                emaill.Text = "";
                adress.Text = "";
            }
        }

        // Редактирование поставщика
        private void Edit1Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedSupplier = grid3.SelectedItem as dynamic;
            if (selectedSupplier != null)
            {
                using (var bd = new СкладыEntities())
                {
                    var supplierToUpdate = bd.Поставщики.Find(selectedSupplier.IDПоставщика);
                    if (supplierToUpdate != null)
                    {
                        supplierToUpdate.Название = naz.Text;
                        supplierToUpdate.ИНН = inn.Text;
                        supplierToUpdate.КПП = kpp.Text;
                        supplierToUpdate.КонтактныйТелефон = phone.Text;
                        supplierToUpdate.КонтактныйEmail = emaill.Text;
                        supplierToUpdate.Адрес = adress.Text;

                        bd.SaveChanges();
                        LoadSuppliers(); // Обновляем данные в DataGrid
                        MessageBox.Show("Поставщик успешно отредактирован!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поставщика для редактирования.");
            }
        }

        //удаление поставщика
        private void Delete1Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid3.SelectedItem != null)
                {
                    var selectedSupplier = (Поставщики)grid3.SelectedItem;
                    using (var bd = new СкладыEntities())
                    {
                        var supplierToDelete = bd.Поставщики.Find(selectedSupplier.IDПоставщика);
                        if (supplierToDelete != null)
                        {
                            bd.Поставщики.Remove(supplierToDelete);
                            bd.SaveChanges();
                            grid3.ItemsSource = bd.Поставщики.ToList();
                            MessageBox.Show("Поставщик успешно удален!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите поставщика для удаления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Добавление клиента
        private void Add2Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nazz.Text) || string.IsNullOrEmpty(adres.Text) ||
                string.IsNullOrEmpty(phonee.Text) || string.IsNullOrEmpty(eemail.Text))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }

            var newClient = new Клиенты
            {
                Название = nazz.Text,
                Адрес = adres.Text,
                КонтактныйТелефон = phonee.Text,
                КонтактныйEmail = eemail.Text
            };

            using (var bd = new СкладыEntities())
            {
                bd.Клиенты.Add(newClient);
                bd.SaveChanges();
                grid2.ItemsSource = bd.Клиенты.ToList();
            }
        }
        private void grid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedClient = grid2.SelectedItem as dynamic;
            if (selectedClient != null)
            {
                // Заполняем текстовые поля данными из выбранного клиента
                nazz.Text = selectedClient.Название;
                adres.Text = selectedClient.Адрес;
                phonee.Text = selectedClient.КонтактныйТелефон;
                eemail.Text = selectedClient.КонтактныйEmail;
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                nazz.Text = "";
                adres.Text = "";
                phonee.Text = "";
                eemail.Text = "";
            }
        }
        //редактирование клиента 
        private void Edit2Button_Click(object sender, RoutedEventArgs e)
        {

            var selectedClient = grid2.SelectedItem as dynamic;
            if (selectedClient != null)
            {
                using (var bd = new СкладыEntities())
                {
                    var supplierToUpdate = bd.Клиенты.Find(selectedClient.IDКлиента);
                    if (supplierToUpdate != null)
                    {
                        supplierToUpdate.Название = nazz.Text;
                        supplierToUpdate.Адрес = adres.Text;
                        supplierToUpdate.КонтактныйТелефон = phonee.Text;
                        supplierToUpdate.КонтактныйEmail = eemail.Text;

                        bd.SaveChanges();
                        LoadClients(); // Обновляем данные в DataGrid
                        MessageBox.Show("Клиент успешно отредактирован!");
                    }
                }
            }

            else
            {
                MessageBox.Show("Выберите клиента для редактирования.");
            }
        }
        //удаление клиента
        private void Delete2Button_Click(object sender, RoutedEventArgs e)
        {
            if (grid2.SelectedItem is Клиенты selectedClient)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить этого клиента?", "Подтверждение удаления", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using (var bd = new СкладыEntities())
                    {
                        bd.Клиенты.Attach(selectedClient);
                        bd.Клиенты.Remove(selectedClient);
                        bd.SaveChanges();
                        grid2.ItemsSource = bd.Клиенты.ToList();
                        MessageBox.Show("Клиент успешно удален!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.");
            }
        }

        // добавление товаров
        private void Add3Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаем новый объект товара
                var newProduct = new Товары
                {
                    Название = nnaz.Text,
                    Артикул = art.Text,
                    Штрихкод = strix.Text,
                    Категория = kategotia.Text,
                    ЕдиницаИзмерения = ed.Text,
                    Цена = decimal.Parse(zena.Text),
                    СерийныйНомер = nomer.Text,
                    МинимальныйЗапас = int.Parse(minzap.Text)
                };

                // Добавляем товар в базу данных
                using (var bd = new СкладыEntities())
                {
                    bd.Товары.Add(newProduct);
                    bd.SaveChanges();
                }

                // Обновляем DataGrid
                LoadProducts();
                MessageBox.Show("Товар успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
            }
        }


        private void grid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedProduct = grid1.SelectedItem as dynamic;
            if (selectedProduct != null)
            {
                // Заполняем текстовые поля данными из выбранного товара
                nnaz.Text = selectedProduct.Название;
                art.Text = selectedProduct.Артикул;
                strix.Text = selectedProduct.Штрихкод;
                kategotia.Text = selectedProduct.Категория;
                ed.Text = selectedProduct.ЕдиницаИзмерения;
                zena.Text = selectedProduct.Цена.ToString();
                nomer.Text = selectedProduct.СерийныйНомер;
                minzap.Text = selectedProduct.МинимальныйЗапас.ToString();
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                nnaz.Text = "";
                art.Text = "";
                strix.Text = "";
                kategotia.Text = "";
                ed.Text = "";
                zena.Text = "";
                nomer.Text = "";
                minzap.Text = "";
            }
        }

        private void Edit3Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = grid1.SelectedItem as dynamic;
            if (selectedProduct != null)
            {
                using (var bd = new СкладыEntities())
                {
                    var supplierToUpdate = bd.Товары.Find(selectedProduct.IDТовара);
                    if (supplierToUpdate != null)
                    {
                        supplierToUpdate.Название = nnaz.Text;
                        supplierToUpdate.Артикул = art.Text;
                        supplierToUpdate.Штрихкод = strix.Text;
                        supplierToUpdate.Категория = kategotia.Text;
                        supplierToUpdate.ЕдиницаИзмерения = ed.Text;
                        supplierToUpdate.Цена = decimal.Parse(zena.Text);
                        supplierToUpdate.СерийныйНомер = nomer.Text;
                        supplierToUpdate.МинимальныйЗапас = int.Parse(minzap.Text);

                        bd.SaveChanges();
                        LoadProducts(); // Обновляем данные в DataGrid
                        MessageBox.Show("Товар успешно отредактирован!");
                    }
                }
            }

            else
            {
                MessageBox.Show("Выберите товар для редактирования.");
            }

        }
        //удаление товаров
        private void Delete3Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedProduct = grid1.SelectedItem as dynamic;
                if (selectedProduct == null)
                {
                    MessageBox.Show("Выберите товар для удаления!");
                    return;
                }

                using (var bd = new СкладыEntities())
                {
                    // Найдем товар по ID
                    var productToDelete = bd.Товары.Find(selectedProduct.IDТовара);
                    if (productToDelete != null)
                    {
                        bd.Товары.Remove(productToDelete);
                        bd.SaveChanges();
                        LoadProducts(); // Обновляем DataGrid
                        MessageBox.Show("Товар успешно удален!");
                    }
                    else
                    {
                        MessageBox.Show("Товар не найден в базе данных.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении товара: {ex.Message}");
            }
        }

        // Добавление склада
        private void Add4Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(kol.Text, out int количество) || ProductComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Некорректные данные! Убедитесь, что выбраны все поля.");
                    return;
                }

                var newWarehouse = new Склады
                {
                    Название = nas.Text,
                    Адрес = adrezz.Text,
                    ТипСклада = tip.Text,
                    ЗонаХранения = zonaxra.Text,
                    IDТовара = (int)ProductComboBox.SelectedValue, // Получаем ID товара из ComboBox
                    Количество = количество
                };

                using (var bd = new СкладыEntities())
                {
                    bd.Склады.Add(newWarehouse);
                    bd.SaveChanges();
                }

                LoadData();
                MessageBox.Show("Склад успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении склада: {ex.Message}");
            }
        }


        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedWarehouse = grid.SelectedItem as dynamic;
            if (selectedWarehouse != null)
            {
                nas.Text = selectedWarehouse.Название;
                adrezz.Text = selectedWarehouse.Адрес;
                tip.Text = selectedWarehouse.ТипСклада;
                zonaxra.Text = selectedWarehouse.ЗонаХранения;
                kol.Text = selectedWarehouse.Количество?.ToString() ?? string.Empty;

                // Установка выбранного товара в ComboBox
                ProductComboBox.SelectedValue = selectedWarehouse.IDТовара;
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                nas.Text = "";
                adrezz.Text = "";
                tip.Text = "";
                zonaxra.Text = "";
                kol.Text = "";
                ProductComboBox.SelectedValue = null; // Сбрасываем выбор в ComboBox
            }
        }

        // Редактирование склада
        private void Edit4Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedWarehouse = grid.SelectedItem as dynamic;
            if (selectedWarehouse != null)
            {
                if (!int.TryParse(kol.Text, out int количество))
                {
                    MessageBox.Show("Некорректные данные!");
                    return;
                }

                using (var bd = new СкладыEntities())
                {
                    var warehouseToUpdate = bd.Склады.Find(selectedWarehouse.IDСклада);
                    if (warehouseToUpdate != null)
                    {
                        warehouseToUpdate.Название = nas.Text;
                        warehouseToUpdate.Адрес = adrezz.Text;
                        warehouseToUpdate.ТипСклада = tip.Text;
                        warehouseToUpdate.ЗонаХранения = zonaxra.Text;
                        warehouseToUpdate.IDТовара = (int)ProductComboBox.SelectedValue; // Получаем ID товара из ComboBox
                        warehouseToUpdate.Количество = количество;

                        bd.SaveChanges();
                        LoadData();
                        MessageBox.Show("Склад успешно отредактирован!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите склад для редактирования.");
            }
        }

        // Удаление склада
        private void Delete4Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedWarehouse = grid.SelectedItem as dynamic;
                if (selectedWarehouse == null)
                {
                    MessageBox.Show("Выберите склад для удаления!");
                    return;
                }

                using (var bd = new СкладыEntities())
                {
                    var warehouseToDelete = bd.Склады.Find(selectedWarehouse.IDСклада);
                    if (warehouseToDelete != null)
                    {
                        bd.Склады.Remove(warehouseToDelete);
                        bd.SaveChanges();
                    }
                }

                LoadData();
                MessageBox.Show("Склад успешно удален!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении склада: {ex.Message}");
            }
        }

        //удаление накладных
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedInvoice = grid4.SelectedItem; // Убираем dynamic
            if (selectedInvoice == null)
            {
                MessageBox.Show("Выберите накладную для удаления.");
                return;
            }

            // Получаем тип накладной и ID через рефлексию
            var invoiceType = selectedInvoice.GetType().GetProperty("Тип")?.GetValue(selectedInvoice) as string;
            var invoiceId = (int)selectedInvoice.GetType().GetProperty("IDНакладной")?.GetValue(selectedInvoice);

            if (invoiceType == null || invoiceId == 0)
            {
                MessageBox.Show("Ошибка при получении данных накладной.");
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить эту накладную?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new СкладыEntities())
                {
                    try
                    {
                        if (invoiceType == "Приходная")
                        {
                            var invoice = db.ПриходныеНакладные.Find(invoiceId);
                            if (invoice != null)
                            {
                                // Удаляем связанные элементы накладной
                                var items = db.ЭлементыПриходнойНакладной.Where(x => x.IDНакладной == invoice.IDНакладной).ToList();
                                db.ЭлементыПриходнойНакладной.RemoveRange(items);

                                // Удаляем накладную
                                db.ПриходныеНакладные.Remove(invoice);
                            }
                        }
                        else
                        {
                            var invoice = db.РасходныеНакладные.Find(invoiceId);
                            if (invoice != null)
                            {
                                // Удаляем связанные элементы накладной
                                var items = db.ЭлементыРасходнойНакладной.Where(x => x.IDНакладной == invoice.IDНакладной).ToList();
                                db.ЭлементыРасходнойНакладной.RemoveRange(items);

                                // Удаляем накладную
                                db.РасходныеНакладные.Remove(invoice);
                            }
                        }

                        db.SaveChanges();

                        // Обновляем DataGrid в зависимости от текущего фильтра
                        if (invoiceType == "Приходная")
                        {
                            Prih_Click(sender, e); // Обновляем приходные накладные
                        }
                        else
                        {
                            Rash_Click(sender, e); // Обновляем расходные накладные
                        }

                        MessageBox.Show("Накладная успешно удалена.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении накладной: {ex.Message}");
                    }
                }
            }
        }
        //поиск накладных
        private void Sb4_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = St4.Text.ToLower(); // Поиск без учета регистра

            using (var db = new СкладыEntities())
            {
                // Проверяем, какие накладные сейчас отображаются
                var currentInvoices = grid4.ItemsSource as IEnumerable<dynamic>;
                if (currentInvoices == null || !currentInvoices.Any())
                {
                    MessageBox.Show("Нет данных для поиска.");
                    return;
                }

                // Определяем тип накладных (приходные или расходные)
                var firstInvoice = currentInvoices.First();
                bool isIncoming = firstInvoice.Тип == "Приходная";

                if (isIncoming)
                {
                    // Поиск приходных накладных
                    var incomingInvoices = db.ПриходныеНакладные
                        .Where(i => i.НомерНакладной.ToLower().Contains(searchTerm) ||
                                     i.ДатаПоступления.ToString().Contains(searchTerm) ||
                                     i.IDПоставщика.ToString().Contains(searchTerm) ||
                                     i.ОбщаяСумма.ToString().Contains(searchTerm))
                        .Select(i => new
                        {
                            i.IDНакладной,
                            i.НомерНакладной,
                            i.ДатаПоступления,
                            i.IDПоставщика,
                            i.ОбщаяСумма,
                            Тип = "Приходная"
                        }).ToList();

                    grid4.ItemsSource = incomingInvoices;
                }
                else
                {
                    // Поиск расходных накладных
                    var outgoingInvoices = db.РасходныеНакладные
                        .Where(i => i.НомерНакладной.ToLower().Contains(searchTerm) ||
                                     i.ДатаОтгрузки.ToString().Contains(searchTerm) ||
                                     i.IDКлиента.ToString().Contains(searchTerm) ||
                                     i.ОбщаяСумма.ToString().Contains(searchTerm))
                        .Select(i => new
                        {
                            i.IDНакладной,
                            i.НомерНакладной,
                            i.ДатаОтгрузки,
                            i.IDКлиента,
                            i.ОбщаяСумма,
                            Тип = "Расходная"
                        }).ToList();

                    grid4.ItemsSource = outgoingInvoices;
                }
            }
        }
        //сохранение в excel
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Выберите тип накладных для экспорта:", "Экспорт накладных", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                ExportIncomingInvoices(); // Экспорт приходных накладных
            }
            else if (result == MessageBoxResult.No)
            {
                ExportOutgoingInvoices(); // Экспорт расходных накладных
            }
            else if (result == MessageBoxResult.Cancel)
            {
                // Экспорт всех накладных
                ExportIncomingInvoices();
                ExportOutgoingInvoices();
            }
        }

        private void Prih_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new СкладыEntities())
            {
                var incomingInvoices = db.ПриходныеНакладные
                    .Select(i => new
                    {
                        i.IDНакладной,
                        i.НомерНакладной,
                        i.ДатаПоступления,
                        i.IDПоставщика,
                        i.ОбщаяСумма,
                        Тип = "Приходная"
                    }).ToList();

                grid4.ItemsSource = incomingInvoices; // Обновляем DataGrid
            }
        }

        private void Rash_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new СкладыEntities())
            {
                var outgoingInvoices = db.РасходныеНакладные
                    .Select(i => new
                    {
                        i.IDНакладной,
                        i.НомерНакладной,
                        i.ДатаОтгрузки,
                        i.IDКлиента,
                        i.ОбщаяСумма,
                        Тип = "Расходная"
                    }).ToList();

                grid4.ItemsSource = outgoingInvoices; // Обновляем DataGrid
            }
        }
        private void ExportIncomingInvoices()
        {
            using (var db = new СкладыEntities())
            {
                var incomingInvoices = db.ПриходныеНакладные
                    .Select(i => new
                    {
                        i.IDНакладной,
                        i.НомерНакладной,
                        i.ДатаПоступления,
                        i.IDПоставщика,
                        i.ОбщаяСумма,
                        Тип = "Приходная"
                    }).ToList();

                if (!incomingInvoices.Any())
                {
                    MessageBox.Show("Нет приходных накладных для экспорта.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Приходные накладные");

                    // Заголовки
                    worksheet.Cells[1, 1].Value = "ID Накладной";
                    worksheet.Cells[1, 2].Value = "Номер Накладной";
                    worksheet.Cells[1, 3].Value = "Дата Поступления";
                    worksheet.Cells[1, 4].Value = "ID Поставщика";
                    worksheet.Cells[1, 5].Value = "Общая Сумма";
                    worksheet.Cells[1, 6].Value = "Тип";

                    // Форматирование заголовков
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Данные
                    int row = 2;
                    foreach (var invoice in incomingInvoices)
                    {
                        worksheet.Cells[row, 1].Value = invoice.IDНакладной;
                        worksheet.Cells[row, 2].Value = invoice.НомерНакладной;
                        worksheet.Cells[row, 3].Value = invoice.ДатаПоступления;
                        worksheet.Cells[row, 4].Value = invoice.IDПоставщика;
                        worksheet.Cells[row, 5].Value = invoice.ОбщаяСумма;
                        worksheet.Cells[row, 6].Value = invoice.Тип;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Приходные_накладные.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Приходные накладные успешно экспортированы.");
                    }
                }
            }
        }
        private void ExportOutgoingInvoices()
        {
            using (var db = new СкладыEntities())
            {
                var outgoingInvoices = db.РасходныеНакладные
                    .Select(i => new
                    {
                        i.IDНакладной,
                        i.НомерНакладной,
                        i.ДатаОтгрузки,
                        i.IDКлиента,
                        i.ОбщаяСумма,
                        Тип = "Расходная"
                    }).ToList();

                if (!outgoingInvoices.Any())
                {
                    MessageBox.Show("Нет расходных накладных для экспорта.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Расходные накладные");

                    // Заголовки
                    worksheet.Cells[1, 1].Value = "ID Накладной";
                    worksheet.Cells[1, 2].Value = "Номер Накладной";
                    worksheet.Cells[1, 3].Value = "Дата Отгрузки";
                    worksheet.Cells[1, 4].Value = "ID Клиента";
                    worksheet.Cells[1, 5].Value = "Общая Сумма";
                    worksheet.Cells[1, 6].Value = "Тип";

                    // Форматирование заголовков
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Данные
                    int row = 2;
                    foreach (var invoice in outgoingInvoices)
                    {
                        worksheet.Cells[row, 1].Value = invoice.IDНакладной;
                        worksheet.Cells[row, 2].Value = invoice.НомерНакладной;
                        worksheet.Cells[row, 3].Value = invoice.ДатаОтгрузки;
                        worksheet.Cells[row, 4].Value = invoice.IDКлиента;
                        worksheet.Cells[row, 5].Value = invoice.ОбщаяСумма;
                        worksheet.Cells[row, 6].Value = invoice.Тип;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Расходные_накладные.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Расходные накладные успешно экспортированы.");
                    }
                }
            }
        }
        //окно формирования заказов
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ordWindow = new OrderWindow();
            ordWindow.Show();
            this.Close();
        }

        private void PosOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new СкладыEntities())
            {
                var incomingOrders = db.Заказы
                    .Where(o => o.ТипЗаказа == "Оптовый") // Заказы поставщику
                    .Select(o => new
                    {
                        o.IDЗаказа,
                        o.ТипЗаказа,
                        o.ДатаЗаказа,
                        o.IDПоставщика,
                        o.СтатусЗаказа,
                        o.ОбщаяСумма
                    }).ToList();

                gridd.ItemsSource = incomingOrders;
            }
        }

        private void ClOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new СкладыEntities())
            {
                var outgoingOrders = db.Заказы
                    .Where(o => o.ТипЗаказа == "Розничный") // Заказы клиенту
                    .Select(o => new
                    {
                        o.IDЗаказа,
                        o.ТипЗаказа,
                        o.ДатаЗаказа,
                        o.IDКлиента,
                        o.СтатусЗаказа,
                        o.ОбщаяСумма
                    }).ToList();
                gridd.ItemsSource = outgoingOrders;
            }
        }
        private void Exc_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Выберите тип заказов для экспорта:", "Экспорт заказов", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                ExportIncomingOrders(); // Экспорт заказов поставщику
            }
            else if (result == MessageBoxResult.No)
            {
                ExportOutgoingOrders(); // Экспорт заказов клиенту
            }
            else if (result == MessageBoxResult.Cancel)
            {
                // Экспорт всех заказов
                ExportIncomingOrders();
                ExportOutgoingOrders();
            }
        }
        private void ExportIncomingOrders()
        {
            using (var db = new СкладыEntities())
            {
                var incomingOrders = db.Заказы
                    .Where(o => o.ТипЗаказа == "Оптовый") // Заказы поставщику
                    .Select(o => new
                    {
                        o.IDЗаказа,
                        o.ТипЗаказа,
                        o.ДатаЗаказа,
                        o.IDПоставщика,
                        o.СтатусЗаказа,
                        o.ОбщаяСумма
                    }).ToList();

                if (!incomingOrders.Any())
                {
                    MessageBox.Show("Нет заказов для экспорта.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Заказы поставщику");

                    // Заголовки
                    worksheet.Cells[1, 1].Value = "ID Заказа";
                    worksheet.Cells[1, 2].Value = "Тип Заказа";
                    worksheet.Cells[1, 3].Value = "Дата Заказа";
                    worksheet.Cells[1, 4].Value = "ID Поставщика";
                    worksheet.Cells[1, 5].Value = "Статус Заказа";
                    worksheet.Cells[1, 6].Value = "Общая Сумма";

                    // Форматирование заголовков
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Данные
                    int row = 2;
                    foreach (var order in incomingOrders)
                    {
                        worksheet.Cells[row, 1].Value = order.IDЗаказа;
                        worksheet.Cells[row, 2].Value = order.ТипЗаказа;
                        worksheet.Cells[row, 3].Value = order.ДатаЗаказа;
                        worksheet.Cells[row, 4].Value = order.IDПоставщика;
                        // Убираем ID Клиента
                        worksheet.Cells[row, 5].Value = order.СтатусЗаказа;
                        worksheet.Cells[row, 6].Value = order.ОбщаяСумма;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Заказы_поставщику.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Заказы поставщику успешно экспортированы.");
                    }
                }
            }
        }

        private void ExportOutgoingOrders()
        {
            using (var db = new СкладыEntities())
            {
                var outgoingOrders = db.Заказы
                    .Where(o => o.ТипЗаказа == "Розничный") // Заказы клиенту
                    .Select(o => new
                    {
                        o.IDЗаказа,
                        o.ТипЗаказа,
                        o.ДатаЗаказа,
                        o.IDКлиента,
                        o.СтатусЗаказа,
                        o.ОбщаяСумма
                    }).ToList();

                if (!outgoingOrders.Any())
                {
                    MessageBox.Show("Нет заказов для экспорта.");
                    return;
                }

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Заказы клиенту");

                    // Заголовки
                    worksheet.Cells[1, 1].Value = "ID Заказа";
                    worksheet.Cells[1, 2].Value = "Тип Заказа";
                    worksheet.Cells[1, 3].Value = "Дата Заказа";
                    worksheet.Cells[1, 4].Value = "ID Клиента";
                    worksheet.Cells[1, 5].Value = "Статус Заказа";
                    worksheet.Cells[1, 6].Value = "Общая Сумма";

                    // Форматирование заголовков
                    using (var range = worksheet.Cells[1, 1, 1, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    }

                    // Данные
                    int row = 2;
                    foreach (var order in outgoingOrders)
                    {
                        worksheet.Cells[row, 1].Value = order.IDЗаказа;
                        worksheet.Cells[row, 2].Value = order.ТипЗаказа;
                        worksheet.Cells[row, 3].Value = order.ДатаЗаказа;
                        // Убираем ID Поставщика
                        worksheet.Cells[row, 4].Value = order.IDКлиента;
                        worksheet.Cells[row, 5].Value = order.СтатусЗаказа;
                        worksheet.Cells[row, 6].Value = order.ОбщаяСумма;
                        row++;
                    }

                    worksheet.Cells.AutoFitColumns();

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Заказы_клиенту.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);
                        MessageBox.Show("Заказы клиенту успешно экспортированы.");
                    }
                }
            }
        }

        private void Udal_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = gridd.SelectedItem;
            if (selectedOrder == null)
            {
                MessageBox.Show("Выберите заказ для удаления.");
                return;
            }

            // Получаем ID заказа через рефлексию
            var orderId = (int)selectedOrder.GetType().GetProperty("IDЗаказа")?.GetValue(selectedOrder);

            if (orderId == 0)
            {
                MessageBox.Show("Ошибка при получении данных заказа.");
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить этот заказ?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new СкладыEntities())
                {
                    try
                    {
                        var order = db.Заказы.Find(orderId);
                        if (order != null)
                        {
                            // Удаляем связанные элементы заказа
                            var items = db.ЭлементыЗаказа.Where(x => x.IDЗаказа == order.IDЗаказа).ToList();
                            db.ЭлементыЗаказа.RemoveRange(items);

                            // Удаляем заказ
                            db.Заказы.Remove(order);
                        }

                        db.SaveChanges();

                        MessageBox.Show("Заказ успешно удален.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении заказа: {ex.Message}");
                    }
                }
            }
        }

        private void Z_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = Z1.Text.ToLower(); // Поиск без учета регистра

            using (var db = new СкладыEntities())
            {
                var currentOrders = gridd.ItemsSource as IEnumerable<dynamic>;
                if (currentOrders == null || !currentOrders.Any())
                {
                    MessageBox.Show("Нет данных для поиска.");
                    return;
                }

                // Поиск заказов
                var filteredOrders = db.Заказы
                    .Where(o => o.IDЗаказа.ToString().Contains(searchTerm) ||
                                 o.ДатаЗаказа.ToString().Contains(searchTerm) ||
                                 o.IDКлиента.ToString().Contains(searchTerm) ||
                                 o.ОбщаяСумма.ToString().Contains(searchTerm))
                    .Select(o => new
                    {
                        o.IDЗаказа,
                        o.ТипЗаказа,
                        o.ДатаЗаказа,
                        o.IDПоставщика,
                        o.IDКлиента,
                        o.СтатусЗаказа,
                        o.ОбщаяСумма
                    }).ToList();

                gridd.ItemsSource = filteredOrders;
            }
        }
    }
}
