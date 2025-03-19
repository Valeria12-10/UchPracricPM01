using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WarehouseMob.DataBase;
using Xamarin.Essentials;

namespace WarehouseMob
{
    public class DatabaseContext
    {
        private SQLiteAsyncConnection _database;

        public DatabaseContext()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "sklade.db");
            _database = new SQLiteAsyncConnection(databasePath);

            // Создаем таблицы
            _database.CreateTableAsync<Пользователи>().Wait();
            _database.CreateTableAsync<Склады>().Wait();
            _database.CreateTableAsync<Товары>().Wait();
            _database.CreateTableAsync<ТоварыНаСкладах>().Wait();

            // Вызов асинхронного метода
            InitializeTestDataAsync().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Console.WriteLine($"Ошибка инициализации складов: {t.Exception.Message}");
                }
            });
            InitializeTestDataAsync1().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Console.WriteLine($"Ошибка инициализации пользователей: {t.Exception.Message}");
                }
            });
            InitializeTestDataAsync2().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Console.WriteLine($"Ошибка инициализации товаров: {t.Exception.Message}");
                }
            });
            InitializeStockDataAsync().ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    Console.WriteLine($"Ошибка инициализации товаров на складах: {t.Exception.Message}");
                }
            });
        }
        private async Task InitializeTestDataAsync()
        {
            var склады = await _database.Table<Склады>().ToListAsync();
            if (склады.Count == 0)
            {
                var testСклады = new List<Склады>
        {
            new Склады
            {
                Название = "Склад 1",
                Адрес = "Советская ул 93, Слободской",
                ТипСклада = "Основной",
                ЗонаХранения = "Зона А",
                Широта = 58.727602,
                Долгота = 50.183471
            },
            new Склады
            {
                Название = "Склад 2",
                Адрес = "Советская ул 67, Слободской",
                ТипСклада = "Основной",
                ЗонаХранения = "Зона Б",
                Широта = 58.732638,
                Долгота = 50.182623
            },
            new Склады
            {
                Название = "Склад 3",
                Адрес = "Советская ул 37Ф, Слободской",
                ТипСклада = "Дополнительный",
                ЗонаХранения = "Зона В",
                Широта = 58.737986,
                Долгота = 50.181688
            },
            new Склады
            {
                Название = "Склад 4",
                Адрес = "Советская ул 155, Слободской",
                ТипСклада = "Основной",
                ЗонаХранения = "Зона Г",
                Широта = 58.711163,
                Долгота = 50.196843
            },
            new Склады
            {
                Название = "Склад 5",
                Адрес = "Рождественская ул 72, Слободской",
                ТипСклада = "Дополнительный",
                ЗонаХранения = "Зона Д",
                Широта = 58.729237,
                Долгота = 50.181203
            },
            new Склады
            {
                Название = "Склад 6",
                Адрес = "ул Степана Халтурина 11, Слободской",
                ТипСклада = "Основной",
                ЗонаХранения = "Зона Е",
                Широта = 58.728779,
                Долгота = 50.182120
            },
            new Склады
            {
                Название = "Склад 7",
                Адрес = "ул Карла Маркса 48, Слободской",
                ТипСклада = "Дополнительный",
                ЗонаХранения = "Зона Ж",
                Широта = 58.735468,
                Долгота = 50.168959
            },
            new Склады
            {
                Название = "Склад 8",
                Адрес = "Первомайская ул 3, Слободской",
                ТипСклада = "Основной",
                ЗонаХранения = "Зона З",
                Широта = 58.740232,
                Долгота = 50.181365
            },
            new Склады
            {
                Название = "Склад 9",
                Адрес = "ул Грина 45, Слободской",
                ТипСклада = "Дополнительный",
                ЗонаХранения = "Зона И",
                Широта = 58.724369,
                Долгота = 50.166848
            }
        };

                foreach (var склад in testСклады)
                {
                    await _database.InsertAsync(склад);
                }
            }
        }
        private async Task InitializeTestDataAsync1()
        {
            var пользователи = await _database.Table<Пользователи>().ToListAsync();
            if (пользователи.Count == 0)
            {
                var testUsers = new List<Пользователи>
        {
            new Пользователи
            {
                IDПользователя = 1,
                ИмяПользователя = "Валерия Поглазова",
                Email = "valeria1739poglaz@gmail.com",
                ХэшПароля = PasswordHelper.HashPassword("admin1234"), // Хэшируем пароль
                Роль = "Администратор",
                Токен = "123456"
            },
            new Пользователи
            {
                IDПользователя = 2,
                ИмяПользователя = "Никита Михалков",
                Email = "valeria1739poglazova@gmail.com",
                ХэшПароля = PasswordHelper.HashPassword("tweette"), // Хэшируем пароль
                Роль = "Кладовщик",
                Токен = "123457"
            },
            new Пользователи
            {
                IDПользователя = 3,
                ИмяПользователя = "Анастасия Мурина",
                Email = "valeria1739poglazov@gmail.com",
                ХэшПароля = PasswordHelper.HashPassword("account1234"), // Хэшируем пароль
                Роль = "Бухгалтер",
                Токен = "122345"
            },
            new Пользователи
            {
                IDПользователя = 4,
                ИмяПользователя = "Павел Гилёв",
                Email = "valeria1739poglazo@gmail.com",
                ХэшПароля = PasswordHelper.HashPassword("manager1234"), // Хэшируем пароль
                Роль = "Менеджер по продажам",
                Токен = "112236"
            }
        };

                foreach (var user in testUsers)
                {
                    await _database.InsertAsync(user);
                }

            }
        }
        private async Task InitializeTestDataAsync2()
        {
            var товары = await _database.Table<Товары>().ToListAsync();
            if (товары.Count == 0)
            {
                var testТовары = new List<Товары>
            {
                new Товары
                {
                    Название = "Ноутбук ASUS VivoBook 15",
                    Артикул = "NB-ASUS-001",
                    Штрихкод = "123456789012",
                    Категория = "Электроника",
                    ЕдиницаИзмерения = "шт",
                    Цена = 54999.99m,
                    СерийныйНомер = "SN-ASUS-2023-001",
                    МинимальныйЗапас = 20
                },
                new Товары
                {
                    Название = "Смартфон Xiaomi Redmi Note 12",
                    Артикул = "PH-XIAOMI-002",
                    Штрихкод = "234567890123",
                    Категория = "Электроника",
                    ЕдиницаИзмерения = "шт",
                    Цена = 24999.99m,
                    СерийныйНомер = "SN-XIAOMI-2023-002",
                    МинимальныйЗапас = 20
                },
                new Товары
                {
                    Название = "Монитор Dell 27\" S2721HS",
                    Артикул = "MON-DELL-003",
                    Штрихкод = "345678901234",
                    Категория = "Компьютерная техника",
                    ЕдиницаИзмерения = "шт",
                    Цена = 28999.99m,
                    СерийныйНомер = "SN-DELL-2023-003",
                    МинимальныйЗапас = 20
                },
                new Товары
                {
                    Название = "Принтер HP LaserJet Pro M15w",
                    Артикул = "PRN-HP-004",
                    Штрихкод = "456789012345",
                    Категория = "Офисная техника",
                    ЕдиницаИзмерения = "шт",
                    Цена = 14999.99m,
                    СерийныйНомер = "SN-HP-2023-004",
                    МинимальныйЗапас = 20
                },
                new Товары
                {
                    Название = "Наушники JBL Tune 510BT",
                    Артикул = "HPH-JBL-005",
                    Штрихкод = "567890123456",
                    Категория = "Аксессуары",
                    ЕдиницаИзмерения = "шт",
                    Цена = 3999.99m,
                    СерийныйНомер = "SN-JBL-2023-005",
                    МинимальныйЗапас = 20
                }
            };

                foreach (var товар in testТовары)
                {
                    await _database.InsertAsync(товар);
                }
            }
        }
        private async Task InitializeStockDataAsync()
        {
            // Проверяем, есть ли уже записи в таблице ТоварыНаСкладах
            var stockItems = await _database.Table<ТоварыНаСкладах>().ToListAsync();
            if (stockItems.Count == 0)
            {
                // Создаем тестовые данные для таблицы ТоварыНаСкладах
                var testStockItems = new List<ТоварыНаСкладах>
        {
            new ТоварыНаСкладах
            {
                IDСклада = 1, // ID первого склада
                IDТовара = 1, // ID первого товара
                Количество = 10 // Количество товара на складе
            },
            new ТоварыНаСкладах
            {
                IDСклада = 1, // ID первого склада
                IDТовара = 2, // ID второго товара
                Количество = 5 // Количество товара на складе
            },
            new ТоварыНаСкладах
            {
                IDСклада = 2, // ID второго склада
                IDТовара = 3, // ID третьего товара
                Количество = 8 // Количество товара на складе
            },
            new ТоварыНаСкладах
            {
                IDСклада = 2, // ID второго склада
                IDТовара = 4, // ID четвертого товара
                Количество = 12 // Количество товара на складе
            },
            new ТоварыНаСкладах
            {
                IDСклада = 3, // ID третьего склада
                IDТовара = 5, // ID пятого товара
                Количество = 3 // Количество товара на складе
            }
        };

                // Сохраняем тестовые данные в таблицу ТоварыНаСкладах
                foreach (var stockItem in testStockItems)
                {
                    await _database.InsertAsync(stockItem);
                }
            }
        }
        // Методы для работы с таблицей "Пользователи"
        public Task<List<Пользователи>> GetПользователиAsync()
        {
            return _database.Table<Пользователи>().ToListAsync();
        }

        public Task<Пользователи> GetПользовательAsync(string имяПользователя)
        {
            return _database.Table<Пользователи>()
                .FirstOrDefaultAsync(u => u.ИмяПользователя == имяПользователя);
        }

        public Task<int> SaveПользовательAsync(Пользователи пользователь)
        {
            if (пользователь.IDПользователя != 0)
            {
                return _database.UpdateAsync(пользователь);
            }
            else
            {
                return _database.InsertAsync(пользователь);
            }
        }
        public Task<Пользователи> GetПользовательПоПочтеAsync(string email)
        {
            return _database.Table<Пользователи>()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        // Методы для работы с таблицей "Склады"
        public Task<List<Склады>> GetСкладыAsync()
        {
            return _database.Table<Склады>().ToListAsync();
        }

        public Task<int> SaveСкладAsync(Склады склад)
        {
            if (склад.IDСклада != 0)
            {
                return _database.UpdateAsync(склад);
            }
            else
            {
                return _database.InsertAsync(склад);
            }
        }

        // Методы для работы с таблицей "Товары"
        public Task<List<Товары>> GetТоварыAsync()
        {
            return _database.Table<Товары>().ToListAsync();
        }

        public Task<Товары> GetТоварПоШтрихкодуAsync(string штрихкод)
        {
            return _database.Table<Товары>()
                .FirstOrDefaultAsync(t => t.Штрихкод == штрихкод);
        }

        public Task<int> SaveТоварAsync(Товары товар)
        {
            if (товар.IDТовара != 0)
            {
                return _database.UpdateAsync(товар);
            }
            else
            {
                return _database.InsertAsync(товар);
            }
        }
        public Task<Товары> GetТоварAsync(int idТовара)
        {
            return _database.Table<Товары>()
                .FirstOrDefaultAsync(t => t.IDТовара == idТовара);
        }

        // Методы для работы с таблицей "ТоварыНаСкладах"
        public Task<List<ТоварыНаСкладах>> GetТоварыНаСкладахAsync()
        {
            return _database.Table<ТоварыНаСкладах>().ToListAsync();
        }

        public Task<List<ТоварыНаСкладах>> GetТоварыНаСкладеAsync(int idСклада)
        {
            return _database.Table<ТоварыНаСкладах>()
                .Where(t => t.IDСклада == idСклада)
                .ToListAsync();
        }

        public Task<int> SaveТоварНаСкладеAsync(ТоварыНаСкладах запись)
        {
            if (запись.IDЗаписи != 0)
            {
                return _database.UpdateAsync(запись);
            }
            else
            {
                return _database.InsertAsync(запись);
            }
        }
    }
}