using SQLite;


namespace WarehouseMob.DataBase
{
    public class Склады
    {
        [PrimaryKey, AutoIncrement]
        public int IDСклада { get; set; }

        public string Название { get; set; }
        public string Адрес { get; set; }
        public string ТипСклада { get; set; }
        public string ЗонаХранения { get; set; }
        public double Широта { get; set; }
        public double Долгота { get; set; }

    }
}
