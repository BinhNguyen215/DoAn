using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DoAn.Views.Import;

namespace _DoAn.Presenters.cImport
{
    public class CancelCommand : Command
    {
        private ImportPresenter import;
        public CancelCommand(ImportPresenter i)
        {
            this.import = i;
        }
        public override bool Execute()
        {
            return import.ClearData();
        }
    }
}
