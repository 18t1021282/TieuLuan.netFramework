using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDeTai.ViewModel;
using QLDeTai.DAL;

namespace QLDeTai
{
    public partial class frmMonHocChiTiet : Form
    {
        MonHocViewModel monHoc;
        public frmMonHocChiTiet(MonHocViewModel monHoc=null)
        {
            InitializeComponent();
            this.monHoc = monHoc;
            if (monHoc == null)
            {
                this.Text = "Thêm mới môn học";
            }
            else
            {
                this.Text = "Cập nhật dữ liệu cho môn học";
                txtTenMH.Text = monHoc.Name;
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var tenMon = txtTenMH.Text;
            if (string.IsNullOrEmpty(tenMon))
            {
                //MessageBox.Show("Vui long nhạp ten lop")
                errorProvider1.SetError(txtTenMH, "Vui lòng nhập tên lớp");
                return;
            }
             QLDeTaiModel model = new QLDeTaiModel();
            if (monHoc == null)
            {
                //them mới

                var lh = model.MonHocs.Where(t => t.Name == tenMon).FirstOrDefault();
                if (lh != null)
                {
                    MessageBox.Show("Tên môn học trùng. Vui lòng nhập tên khác", "Chú ý");
                    return;
                }
                else
                {
                    lh = new MonHoc
                    {
                        Name = tenMon
                    };
                    model.MonHocs.Add(lh);
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;

                }
            }
            else
            {
                // cập nhật

                var lh = model.MonHocs.Where(t => t.ID != monHoc.ID && t.Name == tenMon).FirstOrDefault();
                if (lh != null)
                {
                    MessageBox.Show("Tên môn học trùng. Vui lòng nhập tên khác", "Chú ý");
                    return;
                }
                else
                {
                    lh = model.MonHocs.Where(t => t.ID == monHoc.ID).FirstOrDefault();
                    lh.Name = tenMon;
                    model.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }

        }
    }
}
