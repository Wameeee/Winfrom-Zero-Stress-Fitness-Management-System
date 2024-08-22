using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 健身房管理系统的主界面类
namespace 健身房管理
{
	// 主窗口类，继承自Form
	public partial class DashForm : Form
	{
		// 全局变量，用于存储会员头像路径
		public string ww = "";

		// 构造函数
		public DashForm()
		{
			// 初始化组件
			InitializeComponent();
			// 初始化时添加一个用户消费控件
			UserConsume uC_ = new UserConsume();
			addUserControl(uC_);
		}

		/// <summary>
		/// 移动图片框位置并置底
		/// </summary>
		/// <param name="sender">触发按钮</param>
		private void moveimagebox(object sender)
		{
			// 将发送者转换为Guna2Button类型
			Guna2Button b = (Guna2Button)sender;
			// 设置图片框位置
			imgSlide.Location = new Point(b.Location.X + 34, b.Location.Y - 25);
			// 将图片框置底
			imgSlide.SendToBack();
		}

		/// <summary>
		/// 添加用户控件到显示面板
		/// </summary>
		/// <param name="uc">要添加的用户控件</param>
		private void addUserControl(UserControl uc)
		{
			// 清空显示页面的所有控件
			panelContainer.Controls.Clear();
			// 当前要添加的页面填充满显示面板
			uc.Dock = DockStyle.Fill;
			// 将当前页面提到前面
			uc.BringToFront();
			// 添加当前页面到显示面板
			panelContainer.Controls.Add(uc);
		}

		/// <summary>
		/// Guna2Button1的CheckedChanged事件处理程序
		/// </summary>
		/// <param name="sender">事件源</param>
		/// <param name="e">事件参数</param>
		private void guna2Button1_CheckedChanged(object sender, EventArgs e)
		{
			// 移动图片框
			moveimagebox(sender);
		}

		/// <summary>
		/// Guna2Button1的Click事件处理程序
		/// </summary>
		/// <param name="sender">事件源</param>
		/// <param name="e">事件参数</param>
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			// 创建并初始化用户消费控件
			UserConsume uC_ = new UserConsume();
			// 设置用户消费控件的头像路径
			uC_.toux = ww;
			// 添加用户消费控件到显示面板
			addUserControl(uC_);
		}

		/// <summary>
		/// Guna2Button6的Click事件处理程序，用于退出应用程序
		/// </summary>
		/// <param name="sender">事件源</param>
		/// <param name="e">事件参数</param>
		private void guna2Button6_Click(object sender, EventArgs e)
		{
			// 退出应用程序
			Application.Exit();
		}

		/// <summary>
		/// Guna2Button5的Click事件处理程序，用于显示用户信息页面
		/// </summary>
		/// <param name="sender">事件源</param>
		/// <param name="e">事件参数</param>
		private void guna2Button5_Click(object sender, EventArgs e)
		{
			// 创建并初始化用户信息控件
			UserMessage uM_ = new UserMessage();
			// 添加用户信息控件到显示面板
			addUserControl(uM_);
		}

		/// <summary>
		/// Guna2Button2的Click事件处理程序，用于显示会员管理页面
		/// </summary>
		/// <param name="sender">事件源</param>
		/// <param name="e">事件参数</param>
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			// 创建并初始化会员管理控件
			UserMember uMb_ = new UserMember();
			// 添加会员管理控件到显示面板
			addUserControl(uMb_);
		}

		/// <summary>
		/// Guna2Button4的Click事件处理程序，用于显示器材管理页面
		/// </summary>
		/// <param name="sender">事件源</param>
		/// <param name="e">事件参数</param>
		private void guna2Button4_Click(object sender, EventArgs e)
		{
			// 创建并初始化器材管理控件
			UserApparatus uA_ = new UserApparatus();
			// 添加器材管理控件到显示面板
			addUserControl(uA_);
		}

		/// <summary>
		/// Guna2Button3的Click事件处理程序，用于显示失物招领页面
		/// </summary>
		/// <param name="sender">事件源</param>
		/// <param name="e">事件参数</param>
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			// 创建并初始化失物招领控件
			UserLost uL_ = new UserLost();
			// 添加失物招领控件到显示面板
			addUserControl(uL_);
		}
	}
}