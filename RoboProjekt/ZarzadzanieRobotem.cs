using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace RoboProjekt
{
    class ZarzadzanieRobotem
    {
        private static string ip;
        private static int port;
        private double predkosc;
        private TcpClient tcpClient;
        private NetworkStream Strumien;
        private int zmiennaTrybu;
        private string zwrotBajtow = "ok";
        private string pozycjaX, pozycjaY, kat;
        private string daneZSerwera;
        private string pozycjaX1, pozycjaX2, pozycjaX3, pozycjaX4, pozycjaX5;
        private string pozycjaY1, pozycjaY2, pozycjaY3, pozycjaY4, pozycjaY5;
        private string kat1, kat2, kat3, kat4, kat5;
        private bool zajety = false, zajety2 = false, zajety3 = false,
            zajety4 = false, zajety5 = false;


       
        public string Ip
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        public double Predkosc
        {
            get
            {
                return predkosc;
            }
            set
            {
                predkosc = value;
            }
        }

        public int ZmiennaTrybu
        {
            get
            {
                return zmiennaTrybu;
            }
            set
            {
                zmiennaTrybu = value;
            }
        }

        public string ZwrotBajtow
        {
            get
            {
                return zwrotBajtow;
            }
            set
            {
                zwrotBajtow = value;
            }
        }

        public string PozycjaX
        {
            get
            {
                return pozycjaX;
            }
            set
            {
                pozycjaX = value;
            }
        }

        public string PozycjaY
        {
            get
            {
                return pozycjaY;
            }
            set
            {
                pozycjaY = value;
            }
        }

        public string Kat
        {
            get
            {
                return kat;
            }
            set
            {
                kat = value;
            }
        }

        public string DaneZSerwera
        {
            get
            {
                return daneZSerwera;
            }
            set
            {
                daneZSerwera = value;
            }
        }

        public string PozycjaX1
        {
            get
            {
                return pozycjaX1;
            }
            set
            {
                pozycjaX1 = value;
            }
        }

        public string PozycjaX2
        {
            get
            {
                return pozycjaX2;
            }
            set
            {
                pozycjaX2 = value;
            }
        }

        public string PozycjaX3
        {
            get
            {
                return pozycjaX3;
            }
            set
            {
                pozycjaX3 = value;
            }
        }

        public string PozycjaX4
        {
            get
            {
                return pozycjaX4;
            }

            set
            {
                pozycjaX4 = value;
            }
        }

        public string PozycjaX5
        {
            get
            {
                return pozycjaX5;
            }

            set
            {
                pozycjaX5 = value;
            }
        }

        public string PozycjaY1
        {
            get
            {
                return pozycjaY1;
            }

            set
            {
                pozycjaY1 = value;
            }
        }

        public string PozycjaY2
        {
            get
            {
                return pozycjaY2;
            }

            set
            {
                pozycjaY2 = value;
            }
        }

        public string PozycjaY3
        {
            get
            {
                return pozycjaY3;
            }

            set
            {
                pozycjaY3 = value;
            }
        }

        public string PozycjaY4
        {
            get
            {
                return pozycjaY4;
            }

            set
            {
                pozycjaY4 = value;
            }
        }

        public string PozycjaY5
        {
            get
            {
                return pozycjaY5;
            }

            set
            {
                pozycjaY5 = value;
            }
        }

        public string Kat1
        {
            get
            {
                return kat1;
            }

            set
            {
                kat1 = value;
            }
        }

        public string Kat2
        {
            get
            {
                return kat2;
            }

            set
            {
                kat2 = value;
            }
        }

        public string Kat3
        {
            get
            {
                return kat3;
            }

            set
            {
                kat3 = value;
            }
        }

        public string Kat4
        {
            get
            {
                return kat4;
            }

            set
            {
                kat4 = value;
            }
        }

        public string Kat5
        {
            get
            {
                return kat5;
            }

            set
            {
                kat5 = value;
            }
        }

        public bool Zajety
        {
            get
            {
                return zajety;
            }

            set
            {
                zajety = value;
            }
        }

        public bool Zajety2
        {
            get
            {
                return zajety2;
            }

            set
            {
                zajety2 = value;
            }
        }

        public bool Zajety3
        {
            get
            {
                return zajety3;
            }

            set
            {
                zajety3 = value;
            }
        }

        public bool Zajety4
        {
            get
            {
                return zajety4;
            }

            set
            {
                zajety4 = value;
            }
        }

        public bool Zajety5
        {
            get
            {
                return zajety5;
            }

            set
            {
                zajety5 = value;
            }
        }

        public ZarzadzanieRobotem(string ip, int port)
        {

            this.Ip = ip;
            this.Port = port;
            tcpClient = new TcpClient();

        }

        public void Polacz()
        {

            tcpClient = new TcpClient();
            tcpClient.Connect(ip, port);
            tcpClient.NoDelay = true;
        }

        public void SprawdzeniePolaczenia()
        {
            if (zmiennaTrybu == 2)
            {
                Strumien = tcpClient.GetStream();   //połączenie w trybie monitorowania
                byte[] bufor_tryb = new byte[3];
                bufor_tryb[0] = 1;
                bufor_tryb[1] = 2;
                bufor_tryb[2] = 0;

                Strumien.Write(bufor_tryb, 0, bufor_tryb.Length);

                if (Strumien.ReadByte() == 2)
                {
                    if (Strumien.ReadByte() == 17)
                    {
                        Strumien.ReadByte();

                    }
                }
                else
                {
                    zwrotBajtow = "Read byte problem";
                }
            }
            if (zmiennaTrybu == 0)
            {
                //tcpClient = new TcpClient("192.168.2.102", 50131);
                tcpClient.NoDelay = true;
                Strumien = tcpClient.GetStream();   //połączenie z jednym robotem w trybie sterowania
                byte[] bufor_tryb = new byte[3];
                bufor_tryb[0] = 1;
                bufor_tryb[1] = 0;
                bufor_tryb[2] = 1;

                Strumien.Write(bufor_tryb, 0, bufor_tryb.Length);

                if (Strumien.ReadByte() == 2)
                {
                    if (Strumien.ReadByte() == 33)
                    {
                        Strumien.ReadByte();
                    }
                }
                else
                {
                    zwrotBajtow = "Read byte problem";
                }
            }
        }


        public void Rozlacz()
        {
            Strumien = tcpClient.GetStream();
            byte[] bufor_rozlacz = new byte[1];
            bufor_rozlacz[0] = 0;
            Strumien.Write(bufor_rozlacz, 0, 1);
            tcpClient.Close();
        }
        public Boolean CzyPolaczony()
        {
            return tcpClient.Connected;
        }
        public void TrybMonitor()
        {
            if (zmiennaTrybu == 2)
            {
                Rozlacz(); 
                Polacz();
                Strumien = tcpClient.GetStream();   //połączenie w trybie monitorowania
                byte[] bufor_tryb = new byte[3];
                bufor_tryb[0] = 1;
                bufor_tryb[1] = 2;
                bufor_tryb[2] = 0;

                Strumien.Write(bufor_tryb, 0, bufor_tryb.Length);
                if (Strumien.ReadByte() == 2)
                {
                    if (Strumien.ReadByte() == 17)
                    {
                        //Strumien.ReadByte();
                        //Strumien.Flush();

                    }
                }

                // wyslanie zapytania o wspolrzedne
                byte[] bufor_odczyt = new byte[140]; 
                Strumien.WriteByte(3);
                if (Strumien.ReadByte() == 4) 
                {
                    Strumien.Read(bufor_odczyt, 0, 14 * 5);
                }

                zajety = BitConverter.ToBoolean(bufor_odczyt, 1);
                //dekodowanie danych
                //Robot 1
                pozycjaX1 = BitConverter.ToSingle(bufor_odczyt, 2).ToString();
                pozycjaY1 = BitConverter.ToSingle(bufor_odczyt, 6).ToString();
                kat1 = BitConverter.ToSingle(bufor_odczyt, 10).ToString();

                //Robot 2 
                pozycjaX2 = BitConverter.ToSingle(bufor_odczyt, 2 + 14).ToString();
                pozycjaY2 = BitConverter.ToSingle(bufor_odczyt, 6 + 14).ToString();
                kat2 = BitConverter.ToSingle(bufor_odczyt, 10 + 14).ToString();
                zajety2 = BitConverter.ToBoolean(bufor_odczyt, 1 + 14);

                //Robot 3
                pozycjaX3 = BitConverter.ToSingle(bufor_odczyt, 2 + 14 * 2).ToString();
                pozycjaY3 = BitConverter.ToSingle(bufor_odczyt, 6 + 14 * 2).ToString();
                kat3 = BitConverter.ToSingle(bufor_odczyt, 10 + 14 * 2).ToString();
                zajety3 = BitConverter.ToBoolean(bufor_odczyt, 1 + 14 * 2);

                //Robot 4
                pozycjaX4 = BitConverter.ToSingle(bufor_odczyt, 2 + 14 * 3).ToString();
                pozycjaY4 = BitConverter.ToSingle(bufor_odczyt, 6 + 14 * 3).ToString();
                kat4 = BitConverter.ToSingle(bufor_odczyt, 10 + 14 * 3).ToString();
                zajety4 = BitConverter.ToBoolean(bufor_odczyt, 1 + 14 * 3);

                //Robot 5
                pozycjaX5 = BitConverter.ToSingle(bufor_odczyt, 2 + 14 * 4).ToString();
                pozycjaY5 = BitConverter.ToSingle(bufor_odczyt, 6 + 14 * 4).ToString();
                kat5 = BitConverter.ToSingle(bufor_odczyt, 10 + 14 * 4).ToString();
                zajety5 = BitConverter.ToBoolean(bufor_odczyt, 1 + 14 * 4);
            }
        }
        public void TrybSterowanie1()
        {
            if (zmiennaTrybu == 0)
            {
                Rozlacz();
                Polacz();
                Strumien = tcpClient.GetStream();   //połączenie z jednym robotem w trybie sterowania
                byte[] bufer1 = new byte[3];
                bufer1[0] = 1;
                bufer1[1] = 0;
                bufer1[2] = 1;

                Strumien.Write(bufer1, 0, 3);
                if (Strumien.ReadByte() == 2)
                {
                    if (Strumien.ReadByte() == 33)
                    {
                        Strumien.ReadByte();

                    }
                }
                byte[] bufor_odczyt = new byte[14];  
                Strumien.WriteByte(3);
                if (Strumien.ReadByte() == 4) 
                {
                    Strumien.Read(bufor_odczyt, 0, 14);
                }

                pozycjaX = BitConverter.ToSingle(bufor_odczyt, 2).ToString(); 
                daneZSerwera = pozycjaX + ",";

                pozycjaY = BitConverter.ToSingle(bufor_odczyt, 6).ToString();
                daneZSerwera += pozycjaY + ",";

                kat = BitConverter.ToSingle(bufor_odczyt, 10).ToString();
                daneZSerwera += kat;

                zajety = BitConverter.ToBoolean(bufor_odczyt, 1);
            }
        }

        public void JedzDoPrzodu()
        {
            byte[] bufor_jedz = new byte[9];
            byte[] ramka1 = new byte[4];
            byte[] ramka2 = new byte[4];

            float a = 30, b = 30;

            ramka1 = BitConverter.GetBytes(a);
            ramka2 = BitConverter.GetBytes(b);

            bufor_jedz[0] = 5;

            ramka1.CopyTo(bufor_jedz, 1);
            ramka2.CopyTo(bufor_jedz, 5);

            Strumien.Write(bufor_jedz, 0, bufor_jedz.Length);
            Strumien.Flush();

            Thread.Sleep(100);
            if (Strumien.ReadByte() == 6) 
            {
                //Strumien.ReadByte();
                Thread.Sleep(100);
            }
            else
            {
                zwrotBajtow = "Read byte problem";
            }
            Strumien.Flush();

        }

        public void JedzDoTylu()
        {
            TrybSterowanie1();
            Strumien = tcpClient.GetStream();   //połączenie z jednym robotem w trybie sterowania
            byte[] bufor_jedz = new byte[9];

            byte[] ramka1 = new byte[4];
            byte[] ramka2 = new byte[4];

            float a = -30, b = -30;

            ramka1 = BitConverter.GetBytes(a);
            ramka2 = BitConverter.GetBytes(b);

            bufor_jedz[0] = 5;

            ramka1.CopyTo(bufor_jedz, 1);
            ramka2.CopyTo(bufor_jedz, 5);

            Strumien.Write(bufor_jedz, 0, bufor_jedz.Length);
            Strumien.Flush();

            Thread.Sleep(100);

            if (Strumien.ReadByte() == 6) 
            {
                //Strumien.ReadByte();
                Thread.Sleep(100);
            }
            else
            {
                zwrotBajtow = "Read byte problem";
            }
            Strumien.Flush();
        }

        public void JedzWPrawo()
        {
            Strumien = tcpClient.GetStream();   //połączenie z jednym robotem w trybie sterowania
            byte[] bufor_jedz = new byte[9];

            byte[] ramka1 = new byte[4];
            byte[] ramka2 = new byte[4];

            float a = 30, b = 0;

            ramka1 = BitConverter.GetBytes(a);
            ramka2 = BitConverter.GetBytes(b);

            bufor_jedz[0] = 5;

            ramka1.CopyTo(bufor_jedz, 1);
            ramka2.CopyTo(bufor_jedz, 5);

            Strumien.Write(bufor_jedz, 0, bufor_jedz.Length);
            Strumien.Flush();

            Thread.Sleep(100);

            if (Strumien.ReadByte() == 6) 
            {
                //Strumien.ReadByte();
                Thread.Sleep(100);
            }
            else
            {
                zwrotBajtow = "Read byte problem";
            }
            Strumien.Flush();

        }

        public void JedzWLewo()
        {
            Strumien = tcpClient.GetStream();   //połączenie z jednym robotem w trybie sterowania
            byte[] bufor_jedz = new byte[9];

            byte[] ramka1 = new byte[4];
            byte[] ramka2 = new byte[4];

            float a = 0, b = 30;

            ramka1 = BitConverter.GetBytes(a);
            ramka2 = BitConverter.GetBytes(b);

            bufor_jedz[0] = 5;

            ramka1.CopyTo(bufor_jedz, 1);
            ramka2.CopyTo(bufor_jedz, 5);

            Strumien.Write(bufor_jedz, 0, bufor_jedz.Length);
            //Strumien.Flush();

            Thread.Sleep(100);

            if (Strumien.ReadByte() == 6) 
            {
                //Strumien.ReadByte();
                Thread.Sleep(100);
                //Strumien.Flush();
            }
            else
            {
                zwrotBajtow = "Read byte problem";
            }
            //Strumien.Flush();
            //Rozlacz();

        }

        public void Hamuj()
        {

            Strumien = tcpClient.GetStream();   //połączenie z jednym robotem w trybie sterowania
            byte[] bufor_jedz = new byte[9];

            byte[] ramka1 = new byte[4];
            byte[] ramka2 = new byte[4];

            float a = 0, b = 0;

            ramka1 = BitConverter.GetBytes(a);
            ramka2 = BitConverter.GetBytes(b);

            bufor_jedz[0] = 5;

            ramka1.CopyTo(bufor_jedz, 1);
            ramka2.CopyTo(bufor_jedz, 5);

            Strumien.Write(bufor_jedz, 0, bufor_jedz.Length);
            //Strumien.Flush();

            Thread.Sleep(100);

            if (Strumien.ReadByte() == 6) 
            {
                //Strumien.ReadByte();
                Thread.Sleep(100);
                //Strumien.Flush();
            }
            else
            {
                zwrotBajtow = "Read byte problem";
            }
            //Strumien.Flush();
            //Rozlacz();
        }
    }
}
