﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCBusinessLogic.Controllers {
  internal class FileSystemHandler : IFileSystemHandler {

    private string _fileName;
    private string _filter;

    public string FileName {
      get => _fileName;
      set { _fileName = value; }
    }

    public string Filter {
      get => _filter;
      set { _filter = value; }
    }

    public bool SelectFile() {
      OpenFileDialog fso = new OpenFileDialog();
      fso.ValidateNames = false;
      fso.Filter = _filter;
      fso.ShowDialog();
      _fileName = fso.FileName;
      return _fileName != "";
    }
  }
}