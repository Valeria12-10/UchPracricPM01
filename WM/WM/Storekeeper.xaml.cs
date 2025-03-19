using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WM;
using ZXing;

namespace WM
{
    public partial class Storekeeper : Window
    {
        private Пользователи _currentUser;
        private int _currentUserId;
        public Storekeeper(int userId)
        {
            InitializeComponent();
            _currentUserId = userId;
            LoadCurrentUserProfile();
            DisplayUserInfo();
            DisplayUserPhoto();
            LoadData();
            LoadInventoryReport();

        }

        private void LoadData()
        {
            using (var bd = new СкладыEntities())
            {
                cbProductIncoming.ItemsSource = bd.Товары.ToList();
                cbProductOutgoing.ItemsSource = bd.Товары.ToList();
                cbProductBarcode.ItemsSource = bd.Товары.ToList();
                cbSupplier.ItemsSource = bd.Поставщики.ToList();
                cbClient.ItemsSource = bd.Клиенты.ToList();
            }
        }

        private void CreateIncomingInvoice_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new СкладыEntities())
            {
                if (cbProductIncoming.SelectedItem == null || cbSupplier.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantityIncoming.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                var selectedProduct = cbProductIncoming.SelectedItem as Товары;
                var selectedSupplier = cbSupplier.SelectedItem as Поставщики;
                int quantity = int.Parse(txtQuantityIncoming.Text);
                DateTime date = dpDateIncoming.SelectedDate ?? DateTime.Now;

                var invoice = new ПриходныеНакладные
                {
                    НомерНакладной = Guid.NewGuid().ToString("N").Substring(0, 10), // Генерация уникального номера
                    ДатаПоступления = date,
                    IDПоставщика = selectedSupplier.IDПоставщика,
                    ОбщаяСумма = selectedProduct.Цена * quantity
                };
                bd.ПриходныеНакладные.Add(invoice);
                bd.SaveChanges();

                var invoiceItem = new ЭлементыПриходнойНакладной
                {
                    IDНакладной = invoice.IDНакладной,
                    IDТовара = selectedProduct.IDТовара,
                    Количество = quantity,
                    Цена = selectedProduct.Цена
                };
                bd.ЭлементыПриходнойНакладной.Add(invoiceItem);
                bd.SaveChanges();

                MessageBox.Show("Приходная накладная оформлена.");
            }
        }

        private void CreateOutgoingInvoice_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new СкладыEntities())
            {
                if (cbProductOutgoing.SelectedItem == null || cbClient.SelectedItem == null || string.IsNullOrWhiteSpace(txtQuantityOutgoing.Text))
                {
                    MessageBox.Show("Заполните все поля.");
                    return;
                }

                var selectedProduct = cbProductOutgoing.SelectedItem as Товары;
                var selectedClient = cbClient.SelectedItem as Клиенты;
                int quantity = int.Parse(txtQuantityOutgoing.Text);
                DateTime date = dpDateOutgoing.SelectedDate ?? DateTime.Now;

                var invoice = new РасходныеНакладные
                {
                    НомерНакладной = Guid.NewGuid().ToString("N").Substring(0, 10), // Генерация уникального номера
                    ДатаОтгрузки = date,
                    IDКлиента = selectedClient.IDКлиента,
                    ОбщаяСумма = selectedProduct.Цена * quantity
                };
                bd.РасходныеНакладные.Add(invoice);
                bd.SaveChanges();

                var invoiceItem = new ЭлементыРасходнойНакладной
                {
                    IDНакладной = invoice.IDНакладной,
                    IDТовара = selectedProduct.IDТовара,
                    Количество = quantity,
                    Цена = selectedProduct.Цена
                };
                bd.ЭлементыРасходнойНакладной.Add(invoiceItem);
                bd.SaveChanges();

                MessageBox.Show("Расходная накладная оформлена.");
            }
        }
        private void GenerateBarcode_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = cbProductBarcode.SelectedItem as Товары;
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите товар.");
                return;
            }
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 200,
                    Height = 100
                }
            };
            var barcodeBitmap = barcodeWriter.Write(selectedProduct.Штрихкод);
            imgBarcode.Source = barcodeBitmap.ToBitmapImage();
        }

        private void PrintBarcode_Click(object sender, RoutedEventArgs e)
        {
            if (imgBarcode.Source == null)
            {
                MessageBox.Show("Сначала сгенерируйте штрихкод.");
                return;
            }
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(imgBarcode, "Печать штрихкода");
            }
        }
        private void LoadInventoryReport()
        {
            using (var bd = new СкладыEntities())
            {
                var report = from i in bd.Инвентаризация
                             join e in bd.ЭлементыИнвентаризации on i.IDИнвентаризации equals e.IDИнвентаризации
                             join t in bd.Товары on e.IDТовара equals t.IDТовара
                             select new
                             {
                                 i.ДатаИнвентаризации,
                                 i.ОтветственноеЛицо,
                                 t.Название,
                                 e.ФактическоеКоличество,
                                 e.УчетноеКоличество,
                                 Расхождение = e.ФактическоеКоличество - e.УчетноеКоличество
                             };

                dgInventoryReport.ItemsSource = report.ToList();
            }
        }

        private void ExportInventoryReport_Click(object sender, RoutedEventArgs e)
        {
            var report = dgInventoryReport.ItemsSource as System.Collections.IEnumerable;
            if (report == null)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Отчет по инвентаризации");
                worksheet.Cells[1, 1].Value = "Дата инвентаризации";
                worksheet.Cells[1, 2].Value = "Ответственное лицо";
                worksheet.Cells[1, 3].Value = "Товар";
                worksheet.Cells[1, 4].Value = "Фактическое количество";
                worksheet.Cells[1, 5].Value = "Учетное количество";
                worksheet.Cells[1, 6].Value = "Расхождение";
                int row = 2;
                foreach (dynamic item in report)
                {
                    worksheet.Cells[row, 1].Value = item.ДатаИнвентаризации;
                    worksheet.Cells[row, 2].Value = item.ОтветственноеЛицо;
                    worksheet.Cells[row, 3].Value = item.Название;
                    worksheet.Cells[row, 4].Value = item.ФактическоеКоличество;
                    worksheet.Cells[row, 5].Value = item.УчетноеКоличество;
                    worksheet.Cells[row, 6].Value = item.Расхождение;
                    row++;
                }

                worksheet.Cells.AutoFitColumns();

                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "Отчет_по_инвентаризации.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);
                    MessageBox.Show("Отчет успешно экспортирован.");
                }
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
    }
}

