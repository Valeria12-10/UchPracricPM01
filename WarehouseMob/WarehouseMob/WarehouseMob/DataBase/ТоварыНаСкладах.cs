using SQLite;

namespace WarehouseMob.DataBase
{
    public class ТоварыНаСкладах
    {
        [PrimaryKey, AutoIncrement]
        public int IDЗаписи { get; set; }

        public int IDТовара { get; set; }
        public int IDСклада { get; set; }
        public int Количество { get; set; }
    }
}
