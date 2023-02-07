using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ms.Pago.Infraestructura
{
    public class DBSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }

    }

    public interface IDBSettings
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }

    }
}
