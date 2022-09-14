using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CreatePDFwithImage
{
    public interface ISave
    {
        //Method to save document as a file and view the saved document.
        Task SaveAndView(string filename, string contentType, MemoryStream stream);
    }
}
