using System;
using System.Runtime.InteropServices;

namespace ACEManager
{
    public partial class NativeMethods
    {
        // P/Invoke declarations
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem);

        // About form constants
        // P/Invoke constants
        public const int WM_SYSCOMMAND = 0x112;
        public const int MF_STRING = 0x0;
        public const int MF_SEPARATOR = 0x800;

        /// <summary>
        /// ID for the Config item on the system menu
        /// </summary>
        public const int ext_SYSMENU_CONFIG_ID = 0x1;
        /// <summary>
        /// ID for the Database Maintenance item on the system menu
        /// </summary>
        public const int ext_SYSMENU_DBMAINT_ID = 0x2;
        /// <summary>
        /// ID for the About item on the system menu
        /// </summary>
        public const int ext_SYSMENU_ABOUT_ID = 0x3;
    }
}
