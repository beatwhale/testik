using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.AppDataFile
{
    class BookObj
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static string Author { get; set; }
        public static int Category_id { get; set; }
        public static string ImagePath { get; set; }

        public virtual BookCategory BookCategory { get; set; }
    }
}
