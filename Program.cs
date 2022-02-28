using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;

namespace Sniffer
{
    class NetworkSniffer
    {
        static void Main(){
            
            int a = 0;
            //Deneme amaçlı çalıştırırken, 50 bağlantı sonrası döngü bitsin diye limit koydum. 
            //Normal çalışmada while(true) olacak
            while(a < 50){
                baglantilar();
                a++;
            }
            
        }

        public static void baglantilar(){

            var ipstats = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnections = ipstats.GetActiveTcpConnections();

            String a, b, c, d;
            foreach(var connection in tcpConnections){

                Console.WriteLine("Yerel Ağ: ");
                Console.WriteLine($"Bağlı olunan adres: {connection.LocalEndPoint.Address.ToString()}");
                Console.WriteLine($"Bağlı olunan port: {connection.LocalEndPoint.Port}");
                Console.WriteLine("Uzak Ağ: ");
                Console.WriteLine($"Bağlı olunan adres: {connection.RemoteEndPoint.Address.ToString()}");
                Console.WriteLine($"Bağlı olunan port: {connection.RemoteEndPoint.Port}");
                Console.WriteLine($"Bağlantı Durumu: {connection.State.ToString()}");

                a = connection.LocalEndPoint.Address.ToString();
                b = connection.LocalEndPoint.Port.ToString();
                c = connection.RemoteEndPoint.Address.ToString();
                d = connection.RemoteEndPoint.Port.ToString();
                File.AppendAllText(@"baglanti.txt","Yerel Ağ: "+ a +":"+ b + ", Uzak Ağ: "+ c +":" + d + ", Tarih: " + DateTime.Now +"\r\n");

 
            }

        }
        
    }
}

