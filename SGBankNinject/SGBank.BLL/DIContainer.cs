using Ninject;
using Ninject.Modules;
using SGBank.Data;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class DIContainer //: NinjectModule
    {
        public static IKernel Kernel = new StandardKernel();

        static DIContainer()
        {
            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode)
            {
                case "FreeTest":
                    Kernel.Bind<IAccountRepository>().To<FreeAccountTestRepository>();
                    break;
                    //return new AccountManager(new FreeAccountTestRepository());
                case "BasicTest":
                    Kernel.Bind<IAccountRepository>().To<BasicAccountTestRepository>();
                    break;
                case "PremiumTest":
                    Kernel.Bind<IAccountRepository>().To<PremiumAccountTestRepository>();
                    break;
                case "FileTest":
                    Kernel.Bind<IAccountRepository>().To<FileAccountRepository>();
                    break;
                default:
                    throw new Exception("Mode value in app.config is not valid.");
            }

        }
    }
}
