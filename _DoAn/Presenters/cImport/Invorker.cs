using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DoAn.Views.Import;

namespace _DoAn.Presenters.cImport
{
    internal class Invorker
    {
        private Command add;
        private Command delete;
        private Command cancel;
        private Command edit;
        public Invorker(Command AC, Command DC, Command CC, Command EC)
        {
            this.add = AC;
            this.delete = DC;
            this.cancel = CC;
            this.edit = EC;
        }
        public bool AddData()
        {
            return add.Execute();
        }
        public bool DeleteData()
        {
            return delete.Execute();
        }
        public bool EditData()
        {
            return edit.Execute();
        }
        public bool CancelData()
        {
            return cancel.Execute();
        }
    }
}
