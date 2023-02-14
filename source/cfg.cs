using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZPInfo
{
    public static class cfg
    {
        public static Dictionary<string, string> CAT = new Dictionary<string, string>() 
        {
            {"OKLAD","Должностной оклад"},
            {"PREM", "Премия"},
            {"RAZ", "Разовое поощрение"},
            {"STAG", "Трудовой стаж"},
            {"DOST", "Высокие достижения"},
            {"MAST", "Проф.мастерство"},
            {"CLASS", "Классность"},
            {"EOTP", "Ежегодный отпуск"},
            {"DOTP", "Дополн. отпуск"},
            {"NO4", "Ночное время"},
            {"VIH", "Работа в выходные"},
            {"SVERH", "Сверхурочная работа"},
            {"SOVM", "Совмещение"},
            {"NDFL", "НДФЛ"},
            {"STRAH", "Страхование"},
            {"PROF", "Профсоюз"},
            {"THIRD", "Третьим лицам"},
            {"ZAD", "Задолженность"}
        };

        public static Dictionary<string, double> CATVALUE = new Dictionary<string, double>() 
        {
            {"OKLAD",0},
            {"PREM", 0},
            {"RAZ", 0},
            {"STAG", 0},
            {"DOST", 0},
            {"MAST", 0},
            {"CLASS", 0},
            {"EOTP", 0},
            {"DOTP", 0},
            {"NO4", 0},
            {"VIH", 0},
            {"SVERH", 0},
            {"SOVM", 0},
            {"NDFL", 0},
            {"STRAH", 0},
            {"PROF", 0},
            {"THIRD", 0},
            {"ZAD", 0}
        };

        public static Dictionary<string, int> CATTYPE = new Dictionary<string, int>() 
        {
            {"OKLAD",0},
            {"PREM", 0},
            {"RAZ", 0},
            {"STAG", 0},
            {"DOST", 0},
            {"MAST", 0},
            {"CLASS", 0},
            {"EOTP", 0},
            {"DOTP", 0},
            {"NO4", 0},
            {"VIH", 0},
            {"SVERH", 0},
            {"SOVM", 0},
            {"NDFL", 0},
            {"STRAH", 0},
            {"PROF", 0},
            {"THIRD", 0},
            {"ZAD", 0}
        };      
    }    
}        
         