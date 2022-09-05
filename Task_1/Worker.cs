using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public struct Worker
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfEdit { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public int Growth { get; set; }
        public string Born { get; set; }
        public string PlaceOfBorn { get; set; }
    }
}
