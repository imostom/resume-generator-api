using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Models
{
    public class AppConfigurations
    {
        public string ConnectionString { get; set; }
        public string PostmarkUrl { get; set; }
        public string PostmarkToken { get; set; }
    }
}
