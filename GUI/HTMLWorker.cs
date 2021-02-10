using System;
using System.IO;

namespace GUI
{
    internal class HTMLWorker
    {
        private Document pdfDoc;

        public HTMLWorker(Document pdfDoc)
        {
            this.pdfDoc = pdfDoc;
        }

        internal void Parse(StringReader sr)
        {
            throw new NotImplementedException();
        }
    }
}