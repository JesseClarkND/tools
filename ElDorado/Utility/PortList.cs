using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElDorado.Utility
{
    public class PortList
    {
        //https://github.com/PhilipMur/C-Sharp-Multi-Threaded-Port-Scanner/blob/master/MultiPortScan/PortList.cs
        private int start;
        private int stop;
        private int ports;

        public PortList(int starts, int stops)
        {
            start = starts;
            stop = stops;
            ports = start;
        }

        public bool MorePorts()
        {
            return (stop - ports) >= 0;
        }
        public int NextPort()
        {
            if (MorePorts())
            {
                return ports++;
            }
            return -1;
        }
    }
}