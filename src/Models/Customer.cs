﻿namespace ProvaPub.Models
{
    public class Customer : BaseEntity
    {
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
