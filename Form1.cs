namespace Datagridview_sumRange
{
    public partial class Form1 : Form
    {

        private DataGridViewTextBoxColumn columnHeader1 = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn columnHeader2 = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn columnHeader3 = new DataGridViewTextBoxColumn();

        public Form1()
        {
            InitializeComponent();
            statusStrip1.Items["total"].Visible = false;
            statusStrip1.Items["average"].Visible = false;
            columnHeader1.Name = "�s��";
            columnHeader2.Name = "�m�W";
            columnHeader3.Name = "���~";
            dataGridView1.Columns.Add(columnHeader1);
            dataGridView1.Columns.Add(columnHeader2);
            dataGridView1.Columns.Add(columnHeader3);

            dataGridView1.Rows.Add(new object[] { 1, "�����", 50000 });
            dataGridView1.Rows.Add(new object[] { 2, "���p��", 35000 });
            dataGridView1.Rows.Add(new object[] { 3, "���j�H", 100000 });
            dataGridView1.Rows.Add(new object[] { 4, "������", 60000 });
            dataGridView1.Rows.Add(new object[] { 5, "���S�W", 40000 });
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            statusStrip1.Items["total"].Visible = true;
            statusStrip1.Items["average"].Visible = true;

            float sumNumbers = 0;
            float avgNumbers = 0;
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                var selectedCell = dataGridView1.SelectedCells[i];
                if (selectedCell.ColumnIndex == dataGridView1.Columns["���~"].Index)
                {
                    float nextNumber = 0;

                    if (float.TryParse(selectedCell.FormattedValue.ToString(), out nextNumber))
                        sumNumbers += nextNumber;

                    if (float.TryParse(selectedCell.FormattedValue.ToString(), out nextNumber))
                        avgNumbers += nextNumber;
                }
                else
                {
                    statusStrip1.Items["total"].Text = "";
                    statusStrip1.Items["total"].Visible = false;
                    statusStrip1.Items["average"].Text = "";
                    statusStrip1.Items["average"].Visible = false;
                }
            }
            avgNumbers = avgNumbers / dataGridView1.SelectedCells.Count;
            statusStrip1.Items["total"].Text = "���~�[�`��:" + Convert.ToString(sumNumbers);
            statusStrip1.Items["average"].Text = "�������~��:" + Convert.ToString(avgNumbers);
        }
    }
}