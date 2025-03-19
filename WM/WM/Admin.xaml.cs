using System.IO;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Data;
using System.Security.Policy;
using System.Windows.Media;


namespace WM
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private Пользователи _currentUser;
        private int _currentUserId;
        public Admin(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            LoadCurrentUserProfile();
            DisplayUserInfo();
            DisplayUserPhoto();
            LoadData();
            LoadProducts();
            LoadClients();
            LoadSuppliers();
            LoadUsers();
            LoadProductsToComboBox();


        }
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
        private void LoadUsers()
        {
            using (var bd = new СкладыEntities())
            {
                var polz = from r in bd.Пользователи
                           select new
                           {
                               r.IDПользователя,
                               r.ИмяПользователя,
                               r.Email,
                               r.ХэшПароля,
                               r.Роль

                           };

                grid4.ItemsSource = polz.ToList();
            }
        }
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
        private void Sb4_Click(object sender, RoutedEventArgs e)
        {
            string searchText = St4.Text.ToLower();

            using (var bd = new СкладыEntities())
            {
                var filteredUsers = from u in bd.Пользователи
                                    where u.ИмяПользователя.ToLower().Contains(searchText) ||
                                          u.Email.ToLower().Contains(searchText) ||
                                          u.Роль.ToLower().Contains(searchText)
                                    select new
                                    {
                                        u.IDПользователя,
                                        u.ИмяПользователя,
                                        u.Email,
                                        u.ХэшПароля,
                                        u.Роль
                                    };

                grid4.ItemsSource = filteredUsers.ToList();
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
        // Добавление пользователя 
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ima.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(par.Text) || role.SelectedItem == null)
                {
                    MessageBox.Show("Заполните все поля и выберите роль.");
                    return;
                }

                using (var bd = new СкладыEntities())
                {
                    var newUser = new Пользователи
                    {
                        ИмяПользователя = ima.Text,
                        Email = email.Text,
                        ХэшПароля = par.Text,
                        Роль = ((ComboBoxItem)role.SelectedItem).Content.ToString()
                    };

                    bd.Пользователи.Add(newUser);
                    bd.SaveChanges();

                    // Обновляем DataGrid
                    LoadUsers();

                    // Очищаем поля
                    ima.Clear();
                    email.Clear();
                    par.Clear();
                    role.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grid4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid4.SelectedItem != null)
            {
                var selectedUser = grid4.SelectedItem as dynamic;
                ima.Text = selectedUser.ИмяПользователя;
                email.Text = selectedUser.Email;
                par.Text = selectedUser.ХэшПароля;

                // Установка выбранного элемента в ComboBox
                foreach (ComboBoxItem item in role.Items)
                {
                    if (item.Content.ToString() == selectedUser.Роль)
                    {
                        role.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                // Если ничего не выбрано, очищаем поля
                ima.Text = "";
                email.Text = "";
                par.Text = "";
                role.SelectedItem = null;
            }
        }

        // Редактирование пользователя 
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid4.SelectedItem != null)
                {
                    var selectedUser = grid4.SelectedItem as dynamic;

                    using (var bd = new СкладыEntities())
                    {
                        var userToEdit = bd.Пользователи.Find(selectedUser.IDПользователя);
                        if (userToEdit != null)
                        {
                            userToEdit.ИмяПользователя = ima.Text;
                            userToEdit.Email = email.Text;
                            userToEdit.ХэшПароля = par.Text;
                            userToEdit.Роль = ((ComboBoxItem)role.SelectedItem).Content.ToString();
                            bd.SaveChanges();

                            // Обновляем DataGrid
                            LoadUsers();

                            // Очищаем поля
                            ima.Clear();
                            email.Clear();
                            par.Clear();
                            role.SelectedItem = null;
                            MessageBox.Show("Пользователь успешно отредактирован!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите пользователя для редактирования");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Удаление пользователя 
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid4.SelectedItem != null)
                {
                    var selectedUser = grid4.SelectedItem as dynamic;

                    using (var bd = new СкладыEntities())
                    {
                        var userToDelete = bd.Пользователи.Find(selectedUser.IDПользователя);
                        if (userToDelete != null)
                        {
                            bd.Пользователи.Remove(userToDelete);
                            bd.SaveChanges();

                            // Обновляем DataGrid
                            LoadUsers();
                            MessageBox.Show("Пользователь успешно удален!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите пользователя для удаления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}

