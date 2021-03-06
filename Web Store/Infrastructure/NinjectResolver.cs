using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Web_Store.Controllers;
using Web_Store.Interfaces;
using Web_Store.Models;
using Web_Store.Services;

namespace Web_Store.Infrastructure
{
	public class NinjectResolver : IDependencyResolver
	{
		IKernel _kernel;
		public NinjectResolver(IKernel kernel)
		{
			_kernel = kernel;
			AddBindings();

		}

		public void AddBindings()
		{
			_kernel.Bind<IProduct>().To<ProductServices>();
			_kernel.Bind<ICart>().To<CartServices>();
			_kernel.Bind<IShopTupleData>().To<ShopTupleData>();
			_kernel.Bind<ApplicationDbContext>().ToSelf();
			_kernel.Bind<IAdmin>().To<AdminServices>();
			_kernel.Bind<ICustomer>().To<CustomerServices>();
			_kernel.Bind<ICategory>().To<CategoryServices>();
		}

		public object GetService(Type serviceType) => _kernel.TryGet(serviceType);

		public IEnumerable<object> GetServices(Type serviceType) => _kernel.GetAll(serviceType);
	}
}