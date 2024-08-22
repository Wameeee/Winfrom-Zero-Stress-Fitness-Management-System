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
//using System.Net.Mime;
using BLL;

namespace 健身房管理
{
	/// <summary>
	/// 用户消息界面的用户控件
	/// </summary>
	public partial class UserMessage : UserControl
	{
		/// <summary>
		/// 用户消息控件的构造函数
		/// </summary>
		public UserMessage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 会员业务逻辑层实例
		/// </summary>
		huiyuanBLL hyb = new huiyuanBLL();

		/// <summary>
		/// 当用户消息界面加载时，初始化界面和数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UserMessage_Load(object sender, EventArgs e)
		{
			jiazmail(); // 加载邮件数据
			comboBox3.SelectedIndex = 0; // 初始化发送人邮箱类型选择框
			comboBox1.SelectedIndex = 0; // 初始化收件人邮箱类型选择框
		}

		/// <summary>
		/// 加载邮件数据到数据网格视图
		/// </summary>
		public void jiazmail()
		{
			this.guna2DataGridView1.AutoGenerateColumns = false; // 禁止自动生成列
			this.guna2DataGridView1.DataSource = hyb.hydgvshow1(); // 设置数据源为会员数据
		}

		/// <summary>
		/// 文件打开对话框实例
		/// </summary>
		private OpenFileDialog openFileDialog = new OpenFileDialog();

		/// <summary>
		/// 当点击上传附件按钮时，打开文件对话框选择文件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.fujietxt.Text = this.openFileDialog.FileName; // 设置附件文本框为选择的文件路径
			}
		}

		/// <summary>
		/// 当点击发送邮件按钮时，构造并发送邮件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			try
			{
				MailMessage msg = new MailMessage(); // 创建邮件消息实例
				string connectpath = contenttxt.Text; // 邮件内容
				string mailpath = mailtxt.Text; // 发送人QQ号
				string mailnextpath = comboBox3.Text; // 发送人选择的邮箱类型
				string recipien = recipienttxt.Text; // 收件人QQ号
				string recipiennextpath = comboBox1.Text; // 收件人选择的邮箱类型
				string titlepath = titletxt.Text; // 邮件标题
				msg.From = new MailAddress(mailpath.ToString() + mailnextpath); // 设置发件人地址
				msg.Body = connectpath; // 设置邮件内容
				msg.To.Add(recipien.ToString() + recipiennextpath); // 设置收件人地址
				msg.Subject = titlepath; // 设置邮件主题
				msg.IsBodyHtml = true; // 设置邮件内容为HTML格式
				SmtpClient sc = new SmtpClient(); // 创建SMTP客户端实例
				sc.Host = "smtp.qq.com"; // 设置SMTP服务器地址
				sc.Port = 25; // 设置SMTP服务器端口
				NetworkCredential nc = new NetworkCredential(); // 创建网络凭证实例
				nc.UserName = "2244727152@qq.com"; // 设置SMTP服务器用户名
				nc.Password = "bljusvepoqiidjca"; // 设置SMTP服务器密码
				sc.Credentials = nc; // 设置SMTP客户端凭证
				if (this.fujietxt.Text != "")
				{
					Attachment att = new Attachment(this.fujietxt.Text); // 创建附件实例
					msg.Attachments.Add(att); // 将附件添加到邮件
				}

				sc.Send(msg); // 发送邮件
				MessageBox.Show("发送成功！"); // 提示发送成功
			}
			catch (Exception exception)
			{
				MessageBox.Show(("发送失败！" + exception.Message));
			}
		}
	}
}