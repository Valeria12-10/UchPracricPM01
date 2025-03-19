using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using WarehouseMob.DataBase;
using ZXing;
using System.Threading.Tasks;

namespace WarehouseMob
{
    public partial class BarcodeScanPage : ContentPage
    {
        private readonly DatabaseContext _databaseContext;

        public BarcodeScanPage()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
            scannerView.IsScanning = true;
            scannerView.IsAnalyzing = true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Задержка перед запуском камеры
            await Task.Delay(500); // 500 мс

            scannerView.IsScanning = true;
            scannerView.IsAnalyzing = true;
        }


        protected override void OnDisappearing()
        {
           
            base.OnDisappearing();
            scannerView.IsScanning = false;
            scannerView.IsAnalyzing = false;
        }

       
        private async void Handle_OnScanResult(Result result)
        {
            scannerView.IsAnalyzing = false;

            try
            {
                var barcode = result.Text;
                resultLabel.Text = $"Найден штрих-код: {barcode}";

                var product = await _databaseContext.GetТоварПоШтрихкодуAsync(barcode);

                if (product != null)
                {
                    await DisplayAlert("Информация о товаре",
                        $"Название: {product.Название}\n" +
                        $"Артикул: {product.Артикул}\n" +
                        $"Категория: {product.Категория}\n" +
                        $"Цена: {product.Цена:C}\n" +
                        $"Штрих-код: {product.Штрихкод}\n" +
                        $"Ед. измерения: {product.ЕдиницаИзмерения}\n" +
                        $"Серийный номер: {product.СерийныйНомер}\n" +
                        $"Мин. запас: {product.МинимальныйЗапас}",
                        "OK");
                }
                else
                {
                    var shouldAdd = await DisplayAlert("Не найдено",
                        "Добавить новый товар?", "Да", "Нет");

                    if (shouldAdd)
                    {
                        await Navigation.PushAsync(new ProductDetailPage(barcode));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.InnerException?.Message ?? ex.Message}");
                await DisplayAlert("Ошибка", $"Произошла ошибка: {ex.InnerException?.Message ?? ex.Message}", "OK");
            }
            finally
            {
                scannerView.IsAnalyzing = true;
            }
        }

        private async void OnManualInputClicked(object sender, EventArgs e)
        {
            var barcode = await DisplayPromptAsync("Ручной ввод",
                "Введите штрих-код:", "OK", "Отмена",
                maxLength: 20,
                keyboard: Keyboard.Numeric);

            if (!string.IsNullOrEmpty(barcode))
            {
                var product = await _databaseContext.GetТоварПоШтрихкодуAsync(barcode);

                if (product != null)
                {
                    await DisplayAlert("Информация о товаре",
                        $"Название: {product.Название}\n" +
                        $"Артикул: {product.Артикул}\n" +
                        $"Категория: {product.Категория}\n" +
                        $"Цена: {product.Цена:C}\n" +
                        $"Штрих-код: {product.Штрихкод}\n" +
                        $"Ед. измерения: {product.ЕдиницаИзмерения}\n" +
                        $"Серийный номер: {product.СерийныйНомер}\n" +
                        $"Мин. запас: {product.МинимальныйЗапас}",
                        "OK");
                }
                else
                {
                    var shouldAdd = await DisplayAlert("Не найдено",
                        "Добавить новый товар?", "Да", "Нет");

                    if (shouldAdd) await Navigation.PushAsync(new ProductDetailPage(barcode));
                }
            }
        }
    }
}