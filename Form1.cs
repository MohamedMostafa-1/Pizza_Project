using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float CalcultedCrustPrice()
        {
            if (rdThinCrust.Checked)
                return Convert.ToSingle(rdThinCrust.Tag);
            else
                return Convert.ToSingle(rdThinkCrust.Tag); 
        }
        float CalcultedToppingPrice()
        {
            float TotalPrice = 0;

            if (chkExtraChees.Checked)
                TotalPrice += Convert.ToSingle(chkExtraChees.Tag);

            if (chkGreenPeppers.Checked)
                TotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);

            if (chkMushrooms.Checked)
                TotalPrice += Convert.ToSingle(chkMushrooms.Tag);

            if (chkOlives.Checked)
                TotalPrice += Convert.ToSingle(chkOlives.Tag);

            if (chkOnion.Checked)
                TotalPrice += Convert.ToSingle(chkOnion.Tag);

            if (chkTomatoes.Checked)
                TotalPrice += Convert.ToSingle(chkTomatoes.Tag);


            return TotalPrice;
        }
        float CalcultedSizePrice()
        {
            if (rdSmall.Checked)
                return Convert.ToSingle(rdSmall.Tag);
            else if (rdMeduim.Checked)
                return Convert.ToSingle(rdMeduim.Tag);
            else
                return Convert.ToSingle(rdLarge.Tag);
        }
        float CalculteTotalPrice()
        {
            return CalcultedSizePrice() + CalcultedToppingPrice() + CalcultedCrustPrice();
        }

        //Logical Functions
        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateTopping();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }
        void UpdateTotalPrice()
        {
            lbPrice.Text = "$" + CalculteTotalPrice().ToString();
        }
        void UpdateTopping()
        {
            UpdateTotalPrice();
            string sTopping = "";

            if (chkExtraChees.Checked)
            {
                sTopping = "Extra Chees";
            }
            if (chkGreenPeppers.Checked)
            {
                sTopping += ",Green Peppers";
            }
            if (chkMushrooms.Checked)
            {
                sTopping += ",Mushrooms";
            }
            if (chkOlives.Checked)
            {
                sTopping += ",Olives";
            }
            if (chkOnion.Checked)
            {
                sTopping += ",Onion";
            }
            if (chkTomatoes.Checked)
            {
                sTopping += ",Tomatoes";
            }

            if (sTopping == "")
                sTopping = "No Topping";

            if (sTopping.StartsWith(","))
            {
                sTopping = sTopping.Substring(1, sTopping.Length - 1).Trim();
            }

            lblResultTopping.Text = sTopping;
        }
        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rdThinCrust.Checked)
            {
                lbResultCurst.Text = "Thin Crust";
                return;
            }
            if (rdThinkCrust.Checked)
            {
                lbResultCurst.Text = "Think Crust";
                return;
            }
            
        }
        void UpdateWhereToEat()
        {
            if (rdEatIn.Checked)
            {
                lbReusltWhereToEat.Text = "Eat In";
                return;
            }

            if (rdTakeOut.Checked)
            {
                lbReusltWhereToEat.Text = "Take Out";
                return;
            }

        }
        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rdSmall.Checked)
            {
                lbResultSize.Text = "Small";
                return;
            }
            if (rdMeduim.Checked)
            {
                lbResultSize.Text = "Meduim";
                return;
            }
            if (rdLarge.Checked)
            {
                lbResultSize.Text = "Large";
                return;
            }
        }

        

        private void rdSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rdMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rdLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
       



        private void rdEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rdTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }


        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order" , "Confirm" , MessageBoxButtons.OKCancel ,MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully" , "Success" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                btnOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbCrustType.Enabled = false;
                gbTopping.Enabled = false;
                gbWhereToEat.Enabled = false;
            }
        }

        private void rdThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }
        private void rdThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            gbCrustType.Enabled = true;
            gbSize.Enabled = true;
            gbTopping.Enabled = true;
            gbWhereToEat.Enabled = true;
            btnOrderPizza.Enabled = true;

            rdSmall.Checked = true;
            rdEatIn.Checked = true;
            rdThinCrust.Checked = true;
            chkExtraChees.Checked = true;

        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }
        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTopping();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }
}
