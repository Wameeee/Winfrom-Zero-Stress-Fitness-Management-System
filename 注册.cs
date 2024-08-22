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
	/// 注册表单的 partial 类
	/// </summary>
	public partial class 注册 : Form
	{
		/// <summary>
		/// 初始化注册表单
		/// </summary>
		public 注册()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 实例化一个账号业务逻辑层对象
		/// </summary>
		zhanghaoBLL zbl = new zhanghaoBLL();

		/// <summary>
		/// 关闭当前表单并显示登录表单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void closebtn_Click(object sender, EventArgs e)
		{
			Login lg = new Login();
			lg.Show();
			this.Hide();
		}

		/// <summary>
		/// 当用户名文本框被点击时，改变文本框和相关面板的背景色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox1_Click(object sender, EventArgs e)
		{
			this.textBox1.BackColor = Color.White;
			panel3.BackColor = Color.White;
			panel4.BackColor = SystemColors.Control;
			this.textBox2.BackColor = SystemColors.Control;
		}

		/// <summary>
		/// 当密码文本框被点击时，改变文本框和相关面板的背景色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox2_Click(object sender, EventArgs e)
		{
			this.textBox2.BackColor = Color.White;
			panel4.BackColor = Color.White;
			this.textBox1.BackColor = SystemColors.Control;
			panel3.BackColor = SystemColors.Control;
		}

		/// <summary>
		/// 当鼠标按下密码显示图标时，显示密码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
		{
			this.textBox2.UseSystemPasswordChar = false;
		}

		/// <summary>
		/// 当鼠标松开密码显示图标时，隐藏密码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
		{
			this.textBox2.UseSystemPasswordChar = true;
		}

		/// <summary>
		/// 清空用户名和密码文本框
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			this.textBox1.Text = "";
			this.textBox2.Text = "";
		}

		/// <summary>
		/// 尝试注册新用户
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			DataTable zcname = zbl.cxzh(this.textBox1.Text); // zcname   注册用户名密码
			if (zcname.Rows.Count > 0)
			{
				MessageBox.Show("此账号已有人注册");
			}
			else
			{
				int isr = 0;
				int usename = Convert.ToInt32(this.textBox1.Text);
				int usepwd = Convert.ToInt32(this.textBox2.Text);

				if (this.checkBox1.Checked)
				{
					//管理员
					isr = 1;
					bool b1 = zbl.zhzc(usename, usepwd, isr);
					if (b1)
					{
						MessageBox.Show("注册成功");
						MessageBox.Show("欢迎管理员");
					}
					else
					{
						MessageBox.Show("注册失败");
					}
				}
				else
				{
					isr = 0;
					bool b1 = zbl.zhzc(usename, usepwd, isr);
					if (b1)
					{
						MessageBox.Show("注册成功");
					}
					else
					{
						MessageBox.Show("注册失败");
					}
				}
			}
		}
	}
}