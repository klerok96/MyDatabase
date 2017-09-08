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

namespace MyDatabase
{
    public partial class ViewWindow : Form
    {
        string _connectionString;
        int _pageNumber = 0;
        int _pageSize = 10;
        int _quantityData;
        //bool _flagProgramStart = false;
        public List<string> DataForBtnUpdate;
        public int FlagSelectedBtn;

        public ViewWindow()
        {
            InitializeComponent();

            _connectionString = @"server=LAPTOP-B6SOJQMR;Initial Catalog=Cars;Integrated Security=True;Persist Security Info=False;";

            dataGridView1.AllowUserToAddRows = false; //запрешаем пользователю самому добавлять строки
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DBView();
        }

        public void DBView()
        {
            string sqlExpressionDataCount = "SELECT COUNT(*) FROM Cars.dbo.Car";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(sqlExpressionDataCount, connection);

                _quantityData = (int)cmd.ExecuteScalar();
            }

            Paging();
        }

        void Paging()
        {
            if (true)
                dataGridView1.Rows.Clear();

            if (_pageNumber == _quantityData / 10)
                BtnNextPage.Enabled = false;
            else
                BtnNextPage.Enabled = true;

            if (_pageNumber == 0)
                BtnPreviousPage.Enabled = false;
            else
                BtnPreviousPage.Enabled = true;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlExpressionData = string.Format("WITH num_row " +
                    "AS(SELECT row_number() OVER(ORDER BY CarID) as nom, *FROM Cars.dbo.Car) " +
                    "SELECT * FROM num_row " +
                    "INNER JOIN Cars.dbo.Color ON num_row.ColorID = Color.ColorID " +
                    "INNER JOIN Cars.dbo.DiskCar ON DiskCar.DiskCarID = num_row.DiskCarID " +
                    "WHERE nom BETWEEN {0} AND {1}", _pageNumber * _pageSize + 1, (_pageNumber + 1) * _pageSize);

                SqlCommand command = new SqlCommand(sqlExpressionData, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    dataGridView1.Rows.Add(reader.GetInt32(1).ToString(), reader.GetString(2),
                    reader.GetDecimal(3).ToString(), reader.GetInt32(4).ToString(),
                    reader.GetInt32(5).ToString(), reader.GetString(9), (reader.GetString(11)));
                }
            }

            LbViewPage.Text = string.Format("Page {0}/{1}", _pageNumber + 1, Convert.ToInt32(_quantityData / 10) + 1);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FlagSelectedBtn = 0;

            SaveToDB addForm = new SaveToDB(this);
            addForm.Show();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            FlagSelectedBtn = 1;

            DataForBtnUpdate = new List<string>();

            for (int i = 0; i < 7; i++)
                DataForBtnUpdate.Add(dataGridView1.SelectedCells[i].Value.ToString());

            SaveToDB addForm = new SaveToDB(this);
            addForm.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string sqlExpression = "DELETE FROM Cars.dbo.Car WHERE CarID = @id";

            string id = dataGridView1.SelectedCells[0].Value.ToString();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }

            DBView();
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            _pageNumber++;
            Paging();
        }

        private void BtnPreviousPage_Click(object sender, EventArgs e)
        {
            _pageNumber--;
            Paging();
        }
    }
}
