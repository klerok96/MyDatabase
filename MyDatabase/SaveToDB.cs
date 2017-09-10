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

        public SaveToDB()
        {
            InitializeComponent();
        }

        public SaveToDB(ViewWindow form)
        {
            InitializeComponent();

            _form = form;

            FieldsFilling();
        }

        void FieldsFilling()
        {
            if (_form.FlagSelectedBtn == 1)
            {
                List<string> data = _form.DataForBtnUpdate;

                TextBoxCarName.Text = data[1];
                TextBoxCost.Text = data[2];
                TextBoxPower.Text = data[3];
                TextBoxConsumption.Text = data[4];
                ComboBoxColor.Text = data[5];
                ComboBoxDiskName.Text = data[6];
            }

            using (CarsEntities contextEntities = new CarsEntities())
            {
                var listCar = contextEntities.Colors.ToList();
                var listDisk = contextEntities.DiskCars.ToList();

                foreach (var i in listCar)
                    ComboBoxColor.Items.Add(i.ColorName);

                foreach (var i in listDisk)
                   ComboBoxDiskName.Items.Add(i.DiskCarName);
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
            decimal cost = Convert.ToDecimal(TextBoxCost.Text);
            int power = Convert.ToInt32(TextBoxPower.Text);
            int consumption = Convert.ToInt32(TextBoxConsumption.Text);
            int color = ComboBoxColor.SelectedIndex + 1;
            int disk = ComboBoxDiskName.SelectedIndex + 1;

            var carItem = new Car
            {
                CarName = nameCar,
                Cost = cost,
                Power = power,
                Consumption = consumption,
                ColorID = color,
                DiskCarID = disk,
            };

            using (CarsEntities contextEntities = new CarsEntities())
            {
                contextEntities.Cars.Add(carItem);
                contextEntities.SaveChanges();
            }

            _form.DBView();
        }

        void UpdateToDB()
        {
            int id = Convert.ToInt32(_form.DataForBtnUpdate[0]);
            string nameCar = TextBoxCarName.Text;
            decimal cost = Convert.ToDecimal(TextBoxCost.Text);
            int power = Convert.ToInt32(TextBoxPower.Text);
            int consumption = Convert.ToInt32(TextBoxConsumption.Text);
            int color;
            int disk;

            if (ComboBoxColor.SelectedIndex == -1)
                color = ComboBoxColor.Items.IndexOf(ComboBoxColor.Text) + 1;
            else
                color = ComboBoxColor.SelectedIndex + 1;

            if (ComboBoxDiskName.SelectedIndex == -1)
                disk = ComboBoxDiskName.Items.IndexOf(ComboBoxDiskName.Text) + 1;
            else
                disk = ComboBoxDiskName.SelectedIndex + 1;

            using (CarsEntities contextEntities = new CarsEntities())
            {
                Car carItem = (from ca in contextEntities.Cars
                               where ca.CarID == id
                               select ca).FirstOrDefault();

                carItem.CarName = nameCar;
                carItem.Cost = cost;
                carItem.Power = power;
                carItem.Consumption = consumption;
                carItem.ColorID = color;
                carItem.DiskCarID = disk;

                contextEntities.SaveChanges();
            }

            _form.DBView();
        }
    }
}
