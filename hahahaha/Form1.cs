using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace hahahaha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtocentrDataSet.Техника". При необходимости она может быть перемещена или удалена.
            this.техникаTableAdapter.Fill(this.avtocentrDataSet.Техника);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtocentrDataSet.Статус". При необходимости она может быть перемещена или удалена.
            this.статусTableAdapter.Fill(this.avtocentrDataSet.Статус);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtocentrDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.avtocentrDataSet.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtocentrDataSet._Заказ_техника". При необходимости она может быть перемещена или удалена.
            this.заказ_техникаTableAdapter.Fill(this.avtocentrDataSet._Заказ_техника);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtocentrDataSet.Заказ". При необходимости она может быть перемещена или удалена.
            this.заказTableAdapter.Fill(this.avtocentrDataSet.Заказ);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtocentrDataSet._Завод_иготовитель". При необходимости она может быть перемещена или удалена.
            this.завод_иготовительTableAdapter.Fill(this.avtocentrDataSet._Завод_иготовитель);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtocentrDataSet.Вид_техники". При необходимости она может быть перемещена или удалена.
            this.вид_техникиTableAdapter.Fill(this.avtocentrDataSet.Вид_техники);
        }

        private DataTable table = new DataTable();
        private int selectedRow;

        private void button1_Click(object sender, EventArgs e)
        {
            avtocentrDataSet.Вид_техники.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
            dataGridView1.DataSource = avtocentrDataSet.Вид_техники;

            this.Validate();
            this.видтехникиBindingSource.EndEdit();
            this.вид_техникиTableAdapter.Update(this.avtocentrDataSet.Вид_техники);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDatarow = dataGridView1.Rows[selectedRow];
            newDatarow.Cells[0].Value = textBox1.Text;
            newDatarow.Cells[1].Value = textBox2.Text;
            newDatarow.Cells[2].Value = textBox3.Text;

            this.Validate();
            this.видтехникиBindingSource.EndEdit();
            this.вид_техникиTableAdapter.Update(this.avtocentrDataSet.Вид_техники);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult vibor2 = MessageBox.Show("Вы действительно хотите удалить строку?", "Сообщение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vibor2 == DialogResult.Yes)
            {
                selectedRow = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(selectedRow);

                this.Validate();
                this.видтехникиBindingSource.EndEdit();
                this.вид_техникиTableAdapter.Update(this.avtocentrDataSet.Вид_техники);
            }
            else
                MessageBox.Show("Вы не удалили строку!");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox4.Text = null;
        }
        // 
        private void button10_Click(object sender, EventArgs e)
        {
            avtocentrDataSet._Завод_иготовитель.Rows.Add(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text);
            dataGridView2.DataSource = avtocentrDataSet._Завод_иготовитель;

            this.Validate();
            this.заводиготовительBindingSource.EndEdit();
            this.завод_иготовительTableAdapter.Update(this.avtocentrDataSet._Завод_иготовитель);
        }



        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                        if (dataGridView2.Rows[i].Cells[j].Value.ToString().Contains(textBox5.Text))
                        {
                            dataGridView2.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDatarow = dataGridView2.Rows[selectedRow];
            newDatarow.Cells[0].Value = textBox6.Text;
            newDatarow.Cells[1].Value = textBox7.Text;
            newDatarow.Cells[2].Value = textBox8.Text;
            newDatarow.Cells[3].Value = textBox9.Text;
            newDatarow.Cells[4].Value = textBox10.Text;
            newDatarow.Cells[5].Value = textBox11.Text;
            newDatarow.Cells[6].Value = textBox12.Text;

            this.Validate();
            this.заводиготовительBindingSource.EndEdit();
            this.завод_иготовительTableAdapter.Update(this.avtocentrDataSet._Завод_иготовитель);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult vibor2 = MessageBox.Show("Вы действительно хотите удалить строку?", "Сообщение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vibor2 == DialogResult.Yes)
            {
                selectedRow = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.Rows.RemoveAt(selectedRow);

                this.Validate();
                this.заводиготовительBindingSource.EndEdit();
                this.завод_иготовительTableAdapter.Update(this.avtocentrDataSet._Завод_иготовитель);
            }
            else
                MessageBox.Show("Вы не удалили строку!");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[selectedRow];
            textBox6.Text = row.Cells[0].Value.ToString();
            textBox7.Text = row.Cells[1].Value.ToString();
            textBox8.Text = row.Cells[2].Value.ToString();
            textBox9.Text = row.Cells[3].Value.ToString();
            textBox10.Text = row.Cells[4].Value.ToString();
            textBox11.Text = row.Cells[5].Value.ToString();
            textBox12.Text = row.Cells[6].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
        }
        //
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[selectedRow];
            textBox13.Text = row.Cells[0].Value.ToString();
            textBox14.Text = row.Cells[1].Value.ToString();
            textBox15.Text = row.Cells[2].Value.ToString();
            textBox16.Text = row.Cells[3].Value.ToString();
            textBox17.Text = row.Cells[4].Value.ToString();
            textBox18.Text = row.Cells[5].Value.ToString();
            textBox19.Text = row.Cells[6].Value.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            avtocentrDataSet.Заказ.Rows.Add(textBox13.Text, textBox14.Text, textBox15.Text, textBox16.Text, textBox17.Text, textBox18.Text, textBox19.Text);
            dataGridView3.DataSource = avtocentrDataSet.Заказ;

            this.Validate();
            this.заказBindingSource.EndEdit();
            this.заказTableAdapter.Update(this.avtocentrDataSet.Заказ);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDatarow = dataGridView3.Rows[selectedRow];
            newDatarow.Cells[0].Value = textBox13.Text;
            newDatarow.Cells[1].Value = textBox14.Text;
            newDatarow.Cells[2].Value = textBox15.Text;
            newDatarow.Cells[3].Value = textBox16.Text;
            newDatarow.Cells[4].Value = textBox17.Text;
            newDatarow.Cells[5].Value = textBox18.Text;
            newDatarow.Cells[6].Value = textBox19.Text;

            this.Validate();
            this.заказBindingSource.EndEdit();
            this.заказTableAdapter.Update(this.avtocentrDataSet.Заказ);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult vibor2 = MessageBox.Show("Вы действительно хотите удалить строку?", "Сообщение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vibor2 == DialogResult.Yes)
            {
                selectedRow = dataGridView3.CurrentCell.RowIndex;
                dataGridView3.Rows.RemoveAt(selectedRow);

                this.Validate();
                this.заказBindingSource.EndEdit();
                this.заказTableAdapter.Update(this.avtocentrDataSet.Заказ);
            }
            else
                MessageBox.Show("Вы не удалили строку!");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                dataGridView3.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                        if (dataGridView3.Rows[i].Cells[j].Value.ToString().Contains(textBox20.Text))
                        {
                            dataGridView3.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox20.Text = null;
        }
        //
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView4.Rows[selectedRow];
            textBox21.Text = row.Cells[0].Value.ToString();
            textBox22.Text = row.Cells[1].Value.ToString();
            textBox23.Text = row.Cells[2].Value.ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            avtocentrDataSet._Заказ_техника.Rows.Add(textBox21.Text, textBox22.Text, textBox23.Text);
            dataGridView4.DataSource = avtocentrDataSet._Заказ_техника;

            this.Validate();
            this.заказтехникаBindingSource.EndEdit();
            this.заказ_техникаTableAdapter.Update(this.avtocentrDataSet._Заказ_техника);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDatarow = dataGridView4.Rows[selectedRow];
            newDatarow.Cells[0].Value = textBox21.Text;
            newDatarow.Cells[1].Value = textBox22.Text;
            newDatarow.Cells[2].Value = textBox23.Text;

            this.Validate();
            this.заказтехникаBindingSource.EndEdit();
            this.заказ_техникаTableAdapter.Update(this.avtocentrDataSet._Заказ_техника);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            DialogResult vibor2 = MessageBox.Show("Вы действительно хотите удалить строку?", "Сообщение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vibor2 == DialogResult.Yes)
            {
                selectedRow = dataGridView4.CurrentCell.RowIndex;
                dataGridView4.Rows.RemoveAt(selectedRow);

                this.Validate();
                this.заказтехникаBindingSource.EndEdit();
                this.заказ_техникаTableAdapter.Update(this.avtocentrDataSet._Заказ_техника);
            }
            else
                MessageBox.Show("Вы не удалили строку!");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView4.RowCount; i++)
            {
                dataGridView4.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    if (dataGridView4.Rows[i].Cells[j].Value != null)
                        if (dataGridView4.Rows[i].Cells[j].Value.ToString().Contains(textBox24.Text))
                        {
                            dataGridView4.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox24.Text = null;
        }
        //
        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView5.Rows[selectedRow];
            textBox26.Text = row.Cells[0].Value.ToString();
            textBox27.Text = row.Cells[1].Value.ToString();
            textBox28.Text = row.Cells[2].Value.ToString();
            textBox29.Text = row.Cells[3].Value.ToString();
            textBox30.Text = row.Cells[4].Value.ToString();
            textBox31.Text = row.Cells[5].Value.ToString();
            textBox32.Text = row.Cells[6].Value.ToString();
            textBox33.Text = row.Cells[7].Value.ToString();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            avtocentrDataSet.Клиенты.Rows.Add(textBox26.Text, textBox27.Text, textBox28.Text, textBox29.Text, textBox30.Text, textBox31.Text, textBox32.Text, textBox33.Text);
            dataGridView5.DataSource = avtocentrDataSet.Клиенты;

            this.Validate();
            this.клиентыBindingSource.EndEdit();
            this.клиентыTableAdapter.Update(this.avtocentrDataSet.Клиенты);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDatarow = dataGridView5.Rows[selectedRow];
            newDatarow.Cells[0].Value = textBox26.Text;
            newDatarow.Cells[1].Value = textBox27.Text;
            newDatarow.Cells[2].Value = textBox28.Text;
            newDatarow.Cells[3].Value = textBox29.Text;
            newDatarow.Cells[4].Value = textBox30.Text;
            newDatarow.Cells[5].Value = textBox31.Text;
            newDatarow.Cells[6].Value = textBox32.Text;
            newDatarow.Cells[7].Value = textBox33.Text;

            this.Validate();
            this.клиентыBindingSource.EndEdit();
            this.клиентыTableAdapter.Update(this.avtocentrDataSet.Клиенты);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DialogResult vibor2 = MessageBox.Show("Вы действительно хотите удалить строку?", "Сообщение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vibor2 == DialogResult.Yes)
            {
                selectedRow = dataGridView5.CurrentCell.RowIndex;
                dataGridView5.Rows.RemoveAt(selectedRow);

                this.Validate();
                this.клиентыBindingSource.EndEdit();
                this.клиентыTableAdapter.Update(this.avtocentrDataSet.Клиенты);
            }
            else
                MessageBox.Show("Вы не удалили строку!");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.RowCount; i++)
            {
                dataGridView5.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView5.ColumnCount; j++)
                    if (dataGridView5.Rows[i].Cells[j].Value != null)
                        if (dataGridView5.Rows[i].Cells[j].Value.ToString().Contains(textBox25.Text))
                        {
                            dataGridView5.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox25.Text = null;
        }
        //
        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView6.Rows[selectedRow];
            textBox34.Text = row.Cells[0].Value.ToString();
            textBox35.Text = row.Cells[1].Value.ToString();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            avtocentrDataSet.Статус.Rows.Add(textBox34.Text, textBox35.Text);
            dataGridView6.DataSource = avtocentrDataSet.Статус;

            this.Validate();
            this.статусBindingSource.EndEdit();
            this.статусTableAdapter.Update(this.avtocentrDataSet.Статус);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDatarow = dataGridView6.Rows[selectedRow];
            newDatarow.Cells[0].Value = textBox34.Text;
            newDatarow.Cells[1].Value = textBox35.Text;

            this.Validate();
            this.статусBindingSource.EndEdit();
            this.статусTableAdapter.Update(this.avtocentrDataSet.Статус);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            DialogResult vibor2 = MessageBox.Show("Вы действительно хотите удалить строку?", "Сообщение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vibor2 == DialogResult.Yes)
            {
                selectedRow = dataGridView6.CurrentCell.RowIndex;
                dataGridView6.Rows.RemoveAt(selectedRow);

                this.Validate();
                this.статусBindingSource.EndEdit();
                this.статусTableAdapter.Update(this.avtocentrDataSet.Статус);
            }
            else
                MessageBox.Show("Вы не удалили строку!");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView6.RowCount; i++)
            {
                dataGridView6.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView6.ColumnCount; j++)
                    if (dataGridView6.Rows[i].Cells[j].Value != null)
                        if (dataGridView6.Rows[i].Cells[j].Value.ToString().Contains(textBox36.Text))
                        {
                            dataGridView6.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox36.Text = null;
        }
        //
        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView7.Rows[selectedRow];
            textBox38.Text = row.Cells[0].Value.ToString();
            textBox39.Text = row.Cells[1].Value.ToString();
            textBox40.Text = row.Cells[2].Value.ToString();
            textBox41.Text = row.Cells[3].Value.ToString();
            textBox42.Text = row.Cells[4].Value.ToString();
            textBox43.Text = row.Cells[5].Value.ToString();
            textBox44.Text = row.Cells[6].Value.ToString();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            avtocentrDataSet.Статус.Rows.Add(textBox38.Text, textBox39.Text, textBox40.Text, textBox41.Text, textBox42.Text, textBox43.Text, textBox44.Text);
            dataGridView7.DataSource = avtocentrDataSet.Техника;

            this.Validate();
            this.техникаBindingSource.EndEdit();
            this.техникаTableAdapter.Update(this.avtocentrDataSet.Техника);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDatarow = dataGridView6.Rows[selectedRow];
            newDatarow.Cells[0].Value = textBox38.Text;
            newDatarow.Cells[1].Value = textBox39.Text;
            newDatarow.Cells[2].Value = textBox40.Text;
            newDatarow.Cells[3].Value = textBox41.Text;
            newDatarow.Cells[4].Value = textBox42.Text;
            newDatarow.Cells[5].Value = textBox43.Text;
            newDatarow.Cells[6].Value = textBox44.Text;

            this.Validate();
            this.техникаBindingSource.EndEdit();
            this.техникаTableAdapter.Update(this.avtocentrDataSet.Техника);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            DialogResult vibor2 = MessageBox.Show("Вы действительно хотите удалить строку?", "Сообщение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (vibor2 == DialogResult.Yes)
            {
                selectedRow = dataGridView7.CurrentCell.RowIndex;
                dataGridView7.Rows.RemoveAt(selectedRow);

                this.Validate();
                this.техникаBindingSource.EndEdit();
                this.техникаTableAdapter.Update(this.avtocentrDataSet.Техника);
            }
            else
                MessageBox.Show("Вы не удалили строку!");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            textBox37.Text = null;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView7.RowCount; i++)
            {
                dataGridView7.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView7.ColumnCount; j++)
                    if (dataGridView7.Rows[i].Cells[j].Value != null)
                        if (dataGridView7.Rows[i].Cells[j].Value.ToString().Contains(textBox37.Text))
                        {
                            dataGridView7.Rows[i].Selected = true;
                            break;
                        }
            }
        }
        //
        private void button53_Click(object sender, EventArgs e)
        {
            Отчет newForm = new Отчет();
            newForm.Show();
        }
        //
    }
}
