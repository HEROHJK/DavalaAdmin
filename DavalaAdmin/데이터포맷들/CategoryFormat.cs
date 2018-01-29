using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavalaAdmin.데이터포맷들
{
    class CategoryFormat
    {
        public int index;
        public string name;
        public int parentIndex;
        public List<CategoryFormat> childList;

        private CategoryFormat() { }

        public CategoryFormat(int index, string name, int parentIndex)
        {
            this.index = index;
            this.name = name;
            this.parentIndex = parentIndex;
            childList = new List<CategoryFormat>();
        }
    }
}
