//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiWM.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class ЭлементыИнвентаризации
    {
        public int IDЭлементаИнвентаризации { get; set; }
        public int IDИнвентаризации { get; set; }
        public int IDТовара { get; set; }
        public int ФактическоеКоличество { get; set; }
        public int УчетноеКоличество { get; set; }
    
        public virtual Инвентаризация Инвентаризация { get; set; }
        public virtual Товары Товары { get; set; }
    }
}
