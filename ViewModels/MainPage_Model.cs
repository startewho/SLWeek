﻿using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using SLWeek.Models;
using SLWeek.Views;
namespace SLWeek.ViewModels
{

    [DataContract]
    public class MainPage_Model : ViewModelBase<MainPage_Model>
    {
        // If you have install the code sniplets, use "propvm + [tab] +[tab]" create a property propcmd for command
        // 如果您已经安装了 MVVMSidekick 代码片段，请用 propvm +tab +tab 输入属性 propcmd 输入命令

        public MainPage_Model()
        {
            this.IsSplitViewPaneOpen = !this.IsSplitViewPaneOpen;
           
            MenuItems.Add(new MenuItem { Icon = "", Title = "频道", PageType = typeof(ChannelPage) });
            MenuItems.Add(new MenuItem { Icon = "", Title = "专栏", PageType = typeof(AuthorPage) });
            SelectedMenuItem = MenuItems.First();
        }

        private ObservableCollection<MenuItem> menuItems = new ObservableCollection<MenuItem>();

       

        public bool IsSplitViewPaneOpen
        {
            get { return _IsSplitViewPaneOpenLocator(this).Value; }
            set { _IsSplitViewPaneOpenLocator(this).SetValueAndTryNotify(value); }
        }
        #region Property bool IsSplitViewPaneOpen Setup        
        protected Property<bool> _IsSplitViewPaneOpen = new Property<bool> { LocatorFunc = _IsSplitViewPaneOpenLocator };
        static Func<BindableBase, ValueContainer<bool>> _IsSplitViewPaneOpenLocator = RegisterContainerLocator<bool>("IsSplitViewPaneOpen", model => model.Initialize("IsSplitViewPaneOpen", ref model._IsSplitViewPaneOpen, ref _IsSplitViewPaneOpenLocator, _IsSplitViewPaneOpenDefaultValueFactory));
        static Func<bool> _IsSplitViewPaneOpenDefaultValueFactory = () => default(bool);
        #endregion


        public MenuItem SelectedMenuItem
        {
            get { return _SelectedMenuItemLocator(this).Value; }
            set
            {
                
                    _SelectedMenuItemLocator(this).SetValueAndTryNotify(value);
                    _IsSplitViewPaneOpenLocator(this).SetValueAndTryNotify(false);
                    _SelectedPageTypeLocator(this).SetValueAndTryNotify(value.PageType);
              
             
            }
        }
        #region Property MenuItem SelectedMenuItem Setup        
        protected Property<MenuItem> _SelectedMenuItem = new Property<MenuItem> { LocatorFunc = _SelectedMenuItemLocator };
        static Func<BindableBase, ValueContainer<MenuItem>> _SelectedMenuItemLocator = RegisterContainerLocator<MenuItem>("SelectedMenuItem", model => model.Initialize("SelectedMenuItem", ref model._SelectedMenuItem, ref _SelectedMenuItemLocator, _SelectedMenuItemDefaultValueFactory));
        static Func<MenuItem> _SelectedMenuItemDefaultValueFactory = () => default(MenuItem);
        #endregion


        public Type SelectedPageType
        {
            get
            {
                if (this.SelectedMenuItem != null)
                {
                    return this.SelectedMenuItem.PageType;
                }
                return null;
            }
            set {
                
              
                this.SelectedMenuItem = this.menuItems.FirstOrDefault(m => m.PageType == value);

            }
        }
        #region Property Type SelectedPageType Setup        
        protected Property<Type> _SelectedPageType = new Property<Type> { LocatorFunc = _SelectedPageTypeLocator };
        static Func<BindableBase, ValueContainer<Type>> _SelectedPageTypeLocator = RegisterContainerLocator<Type>("SelectedPageType", model => model.Initialize("SelectedPageType", ref model._SelectedPageType, ref _SelectedPageTypeLocator, _SelectedPageTypeDefaultValueFactory));
        static Func<Type> _SelectedPageTypeDefaultValueFactory = () => default(Type);
        #endregion


        public ObservableCollection<MenuItem> MenuItems
        {
            get { return this.menuItems; }
        }

    }

}

