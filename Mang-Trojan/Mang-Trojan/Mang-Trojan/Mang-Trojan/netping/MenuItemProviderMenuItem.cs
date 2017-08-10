using System.Windows.Forms;
using NetPing.Common;

namespace NetPing
{
	public class MenuItemProviderMenuItem : ToolStripMenuItem
	{
		private IContextMenuItemProvider _menuItemProvider;

		public MenuItemProviderMenuItem(IContextMenuItemProvider menuItemProvider)
			: base(menuItemProvider.Text)
		{
			_menuItemProvider = menuItemProvider;
		}
		
		public IContextMenuItemProvider MenuItemProvider
		{
			get { return _menuItemProvider; }
		}
	}
}
