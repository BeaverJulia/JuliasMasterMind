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
        List<Button> ColoranswerRow;
        List<Color> colors = new List<Color>();
        Random random;
        int[] indexofColors;
        List<int> limit;
        public Form1()
        {
            InitializeComponent();
            
            arrayOfcolors = new Color[] { Color.White, Color.Aqua, Color.Coral, Color.DarkGreen, Color.DeepPink, Color.Yellow };
             ColorsFirstRow = new List<Button>();
            ColorsSecondRow = new List<Button>();
             ColorsThirdRow = new List<Button>();
             ColorsFourthRow = new List<Button>();
             ColorsFifthRow = new List<Button>();
           ColorssixthRow = new List<Button>();
             ColorsseventhRow = new List<Button>();
           ColoranswerRow = new List<Button>();
            List<Color> colors = new List<Color>();
           
           



            List<Control> list = new List<Control>();//zbieranie buttonów i dodawanie do odpowiedniej listy

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
                                ColorsFifthRow.Add(temp);
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
                        case "Answer":
                            {
                                ColoranswerRow.Add(temp);

                                break;
                            }
                    }
                }
            }

            shuffle();

        }

        public void shuffle()
        {
            limit = new List<int>() { 1, 2, 3, 4, 5 };
            random = new Random();
            int range = 5;
            for (int i = 0; i < 5; i++)
            {

                    while (colors.Count() >0)
                    {
                        int randomcolor = random.Next(0, range);
                        range--;
                        colors.Add(arrayOfcolors[randomcolor]);
                    
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
 
       private void Check(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                ColoranswerRow[i].BackColor = colors[i];
            }

        }
    }
}
