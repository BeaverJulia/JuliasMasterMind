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
        List<Button> AnswerFirstRow;
        List<Button> AnswerSecondRow;
        List<Button> AnswerThirdRow;
        List<Button> AnswerFourthRow;
        List<Button> AnswerFifthRow;
        List<Button> AnswersixthRow;
        List<Button> AnswerseventhRow;
        List<Button> ColoranswerRow;
        Color[] AnswerRow;
        Color[] colors;
        int[] indexofColors;
        public Form1()
        {
            InitializeComponent();
            
           arrayOfcolors = new Color[] { Color.White, Color.Aqua, Color.Coral, Color.DarkGreen, Color.DeepPink, Color.Yellow };
            colors = new Color[5];
            AnswerRow = new Color[5];
            ColorsFirstRow = new List<Button>();
           ColorsSecondRow = new List<Button>();
           ColorsThirdRow = new List<Button>();
           ColorsFourthRow = new List<Button>();
           ColorsFifthRow = new List<Button>();
           ColorssixthRow = new List<Button>();
           ColorsseventhRow = new List<Button>();
           ColoranswerRow = new List<Button>();
           AnswerFirstRow = new List<Button> ();
           AnswerSecondRow = new List<Button>();
           AnswerThirdRow = new List<Button>();
           AnswerFourthRow = new List<Button>();
           AnswerFifthRow = new List<Button>();
           AnswersixthRow = new List<Button>();
           AnswerseventhRow = new List<Button>();
            


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
                        case "Control1":
                            {
                                AnswerFirstRow.Add(temp);
                                break;
                            }
                        case "Control2":
                            {
                                AnswerSecondRow.Add(temp);
                                break;
                            }
                        case "Control3":
                            {
                                AnswerThirdRow.Add(temp);
                                break;
                            }
                        case "Control4":
                            {
                                AnswerFourthRow.Add(temp);
                                break;
                            }
                        case "Control5":
                            {
                                AnswerFifthRow.Add(temp);
                                break;
                            }
                        case "Control6":
                            {
                                AnswersixthRow.Add(temp);
                                break;
                            }
                        case "Control7":
                            {
                                AnswerseventhRow.Add(temp);
                                break;
                            }
                    
                    }
                }
            }

            shuffle();

        }

        public void shuffle()
        {
            //1. Uzupełnienie tablicy losowymi indeksami i uzupełnienie tablicy losowymi kolorami
            int[] indexes = new int[5];
            List<int> poss = new List<int>() { 0, 1, 2, 3, 4 };
            Random random = new Random();
            int j = 0;
            int range = 4;
            for (int i=0;i<5;i++)
            {
                int rand = random.Next(0, range);
                range--;
                indexes[i] = poss[rand];
                poss.Remove(indexes[i]);
                colors[i] = arrayOfcolors[indexes[i]];
            }
            for (int i = 0; i < 5; i++)
            {
                AnswerRow[i] = colors[i];
            }

        }
        public void ChangeColor(object sender, EventArgs e)
        {
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
        public void CheckPosition(object sender, EventArgs e)
        {
            int j = 0;
            Button clickbutton = (Button)sender;
            for (int i = 0; i < 5; i++)
            {

                        
                        if(ColorsFirstRow[i].BackColor ==AnswerRow[i])
                        {
                        AnswerFirstRow[j].BackColor = Color.Black;
                        j++;
                          }
                if (j ==5) ;
                {
                    textBox1.Text = "YOU WON";
                }
                
            }
        }
        public void CheckPosition2(object sender, EventArgs e)
        {

        }

        private void Check(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                ColoranswerRow[i].BackColor = colors[i];
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
