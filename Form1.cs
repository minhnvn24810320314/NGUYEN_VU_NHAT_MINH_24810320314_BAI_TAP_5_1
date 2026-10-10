using System;
using System.Windows.Forms;

namespace NGUYEN_VU_NHAT_MINH_24810320314_BAI_TAP_5_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Xóa tất cả cảnh báo lỗi cũ trước khi kiểm tra
            epCheck.Clear();
            bool isValid = true;

            // 1. Kiểm tra Tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                epCheck.SetError(txtTenDangNhap, "Tên đăng nhập không được để trống!");
                isValid = false;
            }

            // 2. Kiểm tra Mật khẩu
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                epCheck.SetError(txtMatKhau, "Mật khẩu không được để trống!");
                isValid = false;
            }

            // 3. Kiểm tra Xác nhận mật khẩu khớp với Mật khẩu ban đầu
            if (txtXacNhanMatKhau.Text != txtMatKhau.Text)
            {
                epCheck.SetError(txtXacNhanMatKhau, "Xác nhận mật khẩu không khớp với mật khẩu ban đầu!");
                isValid = false;
            }

            // 4. Kiểm tra Độ tuổi từ Ngày sinh (≥ 18 tuổi)
            DateTime today = DateTime.Today;
            int age = today.Year - dtpNgaySinh.Value.Year;
            if (dtpNgaySinh.Value.Date > today.AddYears(-age))
            {
                age--; // Trừ 1 nếu chưa tới ngày sinh nhật trong năm hiện tại
            }

            if (age < 18)
            {
                epCheck.SetError(dtpNgaySinh, "Bạn chưa đủ 18 tuổi để đăng ký tài khoản!");
                isValid = false;
            }

            // 5. Kiểm tra Tích chọn Điều khoản dịch vụ
            if (!chkDieuKhoan.Checked)
            {
                epCheck.SetError(chkDieuKhoan, "Bạn phải đồng ý với Điều khoản dịch vụ!");
                isValid = false;
            }

            // Nếu tất cả hợp lệ -> Hiển thị MessageBox thông báo thành công
            if (isValid)
            {
                string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                string thongBao = $"ĐĂNG KÝ TÀI KHOẢN THÀNH CÔNG!\n" +
                                  $"------------------------------------\n" +
                                  $"• Tên đăng nhập: {txtTenDangNhap.Text.Trim()}\n" +
                                  $"• Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy} ({age} tuổi)\n" +
                                  $"• Giới tính: {gioiTinh}";

                MessageBox.Show(thongBao, "Thông báo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtXacNhanMatKhau.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            rdoNam.Checked = true;
            chkDieuKhoan.Checked = false;

            // Xóa sạch các biểu tượng báo lỗi của ErrorProvider
            epCheck.Clear();

            txtTenDangNhap.Focus();
        }
    }
}