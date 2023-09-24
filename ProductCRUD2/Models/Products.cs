using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using ProductCRUD2.Models;
using System.Data.SqlClient;

namespace ProductCRUD2.Models
{
	public class Products
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int Amount { get; set; }
	}
}
