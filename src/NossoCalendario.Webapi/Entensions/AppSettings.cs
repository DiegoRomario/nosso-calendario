﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NossoCalendario.WebApi.Entensions
{
    public class AppSettings
    {
        public string Chave { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string ValidoEm { get; set; }
        public string Emissor { get; set; }
    }
}
