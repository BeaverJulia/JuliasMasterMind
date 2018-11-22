using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuliasMasterMind
{

    public partial class Form1 : Form
    {
        Color[] arrayOfcolors;
        List<Button> ColorsFirstRow;
        List<Button>  ColorsSecondRow;
        List<Button> ColorsThirdRow;
        List<Button> ColorsFourthRow;
        List<Button> ColorsFifthRow;
        List<Button> ColorssixthRow;
        List<Button> ColorsseventhRow;
        int[] indexofColors;
        
        public Form1()
        {
            InitializeComponent();
            
            arrayOfcolors = new Color[] { Color.White, Color.Aqua, Color.Coral, Color.DarkGreen, Color.DeepPink, Color.Yellow };
            Random random = new Random();

            int[]
            List<Color> colors = new List<Color>(5);
                for (int i = 0; i < 5; i++)
            {
                
                int randomcolor = random.Next(1, 5);

                colors[i] = arrayOfcolors[randomcolor];
                
            }





            
            List<Control> list = new List<Control>();

            foreach (var control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button temp = (Button)control;
                    switch (temp.Tag)
                    {
                            case "first":
                            {
                                ColorsFirstRow.Add(temp);
                                break;
                            }
                        case "second":
                            {
                                ColorsSecondRow.Add(temp);
                                break;
                            }
                        case "third":
                            {
                                ColorsThirdRow.Add(temp);
                                break;
                            }
                        case "fourth":
                            {
                                ColorsFourthRow.Add(temp);
                                break;
                            }
                        case "fifth":
                            {
                                ColorsThirdRow.Add(temp);
                                break;
                            }
                        case "sixth":
                            {
                                ColorssixthRow.Add(temp);
                                break;
                            }
                        case "seventh":
                            {
                                ColorsseventhRow.Add(temp);
                                break;
                            }
                    }
                }
            }

          
        }

        public void ChangeColor(object sender, EventArgs e)
        {
            Color actual;
            Button clickbutton = (Button)sender;
            indexofColors = new int[5] { 0, 0, 0, 0, 0 };
            for (int i = 0; i < 6; i++)
            {
                if (clickbutton.BackColor == arrayOfcolors[i])
                {
                    if (i == 5)
                    {
                        clickbutton.BackColor = arrayOfcolors[0];
                    }
                    else
                    {
                        clickbutton.BackColor = arrayOfcolors[i + 1];
                    }
                    break;
                }
            }

        }
        public class Checker
        {
            
        }
    
      

        
        private void Check(object sender, EventArgs e)
        {

        }
    }
}
