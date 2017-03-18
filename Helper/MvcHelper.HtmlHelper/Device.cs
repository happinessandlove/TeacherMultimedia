using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MvcHelper.HtmlHelper
{
    /// <summary>
    /// 控制设备的类
    /// </summary>
    public static class Device
    {
        /// <summary>
        /// 打开设备
        /// </summary>
        /// <param name="data">打开设备的控制字符串 "44532D4F4D50010201000400+中控IP地址"</param>
        public static void Open(string data)
        {
          
            byte[] sendBytes = Encoding.UTF8.GetBytes(data);
            byte[] recvBytes = new byte[1024];
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);
            try
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse("222.192.32.80"), 17001));
                socket.Send(sendBytes, sendBytes.Length, SocketFlags.None);
                int recvLength = socket.Receive(recvBytes, recvBytes.Length, SocketFlags.None);
                string receive = Encoding.UTF8.GetString(recvBytes, 0, recvLength);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Disconnect(false);
                socket.Close();
                socket.Dispose();
            }
        }
    }
}
