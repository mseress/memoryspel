using System.Windows;

namespace Memoryspel.WpfCore
{
    public static class WindowHelper
    {
        // reference: https://stackoverflow.com/questions/4019831/how-do-you-center-your-main-window-in-wpf
        /// <summary>
        /// Centers the <paramref name="window"/> on the screen.
        /// </summary>
        /// <param name="window">The window to be centered on the screen.</param>
        public static void CenterWindowOnScreen(this Window window)
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = window.Width;
            double windowHeight = window.Height;
            window.Left = (screenWidth / 2) - (windowWidth / 2);
            window.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
