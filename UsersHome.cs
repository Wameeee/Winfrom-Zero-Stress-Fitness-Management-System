using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace 健身房管理
{
	/// <summary>
	/// 用户主页控件
	/// </summary>
	public partial class UsersHome : UserControl
	{
		/// <summary>
		/// 用户ID，用于识别当前用户
		/// </summary>
		public int id = 0;

		/// <summary>
		/// 用户主页业务逻辑层实例
		/// </summary>
		UserHomeBLL ubl = new UserHomeBLL();

		/// <summary>
		/// 用户主页的构造函数
		/// </summary>
		public UsersHome()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 添加并显示指定的子控件
		/// </summary>
		/// <param name="uc">要添加并显示的子控件</param>
		private void addUserControl(UserControl uc)
		{
			panel1.Controls.Clear(); // 清空显示页面
			uc.Dock = DockStyle.Fill; // 当前要添加的页面 填充满
			uc.BringToFront();
			panel1.Controls.Add(uc);
		}

		/// <summary>
		/// 处理用户信息图片框点击事件
		/// </summary>
		/// <param name="sender">事件发送者</param>
		/// <param name="e">事件参数</param>
		private void pictureBox1_Click_1(object sender, EventArgs e)
		{
			UserInfo uinfo = new UserInfo();
			uinfo.random1 = id;
			addUserControl(uinfo);
		}

		/// <summary>
		/// 用户主页加载事件处理
		/// </summary>
		/// <param name="sender">事件发送者</param>
		/// <param name="e">事件参数</param>
		private void UsersHome_Load(object sender, EventArgs e)
		{
			jiaz();
		}

		/// <summary>
		/// 面板的绘制事件处理
		/// </summary>
		/// <param name="sender">事件发送者</param>
		/// <param name="e">绘制事件参数</param>
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		/// <summary>
		/// 更新用户健身数据
		/// </summary>
		public void jiaz()
		{
			DataTable dt = ubl.xiansxiaof(id);
			guna2CircleProgressBar1.Value = int.Parse(dt.Rows[0]["carnum"].ToString());
			guna2CircleProgressBar2.Value = int.Parse(dt.Rows[0]["carnum"].ToString()) * 20;
		}
	}
}