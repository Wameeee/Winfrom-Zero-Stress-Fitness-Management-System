using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

// 健身房管理系统的用户界面类
namespace 健身房管理
{
	// 用户主界面表单类
	public partial class UserDashForm : Form
	{
		// 随机数变量，用于生成用户ID
		public int random111 = 0;

		// 构造函数
		public UserDashForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 添加用户控件到显示面板
		/// </summary>
		/// <param name="uc">要添加的用户控件</param>
		private void addUserControl(UserControl uc)
		{
			// 清空显示页面
			paneC.Controls.Clear();
			// 当前要添加的页面 填充满显示区域
			uc.Dock = DockStyle.Fill;
			// 将当前页面置顶
			uc.BringToFront();
			// 添加到显示面板
			paneC.Controls.Add(uc);
		}

		/// <summary>
		/// 返回首页按钮点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2ImageButton3_Click(object sender, EventArgs e)
		{
			// 实例化用户首页控件
			UsersHome uH_ = new UsersHome();
			// 设置用户ID
			uH_.id = this.random111;
			// 添加用户首页控件到显示面板
			addUserControl(uH_);
		}

		/// <summary>
		/// 退出按钮点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2ImageButton5_Click(object sender, EventArgs e)
		{
			// 退出应用程序
			Application.Exit();
		}

		/// <summary>
		/// 用户界面加载事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UserDashForm_Load(object sender, EventArgs e)
		{
			// 初始化界面的代码，此处未具体实现
		}

		/// <summary>
		/// 商品页面按钮点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2ImageButton1_Click(object sender, EventArgs e)
		{
			// 实例化商品页面控件
			UGoods uG_ = new UGoods();
			// 添加商品页面控件到显示面板
			addUserControl(uG_);
		}

		/// <summary>
		/// 消息页面按钮点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2ImageButton2_Click(object sender, EventArgs e)
		{
			// 实例化消息页面控件
			Umessage uM_ = new Umessage();
			// 添加消息页面控件到显示面板
			addUserControl(uM_);
		}

		/// <summary>
		/// 关于我们页面按钮点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2ImageButton4_Click(object sender, EventArgs e)
		{
			// 实例化关于我们页面控件
			Uconcerning uc_ = new Uconcerning();
			// 添加关于我们页面控件到显示面板
			addUserControl(uc_);
		}
	}
}