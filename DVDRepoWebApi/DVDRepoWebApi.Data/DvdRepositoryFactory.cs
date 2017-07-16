using DVDRepoWebApi.Data.Repositories;
using DVDRepoWebApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DVDRepoWebApi.Data
{
    public static class DvdRepositoryFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new DVDRepositoryMock();
                case "EntityFramework":
                    return new DVDRepositoryEF();
                case "ADO":
                    return new DVDRepositoryADO();
                default:
                    return null;
            }

        }
    }
}