using Syncfusion.HtmlConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_HTML_to_MHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize HTML converter with WebKit rendering engine.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);           

            //Convert URL to MHTML.
            htmlConverter.ConvertToMhtml("http://www.syncfusion.com", "../../Data/Sample.mhtml");
        }
    }
}
