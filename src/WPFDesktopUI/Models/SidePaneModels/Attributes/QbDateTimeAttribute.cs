﻿using System;
using System.Data;
using WPFDesktopUI.Models.SidePaneModels.Attributes.Interfaces;

namespace WPFDesktopUI.Models.SidePaneModels.Attributes {
  public class QbDateTimeAttribute : QbAbstractAttribute, IQbDateTimeAttribute {
    public QbDateTimeAttribute() {
      Payload = DateTime.Now.ToString();
    }
    public bool HasDateTimePayload { get; } = true;

    /// <summary>
    /// Decide whether to use data from the sidepane dropdown or textbox, default to
    /// selected combobox item if possible.
    /// </summary>
    /// <param name="row">A row from a DataTable</param>
    /// <param name="key">The dictionary Key for a QbAttribute</param>
    /// <returns>String for the data in a cell/a constant value</returns>
    public override dynamic GetRow(DataRow row) {
      var colName = ComboBox.SelectedItem;

      try {
        if (!string.IsNullOrEmpty(colName)) {
          return Convert.ToDateTime(row[colName]);
        }

        if (!string.IsNullOrEmpty(Payload)) {
          return Convert.ToDateTime(Payload);
        }
      } catch (FormatException e) {
        throw new FormatException(e.Message +
          "\nThis error occured in Column: '" + colName +
          "'\nWith the text: '" + row[colName] + "'");
      }

      return null;
    }
  }
}
