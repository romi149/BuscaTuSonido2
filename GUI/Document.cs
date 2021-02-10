using System;

namespace GUI
{
    internal class Document
    {
        private object a4;
        private float v1;
        private float v2;
        private float v3;
        private float v4;

        public Document(object a4, float v1, float v2, float v3, float v4)
        {
            this.a4 = a4;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }
    }
}