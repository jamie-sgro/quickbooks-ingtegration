﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;
using WPFDesktopUI.Models.ItemReplacerModels.Interfaces;
using WPFDesktopUI.ViewModels.Interfaces;

namespace WPFDesktopUI.ViewModels {
  public class ItemViewModel : Screen, IItemViewModel<IItemReplacer> {
    private string _type;

    public ItemViewModel() {
      ItemModel = Factory.CreateItemModel();

      // TODO: Delete
      /*ItemReplacers = new ObservableCollection<IItemReplacer> {
        Factory.CreateItemReplacer("PSW", "Barrie Connie Thompson- PSW"),
        Factory.CreateItemReplacer("PSW", "CLASS - PSW1"),
        Factory.CreateItemReplacer("PSW", "Villa (PSW)"),
        Factory.CreateItemReplacer("PSW", "Villa (PSW) Night Shift"),
        Factory.CreateItemReplacer("RN", "Barrie Connie Thompson- RN"),
        Factory.CreateItemReplacer("RN", "CLASS - RN1"),
        Factory.CreateItemReplacer("RN - WKD", "Barrie Connie Thompson- RN- Weekend"),
        Factory.CreateItemReplacer("RN - WKD", "CLASS - RN1- Weekend"),
        Factory.CreateItemReplacer("RN - STAT", "Barrie Connie Thompson- RN - Stat Holiday"),
        Factory.CreateItemReplacer("RN - STAT", "CLASS - RN1 - STAT")
      };*/
    }



    public IItemModel<IItemReplacer> ItemModel { get; set; }

    public string SearchBar {
      get => ItemModel.Filter;
      set {
        ItemModel.Filter = value;
        NotifyOfPropertyChange(() => PrimaryPane);
      } 
    }

    public ObservableCollection<IItemReplacer> PrimaryPane => ItemModel.UniqueReplaceWith();

    public ObservableCollection<IItemReplacer> SecondaryPane {
      get => ItemModel.SelectedItem;
      set => ItemModel.SelectedItem = value;
    }


    public string TabHeader { get; set; } = "Item";
    public void OnSelected() {
    }
    public ObservableCollection<IItemReplacer> ItemReplacers { get; set; }
    //public ObservableCollection<IItemReplacer> SelectedItem { get; set; }
    //public string SelectedKey { get; set; }
    /*public ObservableCollection<IItemReplacer> UniqueReplaceWith {
      get {
        return new ObservableCollection<IItemReplacer>(ItemReplacers
          .GroupBy(x => x.ReplaceWith)
          .Select(x => x.First())
          .Where(x => x.ReplaceWith.ToLower().Contains(SearchBar.ToLower()))
          .ToList());
      }
    }*/



    public void OnKeyUp(object itemReplacerObj) {
      var IsValidType = itemReplacerObj is IItemReplacer;
      if (!IsValidType) {
        throw new ArgumentException(@"OnKeyUp() parameter not of type " + typeof(IItemReplacer), nameof(itemReplacerObj));
      }

      // Cast to KeyValuePair like Dict
      var itemReplacer = (IItemReplacer)itemReplacerObj;

      // Pass to model
      ItemModel.ItemSelected(itemReplacer);

      NotifyOfPropertyChange(() => SecondaryPane);
    }

    public void OnCellEditEnding() {
    }
  }
}
