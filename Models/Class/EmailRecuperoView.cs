﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brianzo_Inmobiliaria.Models
{
	public class EmailRecuperoView
	{
		public string Enlace { get; set; }
		public string Nombre { get; set; }
		public string Token { get; set; }
	}
}
