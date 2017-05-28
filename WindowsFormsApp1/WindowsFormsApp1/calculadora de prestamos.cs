using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Ventana : Form
    {


        public Ventana()

        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); // English - US
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");// English - US
            InitializeComponent();

        }

        
       
        decimal interes = 0;
        decimal monto = 0;
        double periodo = 0;
        decimal r = 0;


        decimal amortip=0;
        decimal amortiac=0;
        decimal pagoint=0;
        decimal interestotal = 0;
        decimal nume;
        decimal ct;

        public void Guardar(decimal interes, decimal monto, double periodo)
        {

            interes = Convert.ToDecimal(itxt.Text) / 1200;
            monto = Convert.ToDecimal(mtxt.Text);
            periodo = Convert.ToDouble(ptxt.Text) * 12;
          
           


            r = monto * (interes / (1 - (decimal)Math.Pow(1 + (double)interes, -periodo)));

            DataTable datat = new DataTable();

            datat.Columns.Add("Periodo de pago");
            datat.Columns.Add("Cuota");
            datat.Columns.Add("Pago de Interes");
            datat.Columns.Add("Amortizacion principal");
            datat.Columns.Add("Amortizacion acumulada");
            datat.Columns.Add("Capital Pendiente");


            ct = r * (Convert.ToDecimal(periodo));
            interestotal = ct - monto;

            pm.Text = Convert.ToString(Math.Round(r,2));
            np.Text = Convert.ToString(periodo);
            it.Text = Convert.ToString(Math.Round(interestotal,2));
            costototal.Text = Convert.ToString(Math.Round(ct,2));


            for (int i = 1; i <= periodo; i++)
            {

                pagoint = monto * interes;

                amortip = r - pagoint;
                amortiac+= amortip;
                monto-= amortip;
              

                DataRow row = datat.NewRow();

                row["Periodo de pago"] = i;
                row["Cuota"] = Math.Round(r, 2);
                row["Pago de Interes"] = Math.Round(pagoint,2);
                row["Amortizacion principal"] = Math.Round(amortip, 2);
                row["Amortizacion acumulada"] = Math.Round(amortiac, 2);
                row["Capital Pendiente"] = Math.Round(monto, 2);

                datat.Rows.Add(row);
            }

            

            dataGridView1.DataSource = datat;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guardar(interes,monto,periodo);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          


        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pm_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
