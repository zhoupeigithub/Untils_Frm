using System;
using System.Data;
using System.Windows.Forms;

namespace Untils_UI
{
    public partial class FrmUserDetails : Form
    {
        public FrmUserDetails()
        {
            InitializeComponent();
        }
        string FrmId;

        Untils_BLL.BLLUser bll = new Untils_BLL.BLLUser();

        public FrmUserDetails(string strZId)
        {
            InitializeComponent();
            FrmId = strZId;
        }

        private void FrmUserDetails_Load(object sender, EventArgs e)
        {
            GetUserType();
            GetOneInfo();
        }


        //获取详情
        private void GetOneInfo()
        {
            if (FrmId != null || FrmId != "")
            {
                DataTable dt = bll.GetDetailsById(FrmId);
                txtNo.Text = dt.Rows[0]["Z_Id"].ToString();
                txtName.Text = dt.Rows[0]["Z_UserName"].ToString();
                txtNick.Text = dt.Rows[0]["Z_NickName"].ToString();
                txtPwd.Text = dt.Rows[0]["Z_Password"].ToString();
                cmbUsertype.Text = dt.Rows[0]["Z_UserType"].ToString();
            }
            else
            {
                MessageBox.Show("数据异常！");
            }
        }

        //获取用户类型
        private void GetUserType()
        {
            DataTable dt = bll.GetAllUserType();
            cmbUsertype.DataSource = dt;
            cmbUsertype.DisplayMember = "WName";
            cmbUsertype.ValueMember = "TId";
        }


        /// <summary>
        /// 关闭此窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMain fr = new FrmMain();
            FrmAllData frm = new FrmAllData();
            frm.Show(fr);
        }

        /// <summary>
        /// 修改保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text.ToString())
                && !string.IsNullOrEmpty(txtNick.Text.ToString())
                && !string.IsNullOrEmpty(txtPwd.Text.ToString())
                && !string.IsNullOrEmpty(txtNo.Text.ToString())
                && !string.IsNullOrEmpty(cmbUsertype.Text.ToString()))
            {
                Untils_Model.BZ_User ubu = new Untils_Model.BZ_User();
                ubu.Z_Id = Convert.ToInt32(txtNo.Text);
                ubu.Z_UserName = txtName.Text;
                ubu.Z_NickName = txtNick.Text;
                ubu.Z_Password = txtPwd.Text;
                ubu.Z_UserType = cmbUsertype.Text;
                bool result = bll.UpdateByZId(ubu);
                if (result == true)
                {
                    MessageBox.Show("修改完成");
                }
                else
                {
                    MessageBox.Show("修改失败");
                    return;
                }
            }
            else
            {
                MessageBox.Show("资料填写不完整，请检查！");
            }
        }
    }
}