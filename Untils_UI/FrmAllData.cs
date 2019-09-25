using System;
using System.Data;
using System.Windows.Forms;
using Untils_BLL;

namespace Untils_UI
{
    public partial class FrmAllData : Form
    {
        public FrmAllData()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 引用
        /// </summary>
        private Untils_BLL.BLLUser buser = new BLLUser();

        private void FrmAllData_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void DataBind()
        {
            DataTable dt = buser.GetAllUser();

            if (dt.Rows.Count > 0)
            {
                dgvUser.DataSource = dt;
                this.dgvUser.Columns[0].HeaderText = "编号";
                this.dgvUser.Columns[1].HeaderText = "名称";
                this.dgvUser.Columns[2].HeaderText = "昵称";
                this.dgvUser.Columns[3].HeaderText = "密码";
                this.dgvUser.Columns[3].Visible = false;
                this.dgvUser.Columns[4].HeaderText = "用户类型";

                this.dgvUser.ShowCellToolTips = true;
                this.dgvUser.CellMouseEnter += new DataGridViewCellEventHandler(dgvUser_CellMouseEnter);
            }
            else
            {
                MessageBox.Show("暂无数据");
            }
        }

        private void dgvUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //label1.Text = this.dgvUser["Z_Id", e.RowIndex].Value.ToString();

            DataGridViewRow row = dgvUser.Rows[e.RowIndex];
            string ZId = row.Cells[0].Value.ToString();
            FrmUserDetails frmu = new FrmUserDetails(ZId);
            this.Hide();
            frmu.Show();

        }

        private void dgvUser_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0 || dgvUser.Rows.Count <= 0)
            {
                return;
            }
            dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "双击可以编辑修改";
        }

    }
}
