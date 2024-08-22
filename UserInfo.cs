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
	/// UserInfo类，用于展示和修改用户个人信息
	/// </summary>
	public partial class UserInfo : UserControl
	{
		/// <summary>
		/// UserInfo业务逻辑层实例
		/// </summary>
		UserInfoBLL ubl = new UserInfoBLL();

		/// <summary>
		/// 随机数，用于标识用户
		/// </summary>
		public int random1 = 0;

		/// <summary>
		/// 默认构造函数，初始化控件
		/// </summary>
		public UserInfo()
		{
			InitializeComponent();
		}

		/// <summary>
		/// UserInfo控件加载时调用的方法，用于初始化显示用户信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UserInfo_Load(object sender, EventArgs e)
		{
			jiaz();
		}

		/// <summary>
		/// 加载并显示用户信息
		/// </summary>
		public void jiaz()
		{
			// 从UserInfoBLL层获取用户信息
			DataTable dt = ubl.UserInfoShow(random1.ToString());

			// 绑定并显示用户信息
			this.txtname.Text = dt.Rows[0]["uname"].ToString();
			this.txtmail.Text = dt.Rows[0]["mail"].ToString();
			string sex = dt.Rows[0]["sex"].ToString();
			if (sex == "男")
			{
				this.ra1.Checked = true;
			}
			else
			{
				this.ra2.Checked = true;
			}

			this.jointime.Text = dt.Rows[0]["jointime"].ToString();
			this.lbljif.Text = dt.Rows[0]["carintegral"].ToString();
			this.lblname.Text = dt.Rows[0]["uname"].ToString();
			this.txtrandom.Text = dt.Rows[0]["randomcnum"].ToString();
		}

		/// <summary>
		/// 修改用户信息按钮点击事件处理方法
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			// 获取并处理用户输入的信息
			string name = this.txtname.Text;
			string mail = this.txtmail.Text;
			string sex = "";
			if (this.ra1.Checked)
			{
				sex = "男";
			}
			else
			{
				sex = "女";
			}

			int random = int.Parse(txtrandom.Text);
			int id = random1;

			// 调用BLL层方法修改用户信息
			bool b1 = ubl.UserInfoModify(name, mail, sex, random, id);

			// 根据修改结果展示相应消息
			if (b1)
			{
				MessageBox.Show("修改成功");
				MessageBox.Show("检测到修改个人信息请重新登录");
				this.Hide();
				Login lg = new Login();
				lg.Show();
			}
			else
			{
				MessageBox.Show("修改失败");
			}
		}
	}
}