//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WareHouseLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class ЭлементыЗаказа
    {
        public int IDЭлементаЗаказа { get; set; }
        public int IDЗаказа { get; set; }
        public int IDТовара { get; set; }
        public int Количество { get; set; }
        public decimal Цена { get; set; }
    
        public virtual Заказы Заказы { get; set; }
        public virtual Товары Товары { get; set; }
    }
}
