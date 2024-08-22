using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using BLL;

namespace 健身房管理
{
	/// <summary>
	/// Umessage 用户控件，用于健身房管理系统的消息发送功能。
	/// </summary>
	public partial class Umessage : UserControl
	{
		// 实例化一个 huiyuanBLL 对象，用于处理会员业务逻辑
		huiyuanBLL hyb = new huiyuanBLL();

		/// <summary>
		/// Umessage 的构造函数。
		/// </summary>
		public Umessage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 当 guna2Button1 被点击时，执行邮件发送操作。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			MailMessage msg = new MailMessage();
			// 邮件内容
			string connectpath = contenttxt.Text;
			// 发送人邮箱地址
			string mailpath = mailtxt.Text;
			// 发送人邮箱类型
			string mailnextpath = comboBox3.Text;
			// 收件人邮箱地址
			string recipien = recipienttxt.Text;
			// 收件人邮箱类型
			string recipiennextpath = comboBox1.Text;
			// 邮件标题
			string titlepath = titletxt.Text;

			// 设置发件人地址
			msg.From = new MailAddress(mailpath.ToString() + mailnextpath);
			// 设置邮件内容
			msg.Body = connectpath;
			// 设置收件人地址
			msg.To.Add(recipien.ToString() + recipiennextpath);
			// 设置邮件主题
			msg.Subject = titlepath;

			// 设置邮件内容格式为 HTML
			msg.IsBodyHtml = true;
			// 实例化一个 SmtpClient 对象
			SmtpClient sc = new SmtpClient();
			// 设置 SMTP 服务器地址
			sc.Host = "smtp.qq.com";
			// 设置 SMTP 服务器端口
			sc.Port = 25;

			// 实例化一个 NetworkCredential 对象，用于 SMTP 服务器的身份验证
			NetworkCredential nc = new NetworkCredential();
			// 设置用户名为 SMTP 服务器的邮箱名称
			nc.UserName = "2244727152@qq.com";
			// 设置密码为 SMTP 服务器的邮箱密码
			nc.Password = "bljusvepoqiidjca";
			// 设置 SMTP 客户端使用的凭据
			sc.Credentials = nc;

			// 如果用户指定了附件，则添加到邮件中
			if (this.fujietxt.Text != "")
			{
				Attachment att = new Attachment(this.fujietxt.Text);
				msg.Attachments.Add(att);
			}

			// 发送邮件
			sc.Send(msg);
			// 提示用户邮件发送成功
			MessageBox.Show("发送成功！");
		}

		/// <summary>
		/// 实例化一个 OpenFileDialog 对象，用于选择附件文件。
		/// </summary>
		private OpenFileDialog openFileDialog = new OpenFileDialog();

		/// <summary>
		/// 当 guna2Button2 被点击时，打开文件对话框以选择附件。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.fujietxt.Text = this.openFileDialog.FileName;
			}
		}

		/// <summary>
		/// 当 Umessage_Load 事件被触发时，调用 jiazmail 方法加载邮件数据。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Umessage_Load(object sender, EventArgs e)
		{
			jiazmail();
		}

		/// <summary>
		/// 加载邮件数据到 DataGridView 控件中。
		/// </summary>
		public void jiazmail()
		{
			// 设置 DataGridView 不自动生成列
			this.guna2DataGridView1.AutoGenerateColumns = false;
			// 设置 DataGridView 的数据源为会员数据
			this.guna2DataGridView1.DataSource = hyb.hydgvshow1();
		}
	}
}