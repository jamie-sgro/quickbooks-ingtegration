﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using Caliburn.Micro;
using WPFDesktopUI.Controllers;
using WPFDesktopUI.Models.PluginModels;
using WPFDesktopUI.ViewModels.Interfaces;

namespace WPFDesktopUI.ViewModels {
  public sealed class PluginViewModel : Conductor<object>, IPluginViewModel {
    public PluginViewModel() {
      log.Debug("Querying sql and directory for plugins");
      PluginModel = Factory.CreatePluginModel();

      ReactiveCollection = new ObservableCollection<ClientPlugin>(PluginModel.PluginModels);
    }

    public IPluginModel PluginModel { get; set; }
    public ObservableCollection<ClientPlugin> ReactiveCollection { get; set; }
    public string Title { get; set; } = "Plugin Manager";



    public event PropertyChangedEventHandler PropertyChanged;
    public void OnCellEditEnding() {
      Title = Title.Replace("*", "");
      Title += "*";
      CanBtnUpdate = true;
    }

    public bool CanBtnUpdate { get; set; } = false;

    public void BtnUpdate() {
      log.Debug("Saving plugins to sql");
      PluginModel.Update(ReactiveCollection);
      Title = Title.Replace("*", "");
      CanBtnUpdate = false;
    }

    private static readonly log4net.ILog log = LogHelper.GetLogger();
  }
}