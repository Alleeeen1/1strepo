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
	public class Response
	{
		public int StatusCode { get; set; }
		public string StatusMessage { get; set; }

		public Products products { get; set; }

		public List<Products> listproducts { get; set; }

	}
}
