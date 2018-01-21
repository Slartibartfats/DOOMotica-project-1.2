using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text;
public partial class _Default : System.Web.UI.Page
{
    string IP = "127.0.0.1";
    Int32 port = 11000;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Connect_Click(object sender, EventArgs e)
    {
        
    }
    
    
    private void SendMessage(string message)
    {
        try
        {

            String responseData = String.Empty;
            Int32 port = 11000;
            string server = "127.0.0.1";

            TcpClient client = new TcpClient(server, port);
            Byte[] data = Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);

            data = new Byte[256];
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = Encoding.ASCII.GetString(data, 0, bytes);
            txt_Response.Text = responseData + txt_Response.Text + "\r\n" ;

            Byte[] dataExit = Encoding.ASCII.GetBytes("exit\r\n");
            stream.Write(dataExit, 0, dataExit.Length);
            dataExit = new Byte[256];
            Int32 ExitBytes = stream.Read(dataExit, 0, dataExit.Length);

        }
        catch (ArgumentNullException Ae)
        {
            txt_Response.Text = "ArgumentNullException:" + Ae;
        }
        catch (SocketException Se)
        {
            txt_Response.Text = "SocketException: " + Se;
        }
    }
    
    protected void btn_Send_Click(object sender, EventArgs e)
    {

        //--------------------- LAMP AAN -------------------------------------
        if (rdbt_Lamps.SelectedIndex == 0 && rdbt_OnOff.SelectedIndex == 0)
        {
            string message = "lamp 0 on\r\n";   //Lamp 0 aan
            SendMessage(message);

        }
        else if (rdbt_Lamps.SelectedIndex == 1 && rdbt_OnOff.SelectedIndex == 0)
        {
            string message = "lamp 1 on\r\n";   //Lamp 1 aan
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 2 && rdbt_OnOff.SelectedIndex == 0)
        {
            string message = "lamp 2 on\r\n";   //Lamp 2 aan
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 3 && rdbt_OnOff.SelectedIndex == 0)
        {
            string message = "lamp 3 on\r\n";   //Lamp 3 aan
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 4 && rdbt_OnOff.SelectedIndex == 0)
        {
            string message = "lamp 4 on\r\n";   //Lamp 4 aan
            SendMessage(message);
        }
        

        //-------------------------- LAMP UIT ------------------------------------
        else if (rdbt_Lamps.SelectedIndex == 0 && rdbt_OnOff.SelectedIndex == 1)
        {
            string message = "lamp 0 off\r\n";  //Lamp 0 uit
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 1 && rdbt_OnOff.SelectedIndex == 1)
        {
            string message = "lamp 1 off\r\n";  //Lamp 1 uit
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 2 && rdbt_OnOff.SelectedIndex == 1)
        {
            string message = "lamp 2 off\r\n";  //Lamp 2 uit
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 3 && rdbt_OnOff.SelectedIndex == 1)
        {
            string message = "lamp 3 off\r\n";  //Lamp 3 uit
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 4 && rdbt_OnOff.SelectedIndex == 1)
        {
            string message = "lamp 4 off\r\n";  //Lamp 4 uit
            SendMessage(message);

        }
        
        //----------------- STATUS --------------------

        else if (rdbt_Lamps.SelectedIndex == 0 && rdbt_OnOff.SelectedIndex == 2)
        {
            string message = "lamp 0 \r\n";  //Lamp 0 status
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 1 && rdbt_OnOff.SelectedIndex == 2)
        {
            string message = "lamp 1 \r\n";  //Lamp 1 status
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 2 && rdbt_OnOff.SelectedIndex == 2)
        {
            string message = "lamp 2 \r\n";  //Lamp 2 status
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 3 && rdbt_OnOff.SelectedIndex == 2)
        {
            string message = "lamp 3 \r\n";  //Lamp 3 status
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 4 && rdbt_OnOff.SelectedIndex == 2)
        {
            string message = "lamp 4 \r\n";  //Lamp 4 status
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 5 && rdbt_OnOff.SelectedIndex == 3)
        {
            string message = "window 0 \r\n";  //Window 0 status
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 6 && rdbt_OnOff.SelectedIndex == 3)
        {
            string message = "window 1 \r\n";  //Window 1 status
            SendMessage(message);
        }


        //------------------------WHERE IS ----------------------------
        else if (rdbt_Lamps.SelectedIndex == 0 && rdbt_OnOff.SelectedIndex == 3)
        {
            string message = "whereis lamp 0 \r\n";  //Lamp 0 locatie
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 1 && rdbt_OnOff.SelectedIndex == 3)
        {
            string message = "whereis lamp 1 \r\n";  //Lamp 1 locatie
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 2 && rdbt_OnOff.SelectedIndex == 3)
        {
            string message = "whereis lamp 2 \r\n";  //Lamp 2 locatie
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 3 && rdbt_OnOff.SelectedIndex == 3)
        {
            string message = "whereis lamp 3 \r\n";  //Lamp 3 locatie
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 4 && rdbt_OnOff.SelectedIndex == 3)
        {
            string message = "whereis lamp 4 \r\n";  //Lamp 4 locatie
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 5 && rdbt_OnOff.SelectedIndex == 3)
        {
            string message = "whereis window 0 \r\n";  //Window 0 locatie
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 6 && rdbt_OnOff.SelectedIndex == 3)
        {
            string message = "whereis window 1 \r\n";  //Window 1 locatie
            SendMessage(message);
        }


        //------------------- OPEN WINDOW ------------------------
        else if (rdbt_Lamps.SelectedIndex == 5 && rdbt_OnOff.SelectedIndex == 4)
        {
            string message = "window 0 open \r\n";  //Window 0 open
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 6 && rdbt_OnOff.SelectedIndex == 4)
        {
            string message = "window 1 open \r\n";  //Window 1 open
            SendMessage(message);
        }


        //--------------- CLOSE WINDOW -------------------
        else if (rdbt_Lamps.SelectedIndex == 5 && rdbt_OnOff.SelectedIndex == 5)
        {
            string message = "window 0 close \r\n";  //Window 0 close
            SendMessage(message);
        }
        else if (rdbt_Lamps.SelectedIndex == 6 && rdbt_OnOff.SelectedIndex == 5)
        {
            string message = "window 1 close \r\n";  //Window 1 close
            SendMessage(message);
        }

        //---------------- ALL LAMPS ON ----------------------
        else if (rdbt_Lamps.SelectedIndex == 8 && rdbt_OnOff.SelectedIndex == 0)
        {
            string message = "lamp 0 on\r\n";   //Lamp 0 aan
            SendMessage(message);
            message = "lamp 1 on\r\n";   //Lamp 1 aan
            SendMessage(message);
            message = "lamp 2 on\r\n";   //Lamp 2 aan
            SendMessage(message);
            message = "lamp 3 on\r\n";   //Lamp 3 aan
            SendMessage(message);
            message = "lamp 4 on\r\n";   //Lamp 4 aan
            SendMessage(message);
        }

        //---------------- ALL LAMPS OFF --------------------

        else if (rdbt_Lamps.SelectedIndex == 8 && rdbt_OnOff.SelectedIndex == 1)
        {
            string message = "lamp 0 off\r\n";   //Lamp 0 uit
            SendMessage(message);
            message = "lamp 1 off\r\n";   //Lamp 1 uit
            SendMessage(message);
            message = "lamp 2 off\r\n";   //Lamp 2 uit
            SendMessage(message);
            message = "lamp 3 off\r\n";   //Lamp 3 uit
            SendMessage(message);
            message = "lamp 4 off\r\n";   //Lamp 4 uit
            SendMessage(message);
        }

        //------------- ALL WINDOWS OPEN ------------------------

        else if (rdbt_Lamps.SelectedIndex == 9 && rdbt_OnOff.SelectedIndex == 4)
        {
            string message = "window 0 open \r\n";  //Window 0 open
            SendMessage(message);
            message = "window 1 open \r\n";  //Window 1 open
            SendMessage(message);
        }

        //-------------- ALL WINDOWS CLOSE -----------------
        else if (rdbt_Lamps.SelectedIndex == 9 && rdbt_OnOff.SelectedIndex == 5)
        {
            string message = "window 0 close \r\n";  //Window 0 close
            SendMessage(message);
            message = "window 1 close \r\n";  //Window 1 close
            SendMessage(message);
        }

        //------------ LAMPS AMOUNT ----------------
        else if (rdbt_Lamps.SelectedIndex == 8 && rdbt_OnOff.SelectedIndex == 6)
        {
            string message = "lamps \r\n";  //Window  amount
            SendMessage(message);
        }

        //----------- WINDOWS AMOUNT -----------------
        else if (rdbt_Lamps.SelectedIndex == 9 && rdbt_OnOff.SelectedIndex == 6)
        {
            string message = "windows\r\n";  //Window 0 open
            SendMessage(message);
        }

        // ----------- HEATER STATUS ------------------
        else if (rdbt_Lamps.SelectedIndex == 7 && rdbt_OnOff.SelectedIndex == 2)
        {
            string message = "heater\r\n";  //Heater status
            SendMessage(message);
        }

        // ----------- HEATER Temp ------------------
        else if (rdbt_Lamps.SelectedIndex == 7 && rdbt_OnOff.SelectedIndex == 7)
        {
            string HeaterTemp;
            double number;
            if(double.TryParse(txt_Heater.Text, out number) == false)
            {
                txt_Response.Text = "Ongeldig getal"+ "\r\n" + txt_Response.Text ;
            }

            else if(int.Parse(txt_Heater.Text) > 35)
            {
                HeaterTemp = "35";
                string message = "heater " + HeaterTemp + "\r\n";  //Heater status
                SendMessage(message);
            }
            else if(int.Parse(txt_Heater.Text) < 12)
            {
                HeaterTemp = "12";
                string message = "heater " + HeaterTemp + "\r\n";  //Heater status
                SendMessage(message);
            }
            else
            {
                HeaterTemp = txt_Heater.Text;
                string message = "heater " + HeaterTemp + "\r\n";  //Heater status
                SendMessage(message);
            }
            
        }
        else
        {
            txt_Response.Text = "Please select a valid combination" + "\r\n" + txt_Response.Text  ;
        }
    }

    protected void rdbt_Lamps_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}