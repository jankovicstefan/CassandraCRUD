using Cassandra.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CassandraCRUD.Models
{
    [Table(Keyspace="findjob", Name="jobs")]
    public class Job
    {
        [PartitionKey]
        [Column("jobID")]
        public Guid Id { get; set; }
        [Column("jobtitle")]
        public String JobTitle { get; set; }
        [Column("company")]
        public String Company { get; set; }
        [Column("category")]
        public String Category { get; set; }
        [Column("email")]
        public String Email { get; set; }
        [Column("city")]
        public String City { get; set; }
        [Column("phone")]
        public String Phone { get; set; }
        [Column("description")]
        public String Description { get; set; }
    }
}