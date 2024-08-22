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
using DAL;

// 健身房管理软件命名空间
namespace 健身房管理
{
	// 用户控件类，用于管理健身房商品信息
	public partial class UGoods : UserControl
	{
		// 业务逻辑层对象，用于调用商品业务逻辑方法
		UgoodsBLL ugl = new UgoodsBLL();

		// 数据库帮助类对象，用于数据库操作
		DBHelper db = new DBHelper();

		// 构造函数
		public UGoods()
		{
			InitializeComponent();
		}

		// 用户控件加载事件，调用初始化方法
		private void UGoods_Load(object sender, EventArgs e)
		{
			jiaz();
		}

		// 初始化方法，设置数据网格视图属性并加载商品数据
		public void jiaz()
		{
			this.guna2DataGridView1.AutoGenerateColumns = false;
			DataTable dt = ugl.showUgoods();
			this.guna2DataGridView1.DataSource = dt;
		}

		// 数据网格视图点击事件，用于显示选中行的商品详细信息
		private void guna2DataGridView1_Click(object sender, EventArgs e)
		{
			DataTable dt = ugl.showUgoods();
			this.label6.Text = dt.Rows[0]["goodsnum"].ToString();
			this.label5.Text = dt.Rows[0]["goodsprice"].ToString();
			this.label2.Text = dt.Rows[0]["goodsname"].ToString();
		}

		// 按钮点击事件，用于处理商品数量更新操作
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			int id = int.Parse(this.guna2DataGridView1.CurrentRow.Cells["id"].Value.ToString());
			string sql = string.Format("select * from Goods where id='{0}'", id);
			DataTable dt = db.cx(sql);
			int b = int.Parse(dt.Rows[0]["goodsnum"].ToString());
			int a = int.Parse(this.guna2TextBox1.Text);
			int c = b - a;
			Boolean bl = ugl.up(c, id);
			if (bl)
			{
				MessageBox.Show("成功");
			}
			else
			{
				MessageBox.Show("失败");
			}
		}
	}
}