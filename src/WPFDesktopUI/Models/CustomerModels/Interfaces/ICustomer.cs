﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDesktopUI.Models.CustomerModels.Interfaces {
  public interface ICustomer {

    string Name { get; }

    string PoNumber { get; set; }

    string TermsRefFullName { get; set; }

    string Class { get; set; }

    string AppendLineItem1 { get; set; }
    string AppendLineItem2 { get; set; }
    string AppendLineItem3 { get; set; }
  }
}
