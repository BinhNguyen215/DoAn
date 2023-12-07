using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DoAn.Views.Import;

namespace _DoAn.Presenters.cImport
{
    public class EditCommand : Command
    {
        private int index;
        private ImportPresenter import;
        public EditCommand(ImportPresenter i, int id)
        {
            this.import = i;
            this.index = id;
        }
        public override bool Execute()
        {
            import.EditData(index);
            import.CalculateTotalPrice();
            return true;
        }
    }
}
