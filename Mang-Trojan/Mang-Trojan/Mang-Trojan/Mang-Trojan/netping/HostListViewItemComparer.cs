using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;

namespace NetPing
{
	class HostListViewItemComparer : IComparer
	{
		private int			_columnIndex; 
		private SortOrder	_sortOrder;

		public HostListViewItemComparer(int columnIndex, SortOrder sortOrder)
		{
			_columnIndex = columnIndex;
			_sortOrder = sortOrder;
		}

		public int Compare(object x, object y)
		{
			int result = Comparer<string>.Default.Compare(((HostListViewItem)x).SortKeys[_columnIndex], ((HostListViewItem)y).SortKeys[_columnIndex]);
			
			// Reverse the order if descending.
			if (_sortOrder == SortOrder.Descending)
			{
				result = -result;
			}

			return result;
		}
	}
}
