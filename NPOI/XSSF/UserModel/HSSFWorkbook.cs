using System.IO;

namespace NPOI.XSSF.UserModel
{
    internal class HSSFWorkbook
    {
        private FileStream fs;

        public HSSFWorkbook(FileStream fs)
        {
            this.fs = fs;
        }
    }
}