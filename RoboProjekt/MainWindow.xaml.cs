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
using WPFCustomMessageBox;

namespace RoboProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string IP = "192.168.2.100";
        private const int PORT = 50131;

        private ZarzadzanieRobotem zarzadzanieRobotem;
 
        public MainWindow()
        {
            InitializeComponent();
            zarzadzanieRobotem = new ZarzadzanieRobotem(IP, PORT);
            textBox1_IP.Text = IP;
            textBox1_Port.Text = PORT.ToString();
            
            button_Przod.IsEnabled = false;
            button_Tyl.IsEnabled = false;
            button_Lewo.IsEnabled = false;
            button_Prawo.IsEnabled = false;
            button_Hamulec.IsEnabled = false;
            
            if (!zarzadzanieRobotem.CzyPolaczony())
            {
                button_Rozlacz.IsEnabled = false;
            }
            else button_Rozlacz.IsEnabled = true;
        }

        private void textBox1_IP_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_Port_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Polacz_Click(object sender, RoutedEventArgs e)
        {
            zarzadzanieRobotem.Ip = textBox1_IP.Text;
            zarzadzanieRobotem.Port = int.Parse(textBox1_Port.Text);
                          
            try
            {
                zarzadzanieRobotem.Polacz();
                MessageBoxResult rezultat=CustomMessageBox.ShowYesNo("Wybierz tryb","Wybór trybu",
                    "Tryb monitorowania", "Tryb sterowania", MessageBoxImage.Asterisk);

                switch (rezultat)
                {
                    case MessageBoxResult.Yes:
                        MessageBox.Show("Wybrany tryb: Monitor");
                        zarzadzanieRobotem.ZmiennaTrybu = 2;
                        checkBox_TrybMonitora.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                        checkBox_TrybKontroli.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                                               
                        RamkaKontrola.Visibility = Visibility.Visible;

                        zarzadzanieRobotem.TrybMonitor();
                        textBox_30_X.Text = zarzadzanieRobotem.PozycjaX1;
                        textBox_30_Y.Text = zarzadzanieRobotem.PozycjaY1;
                        textBox_30_Kat.Text = zarzadzanieRobotem.Kat1;
                        textBox_30_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety);

                        textBox_31_X.Text = zarzadzanieRobotem.PozycjaX2;
                        textBox_31_Y.Text = zarzadzanieRobotem.PozycjaY2;
                        textBox_31_Kat.Text = zarzadzanieRobotem.Kat2;
                        textBox_31_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety2);

                        textBox_32_X.Text = zarzadzanieRobotem.PozycjaX3;
                        textBox_32_Y.Text = zarzadzanieRobotem.PozycjaY3;
                        textBox_32_Kat.Text = zarzadzanieRobotem.Kat3;
                        textBox_32_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety3);

                        textBox_33_X.Text = zarzadzanieRobotem.PozycjaX4;
                        textBox_33_Y.Text = zarzadzanieRobotem.PozycjaY4;
                        textBox_33_Kat.Text = zarzadzanieRobotem.Kat4;
                        textBox_33_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety4);

                        textBox_34_X.Text = zarzadzanieRobotem.PozycjaX5;
                        textBox_34_Y.Text = zarzadzanieRobotem.PozycjaY5;
                        textBox_34_Kat.Text = zarzadzanieRobotem.Kat5;
                        textBox_34_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety5);

                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show("Wybrany tryb: Kontrola. Aby sterować robotem naciśnij przycisk Steruj.");
                        zarzadzanieRobotem.ZmiennaTrybu = 0;
                        checkBox_TrybKontroli.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                        checkBox_TrybMonitora.SetCurrentValue(CheckBox.IsCheckedProperty, false);

                        textBox_30_X.Text = "";
                        textBox_30_Y.Text = "";
                        textBox_30_Kat.Text = "";
                        textBox_30_Zajety.Text = "";

                        textBox_31_X.Text = "";
                        textBox_31_Y.Text = "";
                        textBox_31_Kat.Text = "";
                        textBox_31_Zajety.Text = "";

                        textBox_32_X.Text = "";
                        textBox_32_Y.Text = "";
                        textBox_32_Kat.Text = "";
                        textBox_32_Zajety.Text = "";

                        textBox_33_X.Text = "";
                        textBox_33_Y.Text = "";
                        textBox_33_Kat.Text = "";
                        textBox_33_Zajety.Text = "";

                        textBox_34_X.Text = "";
                        textBox_34_Y.Text = "";
                        textBox_34_Kat.Text = "";
                        textBox_34_Zajety.Text = "";

                        RamkaKontrola.Visibility = Visibility.Hidden;
                        
                        zarzadzanieRobotem.TrybSterowanie1();
                        break;
                }
               /* try
                {
                    zarzadzanieRobotem.SprawdzeniePolaczenia();
                    MessageBox.Show(zarzadzanieRobotem.ZwrotBajtow);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Błąd wyboru trybu");
                }
                */
                
                button_Rozlacz.IsEnabled = true;
                button_Polacz.IsEnabled = false;
            }
            catch (System.Net.Sockets.SocketException)
            {             
                MessageBox.Show("Bład połączenia");
            }
        }

        private void button_Rozlacz_Click(object sender, RoutedEventArgs e)
        {
            zarzadzanieRobotem.Rozlacz();
            button_Rozlacz.IsEnabled = false;
            button_Polacz.IsEnabled = true;
            checkBox_TrybMonitora.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            checkBox_TrybKontroli.SetCurrentValue(CheckBox.IsCheckedProperty, false);
            RamkaKontrola.Visibility = Visibility.Visible;

            textBox_30_X.Text = "";
            textBox_30_Y.Text = "";
            textBox_30_Kat.Text = "";
            textBox_30_Zajety.Text = "";

            textBox_31_X.Text = "";
            textBox_31_Y.Text = "";
            textBox_31_Kat.Text = "";
            textBox_31_Zajety.Text = "";

            textBox_32_X.Text = "";
            textBox_32_Y.Text = "";
            textBox_32_Kat.Text = "";
            textBox_32_Zajety.Text = "";

            textBox_33_X.Text = "";
            textBox_33_Y.Text = "";
            textBox_33_Kat.Text = "";
            textBox_33_Zajety.Text = "";

            textBox_34_X.Text = "";
            textBox_34_Y.Text = "";
            textBox_34_Kat.Text = "";
            textBox_34_Zajety.Text = "";

            SolidColorBrush kolor_czerwony = new SolidColorBrush();
            kolor_czerwony.Color = Color.FromArgb(255, 129, 0, 0);
            Lamp_30.Fill = kolor_czerwony;
            
            button_Przod.IsEnabled = false;
            button_Tyl.IsEnabled = false;
            button_Lewo.IsEnabled = false;
            button_Prawo.IsEnabled = false;
            button_Hamulec.IsEnabled = false;           
        }

        private void textBox_30_X_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_30_Y_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_30_Kat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_30_Zajety_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_31_X_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_31_Y_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_31_Kat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_31_Zajety_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_32_X_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_32_Y_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_32_Kat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_32_Zajety_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_33_X_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_33_Y_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_33_Kat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_33_Zajety_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_34_X_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_34_Y_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_34_Kat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_34_Zajety_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Steruj_30_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush kolor_zielony = new SolidColorBrush();
            kolor_zielony.Color = Color.FromArgb(255, 46, 135, 20);

            if (zarzadzanieRobotem.ZmiennaTrybu != 0)
            {
                MessageBoxResult rezultat = CustomMessageBox.ShowYesNo("Czy chcesz przejść do trybu kontroli, aby sterować robotem?",
                    "", "Tak", "Nie");

                switch (rezultat)
                {
                    case MessageBoxResult.Yes:
                        MessageBox.Show("Wybrany tryb: Kontrola");
                        zarzadzanieRobotem.ZmiennaTrybu = 0;
                        checkBox_TrybMonitora.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                        checkBox_TrybKontroli.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                        RamkaKontrola.Visibility = Visibility.Hidden;
                                                
                        Lamp_30.Fill = kolor_zielony;

                        button_Przod.IsEnabled = true;
                        button_Tyl.IsEnabled = true;
                        button_Lewo.IsEnabled = true;
                        button_Prawo.IsEnabled = true;
                        button_Hamulec.IsEnabled = true;

                        textBox_30_X.Text = "";
                        textBox_30_Y.Text = "";
                        textBox_30_Kat.Text = "";
                        textBox_30_Zajety.Text = "";

                        textBox_31_X.Text = "";
                        textBox_31_Y.Text = "";
                        textBox_31_Kat.Text = "";
                        textBox_31_Zajety.Text = "";

                        textBox_32_X.Text = "";
                        textBox_32_Y.Text = "";
                        textBox_32_Kat.Text = "";
                        textBox_32_Zajety.Text = "";

                        textBox_33_X.Text = "";
                        textBox_33_Y.Text = "";
                        textBox_33_Kat.Text = "";
                        textBox_33_Zajety.Text = "";

                        textBox_34_X.Text = "";
                        textBox_34_Y.Text = "";
                        textBox_34_Kat.Text = "";
                        textBox_34_Zajety.Text = "";

                        zarzadzanieRobotem.TrybSterowanie1();
                        textBox_30_X.Text = zarzadzanieRobotem.PozycjaX;
                        textBox_30_Y.Text = zarzadzanieRobotem.PozycjaY;
                        textBox_30_Kat.Text = zarzadzanieRobotem.Kat;
                        textBox_30_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety);

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else
            {
                Lamp_30.Fill = kolor_zielony;
                button_Przod.IsEnabled = true;
                button_Tyl.IsEnabled = true;
                button_Lewo.IsEnabled = true;
                button_Prawo.IsEnabled = true;
                button_Hamulec.IsEnabled = true;

                textBox_30_X.Text = "";
                textBox_30_Y.Text = "";
                textBox_30_Kat.Text = "";
                textBox_30_Zajety.Text = "";

                textBox_31_X.Text = "";
                textBox_31_Y.Text = "";
                textBox_31_Kat.Text = "";
                textBox_31_Zajety.Text = "";

                textBox_32_X.Text = "";
                textBox_32_Y.Text = "";
                textBox_32_Kat.Text = "";
                textBox_32_Zajety.Text = "";

                textBox_33_X.Text = "";
                textBox_33_Y.Text = "";
                textBox_33_Kat.Text = "";
                textBox_33_Zajety.Text = "";

                textBox_34_X.Text = "";
                textBox_34_Y.Text = "";
                textBox_34_Kat.Text = "";
                textBox_34_Zajety.Text = "";


                zarzadzanieRobotem.TrybSterowanie1();
                textBox_30_X.Text = zarzadzanieRobotem.PozycjaX;
                textBox_30_Y.Text = zarzadzanieRobotem.PozycjaY;
                textBox_30_Kat.Text = zarzadzanieRobotem.Kat;
                textBox_30_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety);
            }           
        }

        private void button_Przod_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(zarzadzanieRobotem.ZwrotBajtow);
            zarzadzanieRobotem.JedzDoPrzodu();
        }

        private void button_Tyl_Click(object sender, RoutedEventArgs e)
        {
            zarzadzanieRobotem.JedzDoTylu();
        }

        private void button_Lewo_Click(object sender, RoutedEventArgs e)
        {
            zarzadzanieRobotem.JedzWLewo();
        }

        private void button_Prawo_Click(object sender, RoutedEventArgs e)
        {
            zarzadzanieRobotem.JedzWPrawo();
        }

        private void button_Hamulec_Click(object sender, RoutedEventArgs e)
        {
            zarzadzanieRobotem.Hamuj();
        }

        
        private void button_ZmianaTrybu_Click(object sender, RoutedEventArgs e)
        {
            if (zarzadzanieRobotem.CzyPolaczony())
            {
                MessageBoxResult rezultat = CustomMessageBox.ShowYesNo("Wybierz tryb", "Wybór trybu",
                        "Tryb monitorowania", "Tryb sterowania", MessageBoxImage.Asterisk);
                switch (rezultat)
                {
                    case MessageBoxResult.Yes:
                        MessageBox.Show("Wybrany tryb: Monitor.");
                        checkBox_TrybMonitora.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                        checkBox_TrybKontroli.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                        zarzadzanieRobotem.ZmiennaTrybu = 2;

                        SolidColorBrush kolor_czerwony = new SolidColorBrush();
                        kolor_czerwony.Color = Color.FromArgb(255, 129, 0, 0);
                        Lamp_30.Fill = kolor_czerwony;
                        
                        button_Przod.IsEnabled = false;
                        button_Tyl.IsEnabled = false;
                        button_Lewo.IsEnabled = false;
                        button_Prawo.IsEnabled = false;
                        button_Hamulec.IsEnabled = false;
                        
                        RamkaKontrola.Visibility = Visibility.Visible;

                        zarzadzanieRobotem.TrybMonitor();
                        textBox_30_X.Text = zarzadzanieRobotem.PozycjaX1;
                        textBox_30_Y.Text = zarzadzanieRobotem.PozycjaY1;
                        textBox_30_Kat.Text = zarzadzanieRobotem.Kat1;
                        textBox_30_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety);

                        textBox_31_X.Text = zarzadzanieRobotem.PozycjaX2;
                        textBox_31_Y.Text = zarzadzanieRobotem.PozycjaY2;
                        textBox_31_Kat.Text = zarzadzanieRobotem.Kat2;
                        textBox_31_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety2);

                        textBox_32_X.Text = zarzadzanieRobotem.PozycjaX3;
                        textBox_32_Y.Text = zarzadzanieRobotem.PozycjaY3;
                        textBox_32_Kat.Text = zarzadzanieRobotem.Kat3;
                        textBox_32_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety3);

                        textBox_33_X.Text = zarzadzanieRobotem.PozycjaX4;
                        textBox_33_Y.Text = zarzadzanieRobotem.PozycjaY4;
                        textBox_33_Kat.Text = zarzadzanieRobotem.Kat4;
                        textBox_33_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety4);

                        textBox_34_X.Text = zarzadzanieRobotem.PozycjaX5;
                        textBox_34_Y.Text = zarzadzanieRobotem.PozycjaY5;
                        textBox_34_Kat.Text = zarzadzanieRobotem.Kat5;
                        textBox_34_Zajety.Text = Convert.ToString(zarzadzanieRobotem.Zajety5);

                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show("Wybrany tryb: Kontrola. Aby sterować robotem naciśnij przycisk Steruj.");
                        checkBox_TrybKontroli.SetCurrentValue(CheckBox.IsCheckedProperty, true);
                        checkBox_TrybMonitora.SetCurrentValue(CheckBox.IsCheckedProperty, false);
                        zarzadzanieRobotem.ZmiennaTrybu = 0;
                        RamkaKontrola.Visibility = Visibility.Hidden;

                        textBox_30_X.Text = "";
                        textBox_30_Y.Text = "";
                        textBox_30_Kat.Text = "";
                        textBox_30_Zajety.Text = "";

                        textBox_31_X.Text = "";
                        textBox_31_Y.Text = "";
                        textBox_31_Kat.Text = "";
                        textBox_31_Zajety.Text = "";

                        textBox_32_X.Text = "";
                        textBox_32_Y.Text = "";
                        textBox_32_Kat.Text = "";
                        textBox_32_Zajety.Text = "";

                        textBox_33_X.Text = "";
                        textBox_33_Y.Text = "";
                        textBox_33_Kat.Text = "";
                        textBox_33_Zajety.Text = "";

                        textBox_34_X.Text = "";
                        textBox_34_Y.Text = "";
                        textBox_34_Kat.Text = "";
                        textBox_34_Zajety.Text = "";

                        zarzadzanieRobotem.TrybSterowanie1();
                        
                        break;
                }
            }else
            {
                MessageBox.Show("Brak połączenia z serwerem");
            }
        }

        private void checkBox_TrybMonitora_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_TrybKontroli_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
