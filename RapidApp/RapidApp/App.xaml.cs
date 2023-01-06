using Prism.DryIoc;
using Prism.Ioc;
using RapidApp.ViewModels;
using RapidApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RapidApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 通过容器开启Window
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PersonalSpaceView, PersonalSpaceViewModel>();
            containerRegistry.RegisterForNavigation<ResourcesView, ResourcesViewModel>();
            containerRegistry.RegisterForNavigation<ProjectSpaceView, ProjectSpaceViewModel>();
        }
    }
}
