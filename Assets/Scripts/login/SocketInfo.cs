using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
public class SocketInfo : MonoBehaviour {

    private IPAddress ipAddress;
    private int portNumber;
    private IPEndPoint ep;
    Socket sock;

    public void Ini(string ipaddress, int portnumber)
    {
        ipAddress = IPAddress.Parse(ipaddress);
        portNumber = portnumber;
        ep = new IPEndPoint(ipAddress,portNumber);
    }

    public int GetPortNumber()
    {
        return portNumber;
    }

    public IPEndPoint GetIPEnd()
    {
        return ep;
    }

    public IPAddress GetAddress()
    {
        return ipAddress;
    }

    public Socket GetSocket()
    {
        return sock;
    }
}
