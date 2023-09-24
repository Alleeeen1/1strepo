using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using ProductCRUD2.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProductCRUD2.Models
{
	public class CCP
	{
		public Response GetAllProducts (SqlConnection connection)

		{
			Response response = new Response();
			SqlDataAdapter da = new SqlDataAdapter("SELECT * from tblCurd", connection);
			DataTable dt = new DataTable();
			da.Fill(dt);
			List<Products> listProducts = new List<Products>();
			if (dt.Rows.Count > 0 )
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{

					Products prods = new Products();
					prods.Id = Convert.ToInt32(dt.Rows[i]["ID"]);
					prods.Name = Convert.ToString(dt.Rows[i]["Name"]);
					prods.Amount = Convert.ToInt32(dt.Rows[i]["Amount"]);

					listProducts.Add(prods);

				}
			}
			if (listProducts.Count > 0 ) 
			{
				response.StatusCode= 200;
				response.StatusMessage = "Data Found";
				response.listproducts= listProducts;

			}
			else
			{
				response.StatusCode = 100;
				response.StatusMessage = "Data Not Found";
				response.listproducts = null;

			}

			return response;

		}

		public Response GetProductsByID(SqlConnection connection, int id)

		{
			Response response = new Response();
			SqlDataAdapter da = new SqlDataAdapter("SELECT * from tblCurd WHERE ID = '" +id+"'", connection);
			DataTable dt = new DataTable();
			da.Fill(dt);
			Products Products = new Products();
			if (dt.Rows.Count > 0)
			{

					Products prods = new Products();
					prods.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
					prods.Name = dt.Rows[0]["Name"].ToString();
					prods.Amount = Convert.ToInt32(dt.Rows[0]["Amount"]);

					response.StatusCode = 200;
					response.StatusMessage = "Data Found";
					response.products = prods;

			}
			
			else
			{
				response.StatusCode = 100;
				response.StatusMessage = "Data Not Found";
				response.products = null;

			}

			return response;

		}

		public Response CreateProducts(SqlConnection connection, Products products)

		{
			Response response = new Response();
			SqlCommand cmd = new SqlCommand("INSERT INTO tblCurd (Name,Amount,CreatedDate) VALUES ('"+products.Name+ "', '"+products.Amount+ "',GETDATE ())", connection);
			connection.Open();
			int i = cmd.ExecuteNonQuery();
			connection.Close();

			if (i > 0)
			{

				response.StatusCode = 200;
				response.StatusMessage = "Product Added"; 

			}

			else
			{
				response.StatusCode = 100;
				response.StatusMessage = "Product Not Added"; 

			}

			return response;

		}

		public Response UpdateProducts(SqlConnection connection, Products products)

		{
			Response response = new Response();
			SqlCommand cmd = new SqlCommand("UPDATE tblCurd SET Name = '" + products.Name + "',Amount = '" + products.Amount + "'WHERE ID = '"+products.Id+"' ", connection);
			connection.Open();
			int i = cmd.ExecuteNonQuery();
			connection.Close();

			if (i > 0)
			{

				response.StatusCode = 200;
				response.StatusMessage = "Product Updated";

			}

			else
			{
				response.StatusCode = 100;
				response.StatusMessage = "Product Not Updated";

			}

			return response;

		}

		public Response DeleteProducts(SqlConnection connection, int ID) 
		{
			Response response = new Response();
			SqlCommand cmd = new SqlCommand("DELETE from tblCurd WHERE ID = '"+ID+"'",connection);
			connection.Open();
			int i = cmd.ExecuteNonQuery();
			connection.Close();

			if (i > 0) 
			{
				response.StatusCode=200;
				response.StatusMessage = "Product Deleted!";
			}
			else
			{
				response.StatusCode = 100;
				response.StatusMessage = "Product Deleted Failed!";

			}
			return response;

		
		}
	}
}
