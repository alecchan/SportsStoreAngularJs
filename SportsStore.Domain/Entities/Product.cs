﻿using System.ComponentModel.DataAnnotations;

namespace SportsStore.Domain.Entities
{
	public class Product
	{
		public int ProductID { get; set; }

		[Required(ErrorMessage = "Please enter a product name")]
		public string Name { get; set; }

		[DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "Please enter a description")]
		public string Description { get; set; }

		[DataType(DataType.Currency)]
		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Please enter a category")]
		public string Category { get; set; }

		public byte[] ImageData { get; set; }

		public string	ImageMimeType { get; set; }

	}
}