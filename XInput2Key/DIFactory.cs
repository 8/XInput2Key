namespace XInput2Key
{
    using Autofac;
    using System.Reflection;

    class DIFactory
    {
        public ILifetimeScope GetLifetimeScope()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).InNamespace("XInput2Key.Factory").AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).InNamespace("XInput2Key.ViewModel").AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).InNamespace("XInput2Key.Service").AsImplementedInterfaces().SingleInstance();

            return builder.Build();
        }
    }
}
