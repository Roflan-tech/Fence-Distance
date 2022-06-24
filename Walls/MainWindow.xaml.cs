using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Walls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        float shtahetnick = 0;
        float promeznost = 3.5f;
        float rastoyaniie = 0;

        float tmp = 0;
        float out1 = 100;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void rastoyaniie_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void shtahecnick_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            //rastoyaniie
            try
            {
                rastoyaniie = float.Parse(rastoyaniiedata.Text);
            }
            catch (Exception)
            {
                text.AppendText("Pls don't input a string in textboxes\n");
            }
            //shtahetnick
            try
            {
                shtahetnick = float.Parse(shtahecnickdata.Text);
            }
            catch (Exception)
            {
                text.AppendText("Pls don't input a string in textboxes\n");
            }

            for (float i = 4.5f; i >= promeznost;)
            {
                promeznost += 0.1f;
                //printf("shta: %f, promez: %f, rastoyan: %d\n", shtahetnick, promeznost, rastoyaniie);
                tmp = rastoyaniie / (promeznost + shtahetnick);
                //printf("tmp: %f", promeznost+shtahetnick);
                if (out1 > tmp && rastoyaniie >= (tmp * (shtahetnick + promeznost)) && promeznost < 4.5)
                {
                    //printf("rast: %d shtahet: %f promez: %f\n", rastoyaniie, shtahetnick, promeznost);
                    out1 = tmp;
                    //maintextfield.Text=$"Вывод: {out1}, расстоянние между штахетником: {promeznost}\n";
                    text.AppendText(String.Format("Solution: {0}, distance between picket fence: {1}\n", Math.Round(out1, 2, MidpointRounding.ToEven), Math.Round(promeznost, 2, MidpointRounding.ToEven)));
                }
            }
            text.AppendText("_______________________________________________________________________________\n");
            shtahetnick = 0;
            promeznost = 3.5f;
            rastoyaniie = 0;
            tmp = 0;
            out1 = 100;
        }
    }
}
