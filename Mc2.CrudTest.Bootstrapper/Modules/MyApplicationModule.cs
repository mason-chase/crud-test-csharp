using Autofac;
using Mc2.CrudTest.Services.Concretes;
using Mc2.CrudTest.Services.Interfaces;

namespace Mc2.CrudTest.Bootstrapper.Modules;

public class MyApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerDependency();

        //builder.RegisterGeneric(typeof(ValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }
}