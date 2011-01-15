using System.Runtime.InteropServices;
using System.Windows;

namespace org.pescuma.icm
{
	internal class Win32Utils
	{
		internal static Point GetCursorPos()
		{
			Win32_POINT p;
			Win32_GetCursorPos(out p);
			return new Point(p.X, p.Y);
		}

		[DllImport("user32.dll", EntryPoint = "GetCursorPos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool Win32_GetCursorPos(out Win32_POINT lpPoint);

		[StructLayout(LayoutKind.Sequential)]
// ReSharper disable InconsistentNaming
		private struct Win32_POINT // ReSharper restore InconsistentNaming
		{
			public int X;
			public int Y;
		}
	}
}
