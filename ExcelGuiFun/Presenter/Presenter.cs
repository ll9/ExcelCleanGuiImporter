using ExcelGuiFun.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelGuiFun.Presenter
{
    class Presenter
    {
        public Presenter(IView view)
        {
            View = view;
        }

        public IView View { get; }
    }
}
