using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavalaAdmin.데이터포맷들
{
    class ImageInfo
    {
        public string[] paths;
        public string[] names;
        public string[] urls;

        public ImageInfo(int capacity)
        {
            paths = new string[capacity + 1];
            names = new string[capacity + 1];
            urls = new string[capacity + 1];
        }
    }
}
