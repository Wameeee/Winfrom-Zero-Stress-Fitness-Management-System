using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace 健身房管理
{
	/// <summary>
	/// UserConsume 控制是用于展示用户消费相关数据的用户控件。
	/// </summary>
	public partial class UserConsume : UserControl
	{
		// 会员业务逻辑层对象，用于调用会员相关业务逻辑
		huiyuanBLL hyb = new huiyuanBLL();

		// 用户头像的URL
		public string toux = "";

		/// <summary>
		/// 用户控件的构造函数，用于初始化控件。
		/// </summary>
		public UserConsume()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 用户控件加载事件处理程序，用于在控件加载时执行初始化操作。
		/// </summary>
		/// <param name="sender">事件的发送者。</param>
		/// <param name="e">事件参数。</param>
		private void UserConsume_Load(object sender, EventArgs e)
		{
			// 以下代码注释掉了，功能是加载网络图片到PictureBox控件中
			//Image im = Image.FromStream(WebRequest.Create("http://q2.qlogo.cn/headimg_dl?dst_uin=2244727152&spec=100").GetResponse().GetResponseStream());
			//pictureBox1.Image = im;
			//pictureBox1.Load("http://q2.qlogo.cn/headimg_dl?dst_uin=2244727152&spec=100");

			// 加载用户数量
			viewyh();
			// 加载累计用户卡数量
			viewcarnum();
			// 加载使用小时数
			viewshour();
			// 设置当前月份到Label控件中
			DateTime dt = DateTime.Now;
			label12.Text = dt.Month.ToString() + "月";
		}

		/// <summary>
		/// 加载用户数量到控件中。
		/// </summary>
		public void viewyh() //用户数量
		{
			// 从数据库获取用户数据
			DataTable dt = hyb.view();
			// 设置用户数量到Label控件中
			this.lblyhsl.Text = dt.Rows.Count.ToString();
			// 设置用户数量到CircularProgressBar控件中
			yhslcir.Value = int.Parse(dt.Rows.Count.ToString());
			// 设置用户数量到TrackBar控件中
			this.Tyhsl.Value = int.Parse(dt.Rows.Count.ToString());
		}

		/// <summary>
		/// 加载累计用户卡数量到控件中。
		/// </summary>
		public void viewcarnum() //累计用户卡数量
		{
			try
			{
				// 从数据库获取用户卡数量数据
				DataTable dt = hyb.viewcarnum();
				// 设置累计用户卡数量到Label控件中
				this.lblljcardr.Text = dt.Rows[0]["xx"].ToString();
				// 设置用户卡数量到CircularProgressBar控件中
				this.cardcir.Value = int.Parse(dt.Rows.Count.ToString());
				// 设置用户卡数量到TrackBar控件中
				Tcard.Value = int.Parse(dt.Rows[0]["xx"].ToString());
			}
			catch (Exception e)
			{
				// 显示错误消息
				MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// 计算并加载使用小时数到控件中。
		/// </summary>
		public void viewshour()
		{
			// 根据用户卡数量计算使用小时数，并设置到Label和TrackBar控件中
			lblljsr.Text = (Tcard.Value * 2).ToString();
			Tljsr.Value = Tcard.Value * 2;
		}

		/// <summary>
		/// Label控件点击事件处理程序，目前未使用。
		/// </summary>
		/// <param name="sender">事件的发送者。</param>
		/// <param name="e">事件参数。</param>
		private void label20_Click(object sender, EventArgs e)
		{
		}
	}
}