using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DavalaAdmin.로직쓰
{
    class Crawler
    {
        public int count;
        public List<string> paths;
        public string title;
        public string price, discount, discountPrice;
        public string category;
        public bool LoadData(string url)
        {
            paths = new List<string>();
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string html = wc.DownloadString(url);
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(html);
            string folderPath = "";
            //메인 사진 찾기
            foreach (HtmlNode node in hd.DocumentNode.SelectNodes("//img"))
            {
                try
                {
                    if (node.ParentNode.GetAttributeValue("class", "") == "descImageBig" || node.ParentNode.GetAttributeValue("class", "") == "imageCnt on")
                    {
                        title = node.Attributes["alt"].Value;
                        //폴더 만들기
                        folderPath = Application.StartupPath + "\\" + title + "\\";
                        DirectoryInfo di = new DirectoryInfo(folderPath);
                        if (!di.Exists)
                        {
                            //없으면 만듬
                            di.Create();
                        }
                        //다운로드
                        wc.DownloadFile(node.Attributes["src"].Value, folderPath + "main" + GetExtension(node.Attributes["src"].Value));
                        //후에 패쓰에 저장
                        paths.Add(folderPath + "main" + GetExtension(node.Attributes["src"].Value));
                        break;
                    }

                }
                catch
                {

                }
            }
            if (folderPath == "") return false;
            //콘텐츠 사진 찾기
            foreach (HtmlNode node in hd.DocumentNode.SelectNodes("//div"))
            {
                try
                {
                    if (node.GetAttributeValue("class", "") == "contentsDetail")
                    {
                        Console.WriteLine("찾았다");
                        HtmlAgilityPack.HtmlDocument hd2 = new HtmlAgilityPack.HtmlDocument();
                        hd2.LoadHtml(node.OuterHtml);
                        count = 1;

                        foreach (HtmlNode node2 in hd2.DocumentNode.SelectNodes("//img"))
                        {
                            try
                            {
                                //다운로드
                                wc.DownloadFile(node2.Attributes["src"].Value, folderPath + GetSubFileName(node2.Attributes["src"].Value, count));
                                //후에 패쓰에 저장
                                paths.Add(folderPath + GetSubFileName(node2.Attributes["src"].Value,count++));
                            }
                            catch
                            {

                            }
                        }

                        break;
                    }
                }
                catch
                {

                }
            }

            foreach (HtmlNode node in hd.DocumentNode.SelectNodes("//meta"))
            {
                try
                {
                    //원가 탐색
                    if (node.GetAttributeValue("property", "") == "product:original_price:amount")
                    {
                        price = node.Attributes["content"].Value;
                    }
                    //할인가탐색
                    else if (node.GetAttributeValue("property", "") == "product:sale_price:amount")
                    {
                        discountPrice = node.Attributes["content"].Value;
                    }
                    //카테고리 탐색
                    else if (node.GetAttributeValue("property", "") == "product:category")
                    {
                        string text = node.Attributes["content"].Value;
                        category = text.Substring(text.LastIndexOf('/') + 1).Trim(' ');
                    }
                }
                catch
                {

                }
            }

            foreach (HtmlNode node in hd.DocumentNode.SelectNodes("//strong"))
            {
                try
                {
                    //할인율탐색
                    if (node.GetAttributeValue("class", "") == "nuNumber rateNum")
                    {
                        int percentage;
                        bool result = int.TryParse(node.InnerText, out percentage);
                        if(result)
                        {
                            discount = node.InnerText;
                        }
                        else{
                            discount = "0";
                        }
                        discount = node.InnerText;
                    }
                }
                catch
                {

                }
            }

            return true;
        }

        private string CreateFileName(string url)
        {
            return url.Substring(url.LastIndexOf('/') + 1, url.Length - url.LastIndexOf('/') - 1);
        }

        private string GetSubFileName(string url, int count)
        {
            return string.Format("{0}{1}", count, GetExtension(url));
        }

        private string GetExtension(string url)
        {
            return url.Substring(url.Length - 4, 4);
        }
    }
}
