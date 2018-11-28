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
        Color[] arrayOfcolors;  //mozliwe kolory

        List<Button> ColorsFirstRow;    //pola dla gracza pola odpowiedzi
        List<Button> ColorsSecondRow;
        List<Button> ColorsThirdRow;
        List<Button> ColorsFourthRow;
        List<Button> ColorsFifthRow;
        List<Button> ColorsSixthRow;
        List<Button> ColorsSeventhRow;

        List<List<Button>> ListOfRowColors;   // lista list rzędów

        List<Button> AnswerFirstRow;    // result of player choice
        List<Button> AnswerSecondRow;
        List<Button> AnswerThirdRow;
        List<Button> AnswerFourthRow;
        List<Button> AnswerFifthRow;
        List<Button> AnswerSixthRow;
        List<Button> AnswerSeventhRow;

        int indexofActualRow;
        List<List<Button>> ListOfResults; // list of results

        List<Button> ColoranswerRow; //buttony z odpowiedziami


        Color[] ShuffledColors; //tablica juz losowo ulozonych kolorow
        
        int blocker;

        public Form1()
        {
            InitializeComponent();

           arrayOfcolors = new Color[] { Color.Orange , Color.Aqua, Color.LightCoral, Color.DarkBlue, Color.DeepPink, Color.Yellow, Color.Brown , Color.LightGreen ,Color.Red};
           ColorsFirstRow = new List<Button>();
           ColorsSecondRow = new List<Button>();
           ColorsThirdRow = new List<Button>();
           ColorsFourthRow = new List<Button>();
           ColorsFifthRow = new List<Button>();
           ColorsSixthRow = new List<Button>();
           ColorsSeventhRow = new List<Button>();
           ColoranswerRow = new List<Button>();

           ListOfRowColors = new List<List<Button>>()
            { 
             ColorsFirstRow,
             ColorsSecondRow,
             ColorsThirdRow,
             ColorsFourthRow,
             ColorsFifthRow,
             ColorsSixthRow,
             ColorsSeventhRow
            };
           
           AnswerFirstRow = new List<Button> ();
           AnswerSecondRow = new List<Button>();
           AnswerThirdRow = new List<Button>();
           AnswerFourthRow = new List<Button>();
           AnswerFifthRow = new List<Button>();
           AnswerSixthRow = new List<Button>();
           AnswerSeventhRow = new List<Button>();
            ListOfResults = new List<List<Button>>()
           {
                AnswerFirstRow,
                AnswerSecondRow,
                AnswerThirdRow,
                AnswerFourthRow,
                AnswerFifthRow,
                AnswerSixthRow,
                AnswerSeventhRow,
           };
           indexofActualRow = 0;

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
                                ColorsSixthRow.Add(temp);
                                break;
                            }
                        case "seventh":
                            {
                                ColorsSeventhRow.Add(temp);
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
                                AnswerSixthRow.Add(temp);
                                break;
                            }
                        case "Control7":
                            {
                                AnswerSeventhRow.Add(temp);
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
            ShuffledColors= new Color[5];
            List<int> poss = new List<int>() { 0, 1, 2, 3, 4 };
            Random random = new Random();
            int range = 4;
            for (int i=0;i<5;i++)
            {
                int rand = random.Next(0, range);
                range--;
                indexes[i] = poss[rand];
                poss.Remove(indexes[i]);
                ShuffledColors[i] = arrayOfcolors[indexes[i]];
            }
            

        }
        int indexactualcolor = 0;
        public void ChangeColor(object sender, EventArgs e)
        {
            Button clickbutton = (Button)sender;

                    if (indexactualcolor ==9)
                    {
                        indexactualcolor = 0;
                    }
            clickbutton.BackColor = arrayOfcolors[indexactualcolor];

            indexactualcolor++;
                
           

        }
        public void CheckIfWin(object sender, EventArgs e)
        {
            int j = 0;
            int k = 0;
            Button clickbutton = (Button)sender;
            for (int i = 0; i < 5; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    try
                    {
                        if (ListOfRowColors[indexofActualRow][i].BackColor == ShuffledColors[ii])  // jesli dany kolor istnieje w naszej odpowiedzi 
                        {
                            if (ListOfRowColors[indexofActualRow][i].BackColor == ShuffledColors[i])
                            {
                                ListOfResults[indexofActualRow][j].BackColor = Color.Black;      // prawidlowe miejsce i prawidlowy kolor
                                k++;
                            }
                            else
                            {
                                ListOfResults[indexofActualRow][j].BackColor = Color.Red;        //prawidlowy kolor
                            }
                            j++;
                        }
                    }
                    catch (Exception s)
                    {
                        MessageBox.Show("Something Went wrong :("+ s);

                    }
                }
            }
            indexofActualRow++;
            if (k == 5)
            {
                textBox1.Text = "YOU WON";
                pictureBox1.Image = Properties.Resources.won;
            }
            else
            {
                textBox1.Text = "TRY AGAIN";
                pictureBox1.Image = Properties.Resources.cheater2;
            }
            blocker = k;
        }
 
        private void Check(object sender, EventArgs e)
        {

            textBox1.Text = "YOU LOST";
            pictureBox1.Image = Properties.Resources.cheater2;

            for (int i = 0; i < 5; i++)
                {
                    ColoranswerRow[i].BackColor = ShuffledColors[i];
                }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SHOW(object sender, EventArgs e)
        {

        }

        private void button78_Click(object sender, EventArgs e)
        {
            HELP form2 = new HELP();

            form2.Show();
        }
    }
}
