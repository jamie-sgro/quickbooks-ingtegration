﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDesktopUI.ViewModels.Interfaces {
  public interface IMainTab : ITabComponent {
    string TabHeader { get; set; }
  }
}
