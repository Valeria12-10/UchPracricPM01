using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMob.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.QrCode.Internal;

namespace WarehouseMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        private readonly DatabaseContext _databaseContext;
        private readonly string _scannedBarcode;

        public ProductDetailPage(string barcode)
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext(); // Инициализация контекста базы данных
            _scannedBarcode = barcode;
            entryBarcode.Text = _scannedBarcode;
        }
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                // Проверка обязательных полей
                if (string.IsNullOrWhiteSpace(entryName.Text) ||
                    string.IsNullOrWhiteSpace(entryArticle.Text) ||
                    string.IsNullOrWhiteSpace(entryPrice.Text) ||
                    string.IsNullOrWhiteSpace(entryBarcode.Text))
                {
                    await DisplayAlert("Ошибка", "Заполните обязательные поля (*)", "OK");
                    return;
                }

                var newProduct = new Товары
                {
                    Название = entryName.Text,
                    Артикул = entryArticle.Text,
                    Категория = entryCategory.Text,
                    Цена = decimal.Parse(entryPrice.Text),
                    Штрихкод = entryBarcode.Text,
                    ЕдиницаИзмерения = entryUnit.Text,
                    СерийныйНомер = entrySerial.Text,
                    МинимальныйЗапас = string.IsNullOrEmpty(entryMinStock.Text)
                        ? 0
                        : int.Parse(entryMinStock.Text)
                };

                await _databaseContext.SaveТоварAsync(newProduct);
                await DisplayAlert("Успех", "Товар добавлен", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Некорректные данные: {ex.Message}", "OK");
            }
        }
    }
}