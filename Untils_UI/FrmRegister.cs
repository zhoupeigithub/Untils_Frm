using System;
using System.Data;
using System.Windows.Forms;

namespace Untils_UI
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private Untils_BLL.BLLUser bll = new Untils_BLL.BLLUser();
        private void btnsure_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text.ToString())
                && !string.IsNullOrEmpty(txtNickName.Text.ToString())
                && !string.IsNullOrEmpty(txtpwd.Text.ToString())
                && !string.IsNullOrEmpty(txtsurepwd.Text.ToString())
                && !string.IsNullOrEmpty(cmbUserType.Text.ToString()))
            {
                if (txtpwd.Text.ToString().Trim() == txtsurepwd.Text.ToString().Trim())
                {
                    string md5Pwd = txtpwd.Text;
                    md5Pwd = Untils_Common.EntryMD5.MD5Entryer(md5Pwd);
                    Untils_Model.BZ_User ubu = new Untils_Model.BZ_User();
                    ubu.Z_UserName = txtName.Text;
                    ubu.Z_NickName = txtNickName.Text;
                    ubu.Z_Password = md5Pwd;
                    ubu.Z_UserType = cmbUserType.Text;
                    int flag = bll.Add(ubu);
                    if (flag == 1)
                    {
                        MessageBox.Show("添加成功");
                    }
                    else if (flag == 2)
                    {
                        MessageBox.Show("用户名重复");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("两次密码不一致，请检查！");
                }
            }
            else
            {
                MessageBox.Show("资料填写不完整，请检查！");
            }
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            DataTable dt = bll.GetAllUserType();
            cmbUserType.DataSource = dt;
            cmbUserType.DisplayMember = "WName";
            cmbUserType.ValueMember = "TId";
        }
    }
}