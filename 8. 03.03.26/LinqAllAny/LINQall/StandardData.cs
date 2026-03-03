using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQall
{
    public class StandardData
    {
        public static readonly List<Standard> standards = new List<Standard>()
            {
                new Standard() {StandardId = 1, Name = "Standard 1" },
                new Standard() {StandardId = 2, Name = "Standard 2" },
                new Standard() {StandardId = 3, Name = "Standard 3" },
            };
    }
}
