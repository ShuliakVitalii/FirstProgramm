using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Test3
{
    public partial class Form1 : Form
    {
        private ApplicationDbContext db;
        public Form1()
        {
            InitializeComponent();

            db = new ApplicationDbContext();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            db.Orders.Load();
            db.Products.Load();
            dataGridView1.DataSource = db.Orders.Local.ToBindingList();
            dataGridView2.DataSource = db.Products.Local.ToBindingList();
        }
        //Книпка "Удалить"
        private void button3_Click(object sender, EventArgs e)
        {
            if (label4.Text == String.Empty) return;

            var id = Convert.ToInt32(label4.Text);
            var order = db.Orders.Find(id);

            db.Entry(order).State = EntityState.Deleted;
            db.Orders.Remove(order);

            db.SaveChanges();

            dataGridView1.Refresh();

        }
        //Кнопка "Редактировать"
        private void button2_Click(object sender, EventArgs e)
        {
            if (label4.Text == String.Empty) return;

            var id = Convert.ToInt32(label4.Text);
            var order = db.Orders.Find(id);

            if (order == null) return;

            order.Date = Convert.ToDateTime(textBox1.Text);
            order.NumberOrders = Convert.ToInt32(textBox2.Text);
            order.FullNameClients = Convert.ToString(textBox3.Text);
            order.TotalAmount = Convert.ToDecimal(textBox4.Text);
            order.ProductList = Convert.ToString(textBox5.Text);

            db.Entry(order).State = EntityState.Modified;
            db.Orders.Update(order);

            db.SaveChanges();

            dataGridView1.Refresh();
        }
        //Кнопка "Добавить"
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty || 
                textBox2.Text == String.Empty || 
                textBox3.Text == String.Empty || 
                textBox4.Text == String.Empty || 
                textBox5.Text == String.Empty)
            {
                MessageBox.Show("Текстовые поля не заполнены !");
                return;
            }
            Order order = new Order
            {
                Date = Convert.ToDateTime(textBox1.Text),
                NumberOrders = Convert.ToInt32(textBox2.Text),
                FullNameClients = Convert.ToString(textBox3.Text),
                TotalAmount = Convert.ToDecimal(textBox4.Text),
                ProductList = Convert.ToString(textBox5.Text),
            };

            db.Orders.Add(order);
            db.SaveChanges();
            dataGridView1.Refresh();

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
        }
        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            if (dataGridView2.CurrentRow == null) return;

            var order = dataGridView1.CurrentRow.DataBoundItem as Order;
            var product = dataGridView2.CurrentRow.DataBoundItem as Product;

            if (order == null) return;
            if (product == null) return;

            label4.Text = Convert.ToString(order.Id);
            textBox1.Text = Convert.ToString(order.Date);
            textBox2.Text = Convert.ToString(order.NumberOrders);
            textBox3.Text = order.FullNameClients;
            textBox4.Text = Convert.ToString(order.TotalAmount);
            textBox5.Text = Convert.ToString(order.ProductList);
        }

    }
}