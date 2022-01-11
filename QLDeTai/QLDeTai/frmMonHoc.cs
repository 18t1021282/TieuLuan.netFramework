using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDeTai.BLL;
using QLDeTai.ViewModel;


namespace QLDeTai
{
    public partial class frmMonHoc : Form
    {
        public frmMonHoc()
        {
            InitializeComponent();
            NapMonHoc();
        }
        void NapMonHoc()
        {
            var ls = MonHocBLL.GetListViewModel();
            monHocViewModelBindingSource.DataSource = ls;
            dataGridView1.DataSource = monHocViewModelBindingSource;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            var f = new frmMonHocChiTiet();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapMonHoc();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var lopHoc = monHocViewModelBindingSource.Current as MonHocViewModel;
            if (lopHoc != null)
            {
                var f = new frmMonHocChiTiet(lopHoc);
                var rs = f.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    NapMonHoc();
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var lopHoc = monHocViewModelBindingSource.Current as MonHocViewModel;
            if (lopHoc != null)
            {
                var rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    if (MonHocBLL.Delete(lopHoc.ID))
                    {
                        monHocViewModelBindingSource.RemoveCurrent();
                        MessageBox.Show("Đã xóa thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Đã xóa không thành công", "Thông báo");
                    }

                }
            }
        }
    }
}
