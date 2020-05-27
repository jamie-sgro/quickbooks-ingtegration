﻿using Caliburn.Micro;
using MCBusinessLogic.Controllers;
using MCBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDesktopUI.Models;

namespace WPFDesktopUI.ViewModels {
  public class ShellViewModel : Conductor<object> {

		public ShellViewModel() {
			this.ImportViewModel = new ImportViewModel();
			this.QuickBooksViewModel = new QuickBooksViewModel();
		}

		public ImportViewModel ImportViewModel { get; }
		public QuickBooksViewModel QuickBooksViewModel { get; }

		public void MenuItemClose() {
			Application.Current.Shutdown();
		}

		public void MenuItemMinimize() {
			Application.Current.MainWindow.WindowState = WindowState.Minimized;
		}

		public void MenuItemMaximize() {
			Application.Current.MainWindow.WindowState = WindowState.Maximized;
		}

		public void MenuItemRestore() {
			Application.Current.MainWindow.WindowState = WindowState.Normal;
		}

		public void MenuItemPreferences() {
			IWindowManager manager = new WindowManager();

			manager.ShowWindow(new PreferencesViewModel(), null, null);
		}
    public void MenuItemAbout() {
      IWindowManager manager = new WindowManager();

      manager.ShowWindow(new AboutViewModel(), null, null);
    }
	}
}