using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.BuilderProperties;
using System.Xml.Linq;

namespace WebApiWM.Models
{
    public class Warehouse
    {
        public Warehouse(Entities.Склады склады)
        {
            IDСклада = склады.IDСклада;
            Название = склады.Название;
            Адрес = склады.Адрес;
            ТипСклада = склады.ТипСклада;
            ЗонаХранения = склады.ЗонаХранения;
        

        }
        public int IDСклада { get; set; }
        public string Название { get; set; }
        public string Адрес { get; set; }
        public string ТипСклада { get; set; }
        public string ЗонаХранения { get; set; }
    }
}