using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
public class SocketClass {

    public void Create(ref Socket sock)
    {
        sock = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
    }

    public void Send(Socket sock,string message)
    {
        byte[] sendmessage = Encoding.UTF8.GetBytes(message);
        sock.Send(sendmessage);
    }

    public byte[] Recv(Socket sock,int bytearry)
    {
        byte[] recv = new byte[bytearry];
        sock.Receive(recv);
        return recv;
    }

    public void Connect(ref Socket sock,IPAddress ip,int portnum)
    {
        while (!sock.Connected)
        {
            sock.Connect(ip,portnum);
        }
    }

    public void Accept(Socket sock,Socket newsock)
    {
        newsock = sock.Accept();
    }

    public void ShutDown(ref Socket sock)
    {
        sock.Shutdown(SocketShutdown.Both);
    }
}
