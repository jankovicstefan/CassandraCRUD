using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CassandraCRUD.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public String CategoryName { get; set; }
    }
}