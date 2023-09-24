using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using ProductCRUD2.Models;
using System.Data.SqlClient;

namespace ProductCRUD2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		public ProductsController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpGet]
		[Route("GetAllProducts")]

		public Response GetAllProducts()
		{
			SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString()); 
			Response response = new Response();
			CCP ccp = new CCP();
			response = ccp.GetAllProducts(connection);


			return response;
		}

		[HttpGet]
		[Route("GetProductsByID/{id}")]

		public Response GetProductsByID(int id)
		{
			SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
			Response response = new Response();
			CCP ccp = new CCP();
			response = ccp.GetProductsByID(connection,id);


			return response;
		}

		[HttpPost]
		[Route ("CreateProducts")]
		public Response CreateProducts(Products products) 
		{
			SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
			Response response = new Response();	
			CCP cCP= new CCP();
			response = cCP.CreateProducts(connection, products);

			return response;

		}

		[HttpPut]
		[Route("UpdateProducts")]
		public Response UpdateProducts(Products products)
		{
			SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString()); Response response = new Response();
			CCP cCP = new CCP();
			response = cCP.UpdateProducts(connection, products);

			return response;

		}

		[HttpDelete]
		[Route ("DeleteProducts/{id}")]
		public Response DeleteProducts(int id) 
		{
			SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString()); Response response = new Response();	
			CCP cCP = new CCP();
			response = cCP.DeleteProducts(connection, id);
		return response;
		}
	}
	
}
