using System;

namespace WebApiWM.Models
{
    public class Products
    {
        public Products(Entities.Товары товар) 
        {
            IDТовара = товар.IDТовара;
            Название = товар.Название;
            Артикул = товар.Артикул;
            Штрихкод = товар.Штрихкод;
            Категория = товар.Категория;
            ЕдиницаИзмерения = товар.ЕдиницаИзмерения;
            Цена = товар.Цена;
            СерийныйНомер = товар.СерийныйНомер;
            МинимальныйЗапас = товар.МинимальныйЗапас;
        }

        public int IDТовара { get; set; }
        public string Название { get; set; }
        public string Артикул { get; set; }
        public string Штрихкод { get; set; }
        public string Категория { get; set; }
        public string ЕдиницаИзмерения { get; set; }
        public decimal Цена { get; set; }
        public string СерийныйНомер { get; set; }
        public int? МинимальныйЗапас { get; set; }
    }
}
