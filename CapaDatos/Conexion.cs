﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class Conexion
    {
        public static string CN = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
    }
}
