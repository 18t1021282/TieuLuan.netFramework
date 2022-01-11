using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDeTai.DAL;
using QLDeTai.BLL;

namespace QLDeTai
{
    public partial class frmDeTaiChiTiet : Form
    {
        DeTai deTai;
        public frmDeTaiChiTiet(DeTai deTai = null)
        {
            InitializeComponent();
            var ls = MonHocBLL.GetList();
            comboBox1.DataSource = ls;
            comboBox1.DisplayMember = "Name";
            this.deTai = deTai;
   
            if (deTai == null)
            {
                this.Text = "Thêm mới đề tài";

            }
            else
            {
                this.Text = "Chỉnh sửa đề tài";
                txtTenDT.Text = deTai.TenDeTai;


            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var tenDT = txtTenDT.Text;
            if (string.IsNullOrEmpty(tenDT))
            {
                errorProvider1.SetError(txtTenDT, "Vui lòng nhập mã sinh viên");
                return;
            }
           
            var monHoc = comboBox1.SelectedItem as MonHoc;

            QLDeTaiModel model = new QLDeTaiModel();
            if (deTai == null)
            {
                //thêm mới
                var dt = model.DeTais.Where(s => s.TenDeTai == tenDT).FirstOrDefault();
                if (dt != null)
                {
                    MessageBox.Show("Tên đề tài trùng. Vui lòng nhập đề tài khác", "Chú ý");
                    return;
                }
                else
                {
                    dt = new DeTai
                    {
                        TenDeTai = tenDT,                       
                        IDMonHoc = monHoc.ID,

                    };
                    model.DeTais.Add(dt);
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                // cập nhật
                var lh = model.DeTais.Where(s => s.ID != deTai.ID && s.TenDeTai == tenDT).FirstOrDefault();
                if (lh != null)
                {
                    MessageBox.Show("Tên đề tài trùng. Vui lòng nhập tên đề tài khác khác", "Chú ý");
                    return;
                }
                else
                {
                    lh = model.DeTais.Where(s => s.ID == deTai.ID).FirstOrDefault();
                    lh.TenDeTai = tenDT;               
                    lh.IDMonHoc = monHoc.ID;
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }

        }

       
    }
}
