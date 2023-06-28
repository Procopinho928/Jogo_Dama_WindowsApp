using System;
using System.Windows.Forms;

namespace JogoDama
{

    public partial class Form1 : Form
    {
        public Button[] botoes = new Button[64];
        public string[] teste = new string[64];
        public int[] jogadas = new int[2];
        public Button[] array = new Button[2];
        public Button[] perdedor = new Button[12];


        public Form1()
        {

            InitializeComponent();
            Zerar();
            CasasPretas();
            label1.Text = "Vez das peças pretas";
            //AtaqueBranco();





        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        public void CasasPretas()//DETECTOR DE TODAS AS CASAS PRETAS
        {
            for (int i = 0; i < Controls.Count; i++)//VAI DE 0 ATE TODOS OS CONTROLES
            {
                if (Controls[i] is Button button)//SE O CONTROLE FOR UM DA CLASSE BOTAO
                {
                    if (button.BackgroundImage == Properties.Resources.pecas_brancas)//SE O BOTAO TIVER COR PRETA
                    {
                        //MessageBox.Show("foi:" + button.Name);
                    }
                    else
                    {
                        // MessageBox.Show("nao foi: " + button.Name);
                    }
                }
            }
        }

        public void Zerar()
        {

            for (int i = 0; i < Controls.Count; i++)//VAI DE 0 ATE TODOS OS CONTROLES
            {
                if (Controls[i] is Button button)//SE O CONTROLE FOR UM DA CLASSE BOTAO
                {
                    button.Text = null;
                    button.Click += Botao_Click;
                }
            }
        }

        public void Botao_Click(object sender, EventArgs e)
        {
            // Identifica o botão que foi pressionado
            Button botao = (Button)sender;
            while (true)
            {
                if (label1.Text == "Vez das peças pretas")
                {
                    //PEÇAS PRETAS
                    for (int i = 0; i <= array.Length; i++)
                    {
                        while (array[i] != null)//OCUPADO
                        {
                            i++;
                        }
                        array[i] = botao;


                        break;

                    }
                    if (array[0] != null && array[1] != null)
                    {

                        if (array[0].BackgroundImageLayout == ImageLayout.Center)
                        {
                            MessageBox.Show("Rodada ao preto!, tente novamente");
                            for (int i = 0; i < array.Length; i++)
                            {
                                array[i] = null;
                            }
                        }
                        else
                        {
                            if (array[0].BackColor == Color.Black && array[1].BackColor == Color.Black)
                            {
                                if (array[1].BackgroundImageLayout == ImageLayout.Stretch || array[1].BackgroundImageLayout == ImageLayout.Center)
                                {
                                    MessageBox.Show("Esta casa ja esta ocupada, tente novamente");
                                    for (int i = 0; i < array.Length; i++)
                                    {
                                        array[i] = null;
                                    }
                                }
                                else
                                {
                                    if (array[0].TabIndex + 7 == array[1].TabIndex || array[0].TabIndex - 9 == array[1].TabIndex || array[0].TabIndex + 9 == array[1].TabIndex || array[0].TabIndex - 7 == array[1].TabIndex)
                                    {
                                        array[1].BackgroundImage = Properties.Resources.pecas_pretas;
                                        array[1].BackgroundImageLayout = ImageLayout.Stretch;
                                        array[0].BackgroundImage = null;
                                        array[0].BackgroundImageLayout = ImageLayout.Tile;

                                        for (int i = 0; i < array.Length; i++)
                                        {
                                            array[i] = null;

                                        }


                                        label1.Text = "Vez das peças brancas";


                                    }
                                    else
                                    {
                                        for (int i = 0; i < perdedor.Length; i++)
                                        {
                                            if (perdedor[i] != null)
                                            {
                                                label3.Text = perdedor[i].Name;
                                                break;
                                            }

                                        }
                                       // AtaquePreto();
                                     
                                        if (label3.Text == "PEÇA MORTA")
                                        {
                                            label3.Text = null;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Voce pulou varias casas preto, tente novamente");
                                            for (int i = 0; i < array.Length; i++)
                                            {
                                                array[i] = null;
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("Casa invalida, tente novamente");
                                for (int i = 0; i < array.Length; i++)
                                {
                                    array[i] = null;
                                }
                            }
                        }
                    }
                }

                //PEÇAS BRANCAS
                else if (label1.Text == "Vez das peças brancas")
                {
                    //MessageBox.Show("VEZZZ DO BARNCO PORRA");
                    for (int i = 0; i <= array.Length; i++)
                    {
                        while (array[i] != null)//OCUPADO
                        {
                            i++;
                        }
                        array[i] = botao;
                        break;
                    }
                    if (array[0] != null && array[1] != null)
                    {

                        if (array[0].BackgroundImageLayout == ImageLayout.Stretch)
                        {
                            MessageBox.Show("Rodada ao branco!, tente novamente");
                            for (int i = 0; i < array.Length; i++)
                            {
                                array[i] = null;
                            }
                        }
                        else
                        {
                            if (array[0].BackColor == Color.Black && array[1].BackColor == Color.Black)
                            {
                                if (array[1].BackgroundImageLayout == ImageLayout.Stretch)
                                {
                                    MessageBox.Show("Esta casa ja esta ocupada, tente novamente");
                                    for (int i = 0; i < array.Length; i++)
                                    {
                                        array[i] = null;
                                    }
                                }
                                else
                                {
                                    if (array[0].TabIndex + 7 == array[1].TabIndex || array[0].TabIndex - 9 == array[1].TabIndex || array[0].TabIndex + 9 == array[1].TabIndex || array[0].TabIndex - 7 == array[1].TabIndex)
                                    {
                                        if (array[0].TabIndex + 14 == array[1].TabIndex)//COMER
                                        {
                                            array[1].Image = Properties.Resources.pecas_brancas;
                                            array[1].BackgroundImageLayout = ImageLayout.Center;
                                            array[0].Image = null;
                                            array[0].BackgroundImageLayout = ImageLayout.Tile;

                                            for (int i = 0; i < array.Length; i++)
                                            {
                                                array[i] = null;

                                            }
                                        }
                                        else
                                        {
                                            array[1].Image = Properties.Resources.pecas_brancas;
                                            array[1].BackgroundImageLayout = ImageLayout.Center;
                                            array[0].Image = null;
                                            array[0].BackgroundImageLayout = ImageLayout.Tile;

                                            for (int i = 0; i < array.Length; i++)
                                            {
                                                array[i] = null;

                                            }
                                        }
                                        label1.Text = "Vez das peças pretas";


                                    }
                                    else
                                    {

                                        //AtaquePreto();
                                        if (label3.Text == "PEÇA MORTA")
                                        {
                                            label3.Text = null;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Voce pulou varias casas BRANCO, tente novamente");
                                            for (int i = 0; i < array.Length; i++)
                                            {
                                                array[i] = null;
                                            }
                                        }

                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("Casa invalida, tente novamente");
                                for (int i = 0; i < array.Length; i++)
                                {
                                    array[i] = null;
                                }
                            }
                        }




                    }

                }
                break;
            }
        }

        public void AtaquePreto()
        {
            int perdedor1 = array[0].TabIndex + 7;
            int perdedor3 = array[0].TabIndex - 9;
            int perdedor2 = array[0].TabIndex - 7;
            for (int i = 0; i < Controls.Count; i++)//VAI DE 0 ATE TODOS OS CONTROLES
            {
                if (Controls[i] is Button button && button.TabIndex == perdedor1)//SE O CONTROLE FOR UM DA CLASSE BOTAO
                {


                    Button botao = (Button)Controls[i];
                    string nomeBotao = botao.Name;

                    if (botao.BackgroundImageLayout == ImageLayout.Center)//CASO SEJA UMA PEÇA BRANCA
                    {
                        for (int j = 0; j <= perdedor.Length; j++)
                        {
                            while (perdedor[j] != null)//OCUPADO
                            {
                                j++;
                            }
                            perdedor[j] = botao;
                            perdedor[j].BackgroundImageLayout = ImageLayout.Tile;
                            perdedor[j].Image = null;
                            array[1].BackgroundImage = Properties.Resources.pecas_pretas;
                            array[1].BackgroundImageLayout = ImageLayout.Stretch;
                            array[0].BackgroundImage = null;
                            array[0].BackgroundImageLayout = ImageLayout.Tile;
                            label3.Text = "PEÇA MORTA";
                            break;
                        }
                    }
                    else if (botao.BackgroundImageLayout == ImageLayout.Stretch)
                    {
                        for (int j = 0; j <= perdedor.Length; j++)
                        {
                            while (perdedor[j] != null)//OCUPADO
                            {
                                j++;
                            }
                            perdedor[j] = botao;
                            perdedor[j].BackgroundImageLayout = ImageLayout.Tile;
                            perdedor[j].BackgroundImage = null;
                            array[1].Image = Properties.Resources.pecas_brancas;
                            array[1].BackgroundImageLayout = ImageLayout.Center;
                            array[0].Image = null;
                            array[0].BackgroundImageLayout = ImageLayout.Tile;
                            label3.Text = "PEÇA MORTA";
                            break;
                        }
                    }
                }
                else if (Controls[i] is Button button1 && button1.TabIndex == perdedor2)
                {
                    Button botao = (Button)Controls[i];
                    string nomeBotao = botao.Name;

                    if (botao.BackgroundImageLayout == ImageLayout.Stretch)//CASO SEJA UMA PEÇA PRETA
                    {
                        MessageBox.Show("OXII");
                        for (int j = 0; j <= perdedor.Length; j++)
                        {
                            while (perdedor[j] != null)//OCUPADO
                            {
                                j++;
                            }
                            perdedor[j] = botao;
                            perdedor[j].BackgroundImageLayout = ImageLayout.Tile;
                            perdedor[j].BackgroundImage = null;
                            array[1].Image = Properties.Resources.pecas_brancas;
                            array[1].BackgroundImageLayout = ImageLayout.Center;
                            array[0].Image = null;
                            array[0].BackgroundImageLayout = ImageLayout.Tile;
                            label3.Text = "PEÇA MORTA";
                            break;
                        }

                    }
                    else if (botao.BackgroundImageLayout == ImageLayout.Center)
                    {

                        for (int j = 0; j <= perdedor.Length; j++)
                        {
                            while (perdedor[j] != null)//OCUPADO
                            {
                                j++;
                            }
                            perdedor[j] = botao;
                            perdedor[j].BackgroundImageLayout = ImageLayout.Tile;
                            perdedor[j].Image = null;
                            array[1].BackgroundImage = Properties.Resources.pecas_pretas;
                            array[1].BackgroundImageLayout = ImageLayout.Stretch;
                            array[0].BackgroundImage = null;
                            array[0].BackgroundImageLayout = ImageLayout.Tile;
                            label3.Text = "PEÇA MORTA";
                            break;
                        }
                    }
                    break;
                }
                /*else if (Controls[i] is Button button2 && button2.TabIndex == perdedor3)//SE O CONTROLE FOR UM DA CLASSE BOTAO
                 {
                     Button botao = (Button)Controls[i];
                     string nomeBotao = botao.Name;

                     if (botao.BackgroundImageLayout == ImageLayout.Center)//CASO SEJA UMA PEÇA BRANCA
                     {
                         for (int j = 0; j <= perdedor.Length; j++)
                         {
                             while (perdedor[j] != null)//OCUPADO
                             {
                                 j++;
                             }
                             perdedor[j] = botao;
                             perdedor[j].BackgroundImageLayout = ImageLayout.Tile;
                             perdedor[j].Image = null;
                             array[1].BackgroundImage = Properties.Resources.pecas_pretas;
                             array[1].BackgroundImageLayout = ImageLayout.Stretch;
                             array[0].BackgroundImage = null;
                             array[0].BackgroundImageLayout = ImageLayout.Tile;
                             label3.Text = "PEÇA MORTA";
                             break;
                         }
                     }
                     break;
                 }*/

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
        }

        private void button12_Click(object sender, EventArgs e)
        {
        }

        private void button13_Click(object sender, EventArgs e)
        {
        }

        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void button15_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void button60_Click(object sender, EventArgs e)
        {

        }

        private void button51_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}