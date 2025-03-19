using SQLite;


namespace WarehouseMob.DataBase
{
    public class Пользователи
    {
        [PrimaryKey, AutoIncrement]
        public int IDПользователя { get; set; }

        public string ИмяПользователя { get; set; }
        public string Email { get; set; }
        public string ХэшПароля { get; set; }
        public string Роль { get; set; }
        public string Фото { get; set; }
        public string Токен { get; set; }
    }
}
