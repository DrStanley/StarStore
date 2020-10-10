using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Web_Store.Controllers;
using Web_Store.Interfaces;
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
			_kernel.Bind<ICart>().To<CartServices>().WhenInjectedInto<ShopController>();
			_kernel.Bind<IShopTupleData>().To<ShopTupleData>().WhenInjectedInto<ShopController>();
			_kernel.Bind<IAdmin>().To<AdminServices>();
			_kernel.Bind<ICustomer>().To<CustomerServices>();
		}

		public object GetService(Type serviceType) => _kernel.TryGet(serviceType);

		public IEnumerable<object> GetServices(Type serviceType) => _kernel.GetAll(serviceType);
	}
}