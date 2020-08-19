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

namespace AnalizadorLexico
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GenerarTokens(texto.Text);
        }
        
        public void GenerarTokens(String oracion)
        {
            char delimitador = ' ';
            int num = 0;
            double num2 = 0.00;
            int o = 0;
            String[] d = new String[2];
            String[] palabras = oracion.Split(delimitador);
            
          /*  for (int i = 0; i < palabras.Length; i++)
            {
            System.Console.WriteLine(">>>"+palabras[i]);

            }*/

            for (int i = 0; i < palabras.Length; i++)
            {
                if (int.TryParse(palabras[i], out num))
                {
                    System.Console.WriteLine(palabras[i] + " Es un digito");
                }
                else if(double.TryParse(palabras[i], out num2))
                 {
                    System.Console.WriteLine(palabras[i] + " Es un double");
                }
                d[0] = "";
                d[1] = "";
                foreach (char caracter in palabras[i])
                {

                    //System.Console.WriteLine(caracter);
                    //System.Console.WriteLine(">>>"+caracter.Equals('Q'));

                    if ((Char.IsLetter(caracter))&&(!caracter.Equals('Q')))
                    {
                        System.Console.WriteLine(palabras[i]+" Es una palabra");
                        break;
                    }else if(caracter.Equals('Q'))
                    {
                        d[0] = "Q";
                    }else if (caracter.Equals('.'))
                    {
                        if (d[0].Equals("Q"))
                        {
                            d[1] = ".";
                        }
                    }else if (Char.IsDigit(caracter))
                    {
                        if (d[0].Equals("Q") && d[1].Equals("."))
                        {
                            System.Console.WriteLine(palabras[i] + " Es dinero");
                        }
                    }

                }
            }
            
        }
    }
}
