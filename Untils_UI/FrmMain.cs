using System;
using System.Windows.Forms;

namespace Untils_UI
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        //数据绑定


        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PanMain.Controls.Clear();
            FrmRegister fr = new FrmRegister();
            fr.TopLevel = false;
            PanMain.Controls.Add(fr);
            fr.Show();
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PanMain.Controls.Clear();
            FrmAllData fad = new FrmAllData();
            fad.TopLevel = false;
            PanMain.Controls.Add(fad);
            fad.Show();
        }
    }
}
