using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using RapidApp.Common;
using RapidApp.Extensions;
using RapidApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
		private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand GoForwardCommand { get; private set; }
 
		public MainViewModel(IRegionManager regionManager) { 
			MenuBars= new ObservableCollection<MenuBar>();
            CreateMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this.regionManager = regionManager;
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal!=null&& journal.CanGoBack)
                {
                    journal.GoBack();
                }
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal!=null&& journal.CanGoForward)
                {
                    journal.GoForward();
                }
            });
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.NameSpace)) { return; }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                journal=back.Context.NavigationService.Journal;
            });
        }




        #region 侧边栏相关
        public ObservableCollection<MenuBar> MenuBars
		{
			get { return menuBars; }
			set { menuBars = value; }
		}
        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "资源库", NameSpace = "ResourcesView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookOutline", Title = "个人空间", NameSpace = "PersonalSpaceView" });
            MenuBars.Add(new MenuBar() { Icon = "NotebookPlus", Title = "项目空间", NameSpace = "ProjectSpaceView" });             
        }
        #endregion
    }
}
