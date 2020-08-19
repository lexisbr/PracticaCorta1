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
            //creando tabla
            cargarTabla();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //se envia cadena de texto al metodo
            GenerarTokens(texto.Text);
        }
        
        public void GenerarTokens(String oracion)
        {
            
            char separador = ' ';
            int num = 0;
            double num2 = 0.00;
            int o = 0;
            String[] d = new String[2];
            //Se separan las palabras con la variable separador y se guardan en array 
            String[] palabras = oracion.Split(separador);
       
            // ciclo for que recorre palabras
            for (int i = 0; i < palabras.Length; i++)
            {
                //compara si la palabra puede ser convertida a int y devuelve un valor booleano
                if (int.TryParse(palabras[i], out num))
                {
                    // si es verdadero significa que es un numero 
                    System.Console.WriteLine(palabras[i] + " Es un digito");
                    ///se agregan items con la clase agregaritem
                    lv_tokens.Items.Add(new AgregarItem { Tokens = palabras[i], Tipo = "Digito" });
                }
                //compara si la palabra puede ser convertida a double y devuelve un valor booleano
                else if (double.TryParse(palabras[i], out num2))
                {
                    // si es verdadero significa que es un decimal 
                    System.Console.WriteLine(palabras[i] + " Es un double");
                    ///se agregan items con la clase agregaritem
                    lv_tokens.Items.Add(new AgregarItem { Tokens = palabras[i], Tipo = "Decimal" });
                }
                else
                {
                    d[0] = "";
                    d[1] = "";
                    //Foreach que recorre caracter por caracter de cada palabra
                    foreach (char caracter in palabras[i])
                    {
                        //Se el primer caracter es una letra y es diferente de Q no importa que venga sera una palabra
                        if ((Char.IsLetter(caracter)) && (!caracter.Equals('Q')))
                        {
                            System.Console.WriteLine(palabras[i] + " Es una palabra");
                            ///se agregan items con la clase agregaritem
                            lv_tokens.Items.Add(new AgregarItem { Tokens = palabras[i], Tipo = "Palabra" });
                            break;
                        }
                        //Si es igual a Q es posible que venga una moneda entonces lo guardamos en array 
                        if (caracter.Equals('Q'))
                        {
                            d[0] = "Q";
                        }
                        if (caracter.Equals('.'))
                        {
                            //Si el caracter es igual a . comparamos si en el array teniamos guardado una Q
                            if (d[0].Equals("Q"))
                            {
                                //Si es cierto guardamos el punto en el mismo array para despues comparar si viene un numero
                                d[1] = ".";
                            }
                        }
                       
                        else if (Char.IsDigit(caracter))
                        {
                            // Se viniera un numero comparamos si en el array tenemos guardado una Q o un .
                            if (d[0].Equals("Q") || d[1].Equals("."))
                            {
                                //Si es cierto es moneda
                                System.Console.WriteLine(palabras[i] + " Es dinero");
                                ///se agregan items con la clase agregaritem
                                lv_tokens.Items.Add(new AgregarItem { Tokens = palabras[i], Tipo = "Moneda" });
                                break;
                            }
                            else
                            {
                                //Sino es palabra
                                ///se agregan items con la clase agregaritem
                                lv_tokens.Items.Add(new AgregarItem { Tokens = palabras[i], Tipo = "Palabra" });
                                break;
                            }
                       

                        }


                    }
                }
            }
            
        }
        public void cargarTabla()
        {
            // Se crea gridview para agregarlo a listview
            var gridView = new GridView();
            lv_tokens.View = gridView;
            // se agregan colmnas
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Tokens",
                DisplayMemberBinding = new Binding("Tokens"),
                Width = 200

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Tipo",
                DisplayMemberBinding = new Binding("Tipo"),
                Width = 200
            });
        }
        public class AgregarItem
        {
            //Se usa clase MyItem para agregar valor a filas
            public string Tokens { get; set; }
            public string Tipo { get; set; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Limpiar
            lv_tokens.Items.Clear();
            cargarTabla();



        }
    }

    
}
