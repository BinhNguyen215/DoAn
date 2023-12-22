using _DoAn.Presenters;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DoAn.Views.Statistic
{
    public partial class StatisticDetail : Form,IDetailBill
    {
        string _id;

        public StatisticDetail(string bill_id)
        {
            _id = bill_id;
            InitializeComponent();
        }
        string IDetailBill.BillId {
            get { return lbBill_id.Text; }
            set { lbBill_id.Text = value; }
        }
        string IDetailBill.Name
        {
            get
            {
                return lbName.Text;
            }
            set { lbName.Text = value; }
        }
        string IDetailBill.Date
        {
            get { return lbDate.Text; }
            set { lbDate.Text = value; }
        }
        BunifuDataGridView IDetailBill.dtgvDetail
        {
            get { return  dtgvDetailBill; }
            set { dtgvDetailBill = value; }
        }
        private void StatisticDetail_Load(object sender, EventArgs e)
        {
            DetailStatisticPresenter presenter = new DetailStatisticPresenter(this);
            presenter.GetDate(_id);
            presenter.GetName(_id);
            presenter.GetDTGVDetail(_id);

        }
    }
}
