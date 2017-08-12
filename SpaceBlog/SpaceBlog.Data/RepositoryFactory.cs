using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBlog.Data.Interfaces;
using SpaceBlog.Data.Repositories;

namespace SpaceBlog.Data
{
    public class RepositoryFactory 
    {
        public static ISpaceBlogRepository Create()
        {
            string config = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (config)
            {
                case "MockRepository":
                    return new MockRepository();
                case "EFRepository":
                    return new EntityFrameworkRepo();
            }
            return null;
        }
    }
}
