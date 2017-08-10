using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using NetPing.Common;

namespace NetPing
{
	public class HostListViewItem : ListViewItem
	{
		private IPAddress				_ipAddress;
		private string[]				_sortKeys;
		private Ping					_ping = new Ping();
		private BackgroundWorker		_worker = new BackgroundWorker();
		private List<IColumnProvider>	_columnsToProcess = new List<IColumnProvider>();

		public HostListViewItem(IPAddress ipAddress)
			: base(ipAddress.ToString(), 0)
		{
			_ipAddress = ipAddress;	
			
			// We're going to run the ping on another thread, so we need to wire up the PingCompleted event.
			_ping.PingCompleted += new PingCompletedEventHandler(WhenPingCompleted);

			// Likewise, the BackgroundWorker class will execute each of the column providers on a separate thread, one at a time,
			// so we need to wire up the event handlers that let us know when to execute each provider as well as when execution is 
			// complete for each.
			_worker.DoWork += new DoWorkEventHandler(DoWork);
			_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(WhenRunWorkerCompleted);

			// Create the array containing the sort keys.
			_sortKeys = new string[MainForm.ColumnProviders.Count + 2];

			// Create sort key for IP address. Ensuring that the final octet of the IP address is displayed with leading zeros is
			// enough to ensure that the string comparer sorts the values correctly.
			_sortKeys[0] = _ipAddress.GetAddressBytes()[3].ToString("000");
		}

		public IPAddress IpAddress
		{
			get { return _ipAddress; }
		}

		public string[] SortKeys
		{
			get { return _sortKeys; }
		}

		public void Ping()
		{
			// Ping on a new thread. WhenPingCompleted will be called when the ping is complete.
			_ping.SendAsync(IpAddress, null);
		}

		private void WhenPingCompleted(object sender, PingCompletedEventArgs e)
		{
			// We only care about the computers that successfully responded to our ping request.
			if (e.Reply.Status == IPStatus.Success)
			{
				// Change the image to reflect the online status.
				ImageIndex = 1;

				// Add the ping response time.
				SubItems.Add(e.Reply.RoundtripTime.ToString());
				
				// Create an empty subitem for each of the column provider types. These will be populated in a moment.
				for (int i = 0; i < MainForm.ColumnProviders.Count; i++)
				{
					SubItems.Add("");
				}

				// Set the sort key value to the number of milliseconds.
				_sortKeys[1] = e.Reply.RoundtripTime.ToString("00000000");

				// Add all of the column providers to the list of columns to process.
				_columnsToProcess.AddRange(MainForm.ColumnProviders);
				
				// Start processing columns.
				ProcessNextColumn();
			}
			else
			{
				// The ping wasn't a success, so remove this item from the ListView.
				Remove(); 
			}
		}

		private void ProcessNextColumn()
		{
			if (_columnsToProcess.Count > 0)
			{
				// Tell the BackgroundWorker that we would like to run a process on another thread.  
				_worker.RunWorkerAsync();
			}
		}

		private void DoWork(object sender, DoWorkEventArgs e)
		{
			// This method is being called on a new thread; since we're calling the column provider from this new thread, the
			// column writer doesn't need to write their own threading code and can focus solely on the column's function.

			// This method is only called if the _columnsToProcess list has items in it, so we can safely grab the first one, then 
			// remove it from the list so it won't be processed again.
			IColumnProvider columnProvider = _columnsToProcess[0];
			_columnsToProcess.Remove(columnProvider);


			// The WhenRunWorkerCompleted method expects Result to be a ColumnValue object, so we'll pass either the result
			// returned from the column provider, or a value containing error information if the column provider throws
			// an exception. Note that we don't update the ListView right now because we're on a thread other than
			// the UI thread. The UI can only be manipulated on its own thread.
			try
			{
				e.Result = columnProvider.Execute(IpAddress);
			}
			catch (Exception e1)
			{
				e.Result = new ColumnValue(columnProvider.ColumnIndex, "Exception: " + e1.Message);
			}
		}

		private void WhenRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// The DoWork method has completed, so the BackgroundWorker object is letting us know by firing the RunWorkerCompleted event on 
			// the UI thread, from where we can update the ListView.

			// Get the ColumnValue result and update the corresponding column's text.
			ColumnValue columnValue = (ColumnValue)e.Result;
			SubItems[columnValue.ColumnIndex].Text = columnValue.Text;
			_sortKeys[columnValue.ColumnIndex] = columnValue.SortKey;

			// Process the next column.
			ProcessNextColumn();
		}
	}
}
