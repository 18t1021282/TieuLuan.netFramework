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
using QLDeTai.DAL;

namespace QLDeTai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ls = MonHocBLL.GetList();

            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var monHoc = comboBox1.SelectedItem as MonHoc;
            if (monHoc != null)
            {
                var maMon = monHoc.ID;
                var ls = DeTaiBLL.GetList(maMon);

                deTaiBindingSource.DataSource = ls;
                dataGridView1.DataSource = deTaiBindingSource;

                var total = DeTaiBLL.Count(maMon);
                lblTongSoDT.Text = $"{total} đề tài";

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var deTai = deTaiBindingSource.Current as DeTai;
            if (deTai != null)
            {
                var rs = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (rs == DialogResult.OK)
                {
                    DeTaiBLL.Delete(deTai.ID);
                    deTaiBindingSource.RemoveCurrent();
                    MessageBox.Show("Đã xóa thành công", "Thông báo");

                }
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            var deTai = deTaiBindingSource.Current as DeTai;
            if (deTai != null)
            {
                var f = new frmDeTaiChiTiet(deTai);
                var rs = f.ShowDialog();
                var lopHoc = comboBox1.SelectedItem as MonHoc;
                if (rs == DialogResult.OK)
                {
                    var maMon = lopHoc.ID;
                    var ls = DeTaiBLL.GetList(maMon);

                    deTaiBindingSource.DataSource = ls;
                    dataGridView1.DataSource = deTaiBindingSource;

                    var total = DeTaiBLL.Count(maMon);
                    lblTongSoDT.Text = $"{total} đề tài";
                }

            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var f = new frmDeTaiChiTiet();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                var lopHoc = comboBox1.SelectedItem as MonHoc;
                if (lopHoc != null)
                {
                    var maLop = lopHoc.ID;
                    var ls = DeTaiBLL.GetList(maLop);

                    deTaiBindingSource.DataSource = ls;
                    dataGridView1.DataSource = deTaiBindingSource;

                    var total = DeTaiBLL.Count(maLop);
                    lblTongSoDT.Text = $"{total} đề tài";
                }
            }

        }
    }
}
