using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class PageGet
    {
        public static string GetPageBar(int pageIndex, int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;
            }
            int start = pageIndex - 1;
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 2;
            if (end > pageCount)
            {
                end = pageCount;
            }
            StringBuilder sb = new StringBuilder();



            sb.Append(string.Format("<a href='?pageIndex={0}'>首页</a>", 1));

            //int x = pageIndex - 1;
            //if (x < 1) x = 1;
            //if(x>=2){
            //sb.Append(string.Format("<a href='?pageIndex={0}'>上一页</a>", x));}

            for (int i = start; i <= end; i++)
            {



                if (i == pageIndex)
                {

                    sb.Append(i);
                }

                else
                {
                    sb.Append(string.Format("<a href='?pageIndex={0}'>{0}</a>", i));  //所以在后台可以使用request进行接收
                }

            }

            //int y = pageIndex + 1;
            //if (y > pageCount) y = pageCount;
            //sb.Append(string.Format("<a href='?pageIndex={0}'>下一页</a>", y));
            sb.Append(string.Format("<a href='?pageIndex={0}'>尾页</a>", pageCount));
            return sb.ToString();
        }

    
     }
}
