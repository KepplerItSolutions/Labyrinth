using System.Drawing;
using System.IO;

namespace B_ESA_4.Common
{
    public static class IconExtension
    {
        const string K_ICON = "K.ico";

        public static Icon GetKepplerIcon(this Icon icon, string startUpPath)
        {
            string iconFile = startUpPath + "\\" + K_ICON;
            if (File.Exists(iconFile))
            {
                return new Icon(iconFile);
            }
            return icon;
        }
    }
}
