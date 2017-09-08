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
    public partial class SaveToDB : Form
    {
        ViewWindow _form;

        string _connectionString;

        public SaveToDB()
        {
            InitializeComponent();
        }

        public SaveToDB(ViewWindow form)
        {
            InitializeComponent();

            _form = form;

            _connectionString = @"server=LAPTOP-B6SOJQMR;Initial Catalog=Cars;Integrated Security=True;Persist Security Info=False;";

            FieldsFilling();
        }

        void FieldsFilling()
        {
            if (_form.FlagSelectedBtn == 1)
            {
                this.Text = "Update to db";

                List<string> data = _form.DataForBtnUpdate;

                TextBoxCarName.Text = data[1];
                TextBoxCost.Text = data[2];
                TextBoxPower.Text = data[3];
                TextBoxConsumption.Text = data[4];
                ComboBoxColor.Text = data[5];
                ComboBoxDiskName.Text = data[6];
            }

            string sqlExpressionColor = "SELECT * FROM Color";
            string sqlExpressionDisk = "SELECT * FROM DiskCar";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand comman = new SqlCommand();
                comman.Connection = connection;
                comman.CommandText = sqlExpressionColor;

                SqlDataReader reader = comman.ExecuteReader();

                while (reader.Read())
                    ComboBoxColor.Items.Add(reader.GetString(1));

                reader.Close();

                comman.CommandText = sqlExpressionDisk;
                SqlDataReader readerDisk = comman.ExecuteReader();

                while (readerDisk.Read())
                    ComboBoxDiskName.Items.Add(readerDisk.GetString(1));
            }
        }

        private void BtnSaveToDB_Click(object sender, EventArgs e)
        {
            if (_form.FlagSelectedBtn == 0)
                AddToDB();
            if (_form.FlagSelectedBtn == 1)
                UpdateToDB();

            this.Close();
        }

        void AddToDB()
        {
            string nameCar = TextBoxCarName.Text;
            string cost = TextBoxCost.Text;
            string power = TextBoxPower.Text;
            string consumption = TextBoxConsumption.Text;
            string color = Convert.ToString(ComboBoxColor.SelectedIndex + 1);
            string disk = Convert.ToString(ComboBoxDiskName.SelectedIndex + 1);

            string sqlExpression = "INSERT Cars.dbo.Car VALUES (@name, @cost, @power, @consumption, @color, @disk)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@name", nameCar);
                command.Parameters.AddWithValue("@cost", cost);
                command.Parameters.AddWithValue("@power", power);
                command.Parameters.AddWithValue("@consumption", consumption);
                command.Parameters.AddWithValue("@color", color);
                command.Parameters.AddWithValue("@disk", disk);

                command.ExecuteNonQuery();
            }

            _form.DBView();
        }

        void UpdateToDB()
        {
            string id = _form.DataForBtnUpdate[0];
            string nameCar = TextBoxCarName.Text;
            string cost = TextBoxCost.Text;
            string power = TextBoxPower.Text;
            string consumption = TextBoxConsumption.Text;
            string color;
            string disk;

            if (ComboBoxColor.SelectedIndex == -1)
                color = Convert.ToString(ComboBoxColor.Items.IndexOf(ComboBoxColor.Text) + 1);
            else
                color = Convert.ToString(ComboBoxColor.SelectedIndex + 1);

            if (ComboBoxDiskName.SelectedIndex == -1)
                disk = Convert.ToString(ComboBoxDiskName.Items.IndexOf(ComboBoxDiskName.Text) + 1);
            else
                disk = Convert.ToString(ComboBoxDiskName.SelectedIndex + 1);

            string sqlExpression = "UPDATE Cars.dbo.Car " +
                "SET CarName = @name, Cost = @cost, Power = @power, Consumption = @consumption, ColorID = @color, DiskCarID = @disk " +
                "WHERE CarID = @id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@name", nameCar);
                command.Parameters.AddWithValue("@cost", cost);
                command.Parameters.AddWithValue("@power", power);
                command.Parameters.AddWithValue("@consumption", consumption);
                command.Parameters.AddWithValue("@color", color);
                command.Parameters.AddWithValue("@disk", disk);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }

            _form.DBView();
        }
    }
}
