using SQLite;

namespace WarehouseMob.DataBase
{
    public class Товары
    {
        [PrimaryKey, AutoIncrement]
        public int IDТовара { get; set; }

        public string Название { get; set; }
        public string Артикул { get; set; }
        public string Штрихкод { get; set; }
        public string Категория { get; set; }
        public string ЕдиницаИзмерения { get; set; }
        public decimal Цена { get; set; }
        public string СерийныйНомер { get; set; }
        public int МинимальныйЗапас { get; set; }
    }
}
