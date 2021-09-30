using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
namespace project
{
    public partial class Form1 : Form
    {
        //tax
        double taxRate = 0.13;

        //prices
        double onePrice = 1.50;
        double twoPrice = 1.75;
        double thrPrice = 2.00;
        double whoPrice = 2.50;
        double skiPrice = 1.00;

        //number of items ordered
        int onePercNum = 0;
        int twoPercNum = 0;
        int thrPercNum = 0;
        int whoPercNum = 0;
        int skiPercNum = 0;

        //total cost of each item
        double taxTot = 0;
        double oneTot = 0;
        double twoTot = 0;
        double thrTot = 0;
        double whoTot = 0;
        double skiTot = 0;

        //cash given
        double cashPaid = 0;

        //cost without tax
        double totalCost = 0;

        //cost with tax
        double GrandTot = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void checkout_Click(object sender, EventArgs e)
        {
            try
            {
                //cash register sound
                SoundPlayer alertplayer = new SoundPlayer(Properties.Resources.mny1);
                alertplayer.Play();


                //getting inputs ammounts of items
                onePercNum = Convert.ToInt32(OnePerInput.Text);
                twoPercNum = Convert.ToInt32(twoPerInput.Text);
                thrPercNum = Convert.ToInt32(ThreePerInput.Text);
                whoPercNum = Convert.ToInt32(wholeMilkInput.Text);
                skiPercNum = Convert.ToInt32(fakeLoserMilkInput.Text);

                //total cost of each item without tax
                oneTot = onePrice * onePercNum;
                twoTot = twoPrice * twoPercNum;
                thrTot = thrPrice * thrPercNum;
                whoTot = whoPrice * whoPercNum;
                skiTot = skiPrice * skiPercNum;

                //cost calculations
                totalCost = oneTot + twoTot + thrTot + skiTot + whoTot;
                taxTot = totalCost * taxRate;
                GrandTot = taxTot + totalCost;

                //displaying cost 
                Cost.Text = $"{totalCost:C}";
                total.Text = $"{GrandTot:C}";
                taxAmount.Text = $"{taxTot:C}";
                


            }
            catch {

                //error alert for checkout
                errorMessage.Visible = true;
                errorMessage.BringToFront();

                refreshButton.Visible = true;
                refreshButton.BringToFront();

                //error sound
                SoundPlayer errorSound = new SoundPlayer(Properties.Resources.sound103);
                errorSound.Play();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //print receipt
                printRe.Visible = true;
                 button1.Visible = false;
                
                //cash given 
                cashPaid = Convert.ToDouble(cashInput.Text);
                change.Text = $"{cashPaid - GrandTot:C}";
                amoPaid.Text = $"{cashPaid:C}";

            }
            catch
            {
                //error alert for pay button
                errorMessage.Visible = true;
                errorMessage.BringToFront();
                refreshButton.Visible = true;
                refreshButton.BringToFront();

                //error sound
                SoundPlayer errorSound = new SoundPlayer(Properties.Resources.sound103);
                errorSound.Play();
            }

        }

            private void refreshButton_Click(object sender, EventArgs e)
            {
                //full reset of variables
                OnePerInput.Text = "0";
                twoPerInput.Text = "0";
                ThreePerInput.Text = "0";
                fakeLoserMilkInput.Text = "0";
                wholeMilkInput.Text = "0";
                onePercNum = 0;
                twoPercNum = 0;
                thrPercNum = 0;
                whoPercNum = 0;
                skiPercNum = 0;
                taxTot = 0;
                oneTot = 0;
                twoTot = 0;
                whoTot = 0;
                skiTot = 0;
                cashPaid = 0;
                totalCost = 0;
                GrandTot = 0;
                taxAmount.Text = "xx";
                amoPaid.Text = "xx";
                Cost.Text = "xx";
                total.Text = "xx";
                change.Text = "xx";

                //wait to build suspence
                Refresh();
                Thread.Sleep(1500);

                //getting rid of alert
                refreshButton.Visible = false;
                errorMessage.Visible = false;
            }

            private void printRe_Click(object sender, EventArgs e)
            {
            //will make a slow reveil later

            //making receipt visible
                label2.Visible = true;
                oneLab.Visible = true;
                twoLab.Visible = true;
                ThrLab.Visible = true;
                whoLab.Visible = true;
                skimLab.Visible = true;
                oneCost.Visible = true;
                twoCost.Visible = true;
                threeCost.Visible = true;
                wholeCost.Visible = true;
                skimCost.Visible = true;
                subtotalLab.Visible = true;
                taxLab.Visible = true;
                totalab.Visible = true;
                change.Visible = true;
                cashCost.Visible = true;
                subtotCost.Visible = true;
                totalCo.Visible = true;
                taxCo.Visible = true;
                cashCo.Visible = true;
                changeLab.Visible = true;
                changeCost.Visible = true;

                // displaying costs and cash paid
                oneCost.Text = $"{oneTot:C}";
                twoCost.Text = $"{twoTot:C}";
                threeCost.Text = $"{thrTot:C}";
                wholeCost.Text = $"{whoTot:C}";
                skimCost.Text = $"{skiTot:C}";
                totalCo.Text = $"{GrandTot:C}";
                taxCo.Text = $"{taxTot:C}";
                subtotCost.Text = $"{totalCost:C}";
                cashCo.Text = $"{cashPaid:C}";
                changeCost.Text = $"{cashPaid - GrandTot:C}";

            }

        }
    } 
