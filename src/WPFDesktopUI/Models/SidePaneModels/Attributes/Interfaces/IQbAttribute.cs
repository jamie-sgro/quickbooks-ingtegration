﻿namespace WPFDesktopUI.Models.SidePaneModels.Attributes.Interfaces {
  public interface IQbAttribute {
    string Name { get; set; }
    string Payload { get; set; }
    bool IsMandatory { get; set; }
    IQbComboBox ComboBox { get; set; }
  }
}
