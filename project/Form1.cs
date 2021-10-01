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
    public partial class milkShop : Form
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

        public milkShop()
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

                //receipt printing
















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
                cashInput.Text = "0";

                //wait to build suspence
                Refresh();
                Thread.Sleep(1500);

                //getting rid of alert
                refreshButton.Visible = false;
                errorMessage.Visible = false;
            }

            private void printRe_Click(object sender, EventArgs e)
            {
            SoundPlayer receiptPrint = new  SoundPlayer(Properties.Resources.kitchen_ticket_printer_sound);
            receiptPrint.Play();

            //setting values

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
            onePerN.Text = $"X {onePercNum}";
            twoPerN.Text = $"X {twoPercNum}";
            threePerN.Text = $"X {thrPercNum}";
            wholeN.Text = $"X {whoPercNum}";
            skimN.Text = $"X {skiPercNum}";

            //making receipt visible

            if (onePercNum > 0)
            {
             oneCost.Visible = true; 
             oneLab.Visible = true;
             onePerN.Visible = true;
            }    

            label2.Visible = true;
            label2.SendToBack();

            Refresh();
            Thread.Sleep(500);

            if (twoPercNum > 0)
            {
                twoPerN.Visible = true;
                twoLab.Visible = true;
                twoCost.Visible = true;
            }

            Refresh();
            Thread.Sleep(500);

            if (thrPercNum > 0)
            {
                ThrLab.Visible = true;
                threeCost.Visible = true;
                threePerN.Visible = true;
            }

            Refresh();
            Thread.Sleep(500);

            if (whoPercNum > 0)
            {
                whoLab.Visible = true;
                wholeCost.Visible = true;
                wholeN.Visible = true;
            }

            Refresh();
            Thread.Sleep(500);

            if (skiPercNum > 0)
            {
                skimLab.Visible = true;
                skimCost.Visible = true;
                skimN.Visible = true;
            }

            Refresh();
            Thread.Sleep(500);
            
            subtotalLab.Visible = true;  
            subtotCost.Visible = true;  
               
            Refresh();
            Thread.Sleep(500);
             
            taxLab.Visible = true;   
            taxCo.Visible = true;   
                
            Refresh();
            Thread.Sleep(500);
                
            totalab.Visible = true;
            totalCo.Visible = true;    

            Refresh();
            Thread.Sleep(500);

            cashCost.Visible = true;
            cashCo.Visible = true; 
              
            Refresh();
            Thread.Sleep(500);

            changeCost.Visible = true;
            changeLab.Visible = true;

            Refresh();
            Thread.Sleep(500);

            noRe.Visible = true;
            thank.Visible = true;
            
            Refresh();
            Thread.Sleep(250);

            resetButton.Visible = true;
           
            }

        private void resetButton_Click(object sender, EventArgs e)
        {


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
            cashInput.Text = "0";
                oneCost.Text = $"xx";
                twoCost.Text = $"xx";
                threeCost.Text = $"xx";
                wholeCost.Text = $"xx";
                skimCost.Text = $"xx";
                totalCo.Text = $"xx";
                taxCo.Text = $"xx";
                subtotCost.Text = $"xx";
                cashCo.Text = $"xx";
                changeCost.Text = $"xx";
                onePerN.Text = $"X 0";
                twoPerN.Text = $"X 0";
                threePerN.Text = $"X 0";
                wholeN.Text = $"X 0";
                skimN.Text = $"X 0";

            //making receipt invisible
            whoLab.Visible = false;
            wholeCost.Visible = false;
            wholeN.Visible = false;

            oneCost.Visible = false;
            oneLab.Visible = false;
            onePerN.Visible = false;

            twoPerN.Visible = false;
            twoLab.Visible = false;
            twoCost.Visible = false;

            ThrLab.Visible = false;
            threeCost.Visible = false;
            threePerN.Visible = false;

            skimLab.Visible = false;
            skimCost.Visible = false;
            skimN.Visible = false;

            changeCost.Visible = false;
            changeLab.Visible = false;

            cashCost.Visible = false;
            cashCo.Visible = false;

            totalab.Visible = false;
            totalCo.Visible = false;

            taxLab.Visible = false;
            taxCo.Visible = false;

            subtotalLab.Visible = false;
            subtotCost.Visible = false;

            resetButton.Visible = false;
            label2.Visible = false;
        }
    }
    } 
