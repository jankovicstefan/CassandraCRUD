using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cassandra;
using Cassandra.Mapping;
using CassandraCRUD.Models;
namespace CassandraCRUD
{
    public static class SessionManager
    {
        public static ISession session;
        public static IMapper mapper;

        public static IMapper getMapper()
        {
            if (session == null)
            {
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                session = cluster.Connect("findjob");
                mapper = new Mapper(session);
                
            }

            return mapper;
        }
    }
}