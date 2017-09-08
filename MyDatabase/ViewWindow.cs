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
        int _quantityData = 0;
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
            using (CarsEntities contextEntities = new CarsEntities())
            {
                _quantityData = contextEntities.Cars.Count();
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

            using (CarsEntities contextEntities = new CarsEntities())
            {
                var query = (from ca in contextEntities.Cars
                             join co in contextEntities.Colors on ca.ColorID equals co.ColorID
                             join di in contextEntities.DiskCars on ca.DiskCarID equals di.DiskCarID
                             orderby ca.CarID
                             select new
                             {
                                 CarID = ca.CarID,
                                 CarName = ca.CarName,
                                 Cost = ca.Cost,
                                 Power = ca.Power,
                                 Consumption = ca.Consumption,
                                 Color = co.ColorName,
                                 DiskName = di.DiskCarName
                             }).Skip(_pageNumber * _pageSize).Take(_pageSize);

                var list = query.ToList();

                foreach (var i in list)
                {
                    dataGridView1.Rows.Add(i.CarID, i.CarName, i.Cost, i.Power, i.Consumption, i.Color, i.DiskName);
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
