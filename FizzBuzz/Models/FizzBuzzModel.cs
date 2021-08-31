using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Models
{
    public class FizzBuzzModel
    {
        public int InputFizz { get; set; }
        public int InputBuzz { get; set; }
        public List<string> Result { get; set; } = new();
    }
}
