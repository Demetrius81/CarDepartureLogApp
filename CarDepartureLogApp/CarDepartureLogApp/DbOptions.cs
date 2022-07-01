using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDepartureLogApp
{
    internal class DbOptions
    {
        public static string ConnectionString { get => @"server=127.0.0.1;port=3306;user=root;password=Pegasus2;database=TestDb;"; }
    }
}
