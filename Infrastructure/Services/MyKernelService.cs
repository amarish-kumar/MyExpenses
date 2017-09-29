namespace Infrastructure.Services
{
    using CrossCutting.IoC;
    using Ninject.Modules;

    public static class MyKernelService
    {
        public static void Init()
        {
            MyKernel.Init();
        }

        public static void AddModule(INinjectModule module)
        {
            MyKernel.AddModule(module);
        }

        public static T GetInstance<T>()
        {
            return MyKernel.GetInstance<T>();
        }
    }
}
