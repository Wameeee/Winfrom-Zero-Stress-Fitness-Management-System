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
using Microsoft.VisualBasic;

// 健身房管理系统的登录表单
namespace 健身房管理
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}

		// 实例化业务逻辑层对象，用于后续调用相关业务方法
		zhanghaoBLL zhb = new zhanghaoBLL();
		huiyuanBLL hyb = new huiyuanBLL();

		// 关闭按钮点击事件处理，退出应用程序
		private void closebtn_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// 账号文本框点击事件，设置相关控件的背景色以提供用户交互提示
		private void textBox1_Click(object sender, EventArgs e)
		{
			this.textBox1.BackColor = Color.White;
			panel3.BackColor = Color.White;
			panel4.BackColor = SystemColors.Control;
			this.textBox2.BackColor = SystemColors.Control;
		}

		// 密码文本框点击事件，设置相关控件的背景色以提供用户交互提示
		private void textBox2_Click(object sender, EventArgs e)
		{
			this.textBox2.BackColor = Color.White;
			panel4.BackColor = Color.White;
			this.textBox1.BackColor = SystemColors.Control;
			panel3.BackColor = SystemColors.Control;
		}

		// 密码查看图片框鼠标按下事件，显示密码
		private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
		{
			this.textBox2.UseSystemPasswordChar = false;
		}

		// 密码查看图片框鼠标抬起事件，隐藏密码
		private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
		{
			this.textBox2.UseSystemPasswordChar = true;
		}

		// 注册按钮点击事件，显示注册表单并隐藏登录表单
		private void button2_Click(object sender, EventArgs e)
		{
			注册 zc = new 注册();
			zc.Show();
			this.Hide();
		}

		// 登录按钮点击事件，验证用户输入的账号和密码
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				// 获取账号和密码文本框的值并转换为整型
				int usename = int.Parse(this.textBox1.Text.ToString());
				int usepwd = int.Parse(this.textBox2.Text.ToString());

				// 调用业务逻辑层的方法验证登录信息
				DataTable b1 = zhb.zhdl(usename, usepwd);
				DataTable dt = hyb.yhrandom(usename, usepwd);

				// 根据验证结果判断用户是否可以登录
				if (b1.Rows.Count > 0)
				{
					string test = b1.Rows[0]["isr"].ToString();
					if (int.Parse(test) > 0)
					{
						DashForm Dszhu = new DashForm();
						Dszhu.Show();
					}
					else
					{
						// 处理会员随机码验证逻辑
						if (dt.Rows.Count > 0)
						{
							string str = Interaction.InputBox("请输入随机码", "验证", "在这里输入", -1, -1);
							DataTable dt2 = hyb.yzrandom(int.Parse(str.ToString()));
							if (dt2.Rows.Count > 0)
							{
								if (str != "")
								{
									UserDashForm User = new UserDashForm();
									User.random111 = int.Parse(str.ToString());
									User.Show();
								}
							}
							else
							{
								MessageBox.Show("验证码错误");
							}
						}
						else
						{
							MessageBox.Show("密码错误");
						}
					}
				}
			}
			catch (Exception exception)
			{
				// 异常处理，显示错误信息
				MessageBox.Show($"错误+{exception.Message}", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}