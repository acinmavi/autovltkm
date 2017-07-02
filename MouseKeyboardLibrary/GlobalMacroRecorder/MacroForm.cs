using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using MouseKeyboardLibrary;
using System.Runtime.InteropServices;

namespace GlobalMacroRecorder
{
	public partial class MacroForm : Form
	{
		private List<MacroEvent> events = new List<MacroEvent>();
		private int lastTimeRecorded = 0;

		private MouseHook mouseHook = new MouseHook();
		private KeyboardHook keyboardHook = new KeyboardHook();
		private bool isCancel = false;

		public MacroForm()
		{
			InitializeComponent();

			mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);
			mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
			mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);

			keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
			keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);
		}

		private void mouseHook_MouseMove(object sender, MouseEventArgs e)
		{
			events.Add(
				new MacroEvent(
					MacroEventType.MouseMove,
					e,
					Environment.TickCount - lastTimeRecorded
				));

			lastTimeRecorded = Environment.TickCount;
		}

		private void mouseHook_MouseDown(object sender, MouseEventArgs e)
		{
			events.Add(
				new MacroEvent(
					MacroEventType.MouseDown,
					e,
					Environment.TickCount - lastTimeRecorded
				));

			lastTimeRecorded = Environment.TickCount;
		}

		private void mouseHook_MouseUp(object sender, MouseEventArgs e)
		{
			events.Add(
				new MacroEvent(
					MacroEventType.MouseUp,
					e,
					Environment.TickCount - lastTimeRecorded
				));

			lastTimeRecorded = Environment.TickCount;
		}

		private void keyboardHook_KeyDown(object sender, KeyEventArgs e)
		{
			events.Add(
				new MacroEvent(
					MacroEventType.KeyDown,
					e,
					Environment.TickCount - lastTimeRecorded
				));

			lastTimeRecorded = Environment.TickCount;
		}

		private void keyboardHook_KeyUp(object sender, KeyEventArgs e)
		{
			events.Add(
				new MacroEvent(
					MacroEventType.KeyUp,
					e,
					Environment.TickCount - lastTimeRecorded
				));

			lastTimeRecorded = Environment.TickCount;
		}

		private void recordStartButton_Click(object sender, EventArgs e)
		{
			events.Clear();
			lastTimeRecorded = Environment.TickCount;

			keyboardHook.Start();
			mouseHook.Start();
		}

		private void recordStopButton_Click(object sender, EventArgs e)
		{
			ObjectToSerialize ots = new ObjectToSerialize();
			ots.Events = events;

            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\test";
            string filePath = Environment.CurrentDirectory + "\\data\\" + DateTime.Now.ToString("ddMMyyyy-HHmmss");
			ConvertEvent(events);
			SerializeObject(filePath, ots);

			keyboardHook.Stop();
			mouseHook.Stop();
		}
		
		public void WorkThreadFunction(int times)
		{
			try
			{
				ConvertEvent(events);
				isCancel = false;
				for (int i = 0; i < times; i++) {
					foreach (MacroEvent macroEvent in events)
					{
						if(isCancel) break;
						Thread.Sleep(macroEvent.TimeSinceLastEvent);

						switch (macroEvent.MacroEventType)
						{
							case MacroEventType.MouseMove:
								{
									MyMouseEventArgs mouseArgs = (MyMouseEventArgs)macroEvent.EventArgs;

									MouseSimulator.X = mouseArgs.X;
									MouseSimulator.Y = mouseArgs.Y;
								}
								break;

							case MacroEventType.MouseDown:
								{
									MyMouseEventArgs mouseArgs = (MyMouseEventArgs)macroEvent.EventArgs;

									MouseSimulator.MouseDown(mouseArgs.Button);
								}
								break;

							case MacroEventType.MouseUp:
								{
									MyMouseEventArgs mouseArgs = (MyMouseEventArgs)macroEvent.EventArgs;

									MouseSimulator.MouseUp(mouseArgs.Button);
								}
								break;

							case MacroEventType.KeyDown:
								{
									MyKeyEventArgs keyArgs = (MyKeyEventArgs)macroEvent.EventArgs;

									KeyboardSimulator.KeyDown(keyArgs.KeyCode);
								}
								break;

							case MacroEventType.KeyUp:
								{
									MyKeyEventArgs keyArgs = (MyKeyEventArgs)macroEvent.EventArgs;

									KeyboardSimulator.KeyUp(keyArgs.KeyCode);
								}
								break;

							default:
								break;
						}
					}
					if(times > 1) {
						Thread.Sleep(2000);
					}
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void playBackMacroButton_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(() => WorkThreadFunction(1));
			thread.Start();
			
		}

		private void MacroForm_Load(object sender, EventArgs e)
		{
		}

		public void SerializeObject(string filename, ObjectToSerialize objectToSerialize)
		{
			Stream stream = File.Open(filename, FileMode.Create);
			BinaryFormatter bFormatter = new BinaryFormatter();
			bFormatter.Serialize(stream, objectToSerialize);
			stream.Close();
		}

		public ObjectToSerialize DeSerializeObject(string filename)
		{
			ObjectToSerialize objectToSerialize;
			Stream stream = File.Open(filename, FileMode.Open);
			BinaryFormatter bFormatter = new BinaryFormatter();
			objectToSerialize = (ObjectToSerialize)bFormatter.Deserialize(stream);
			stream.Close();
			return objectToSerialize;
		}

		public void ConvertEvent(List<MacroEvent> events)
		{
			foreach (var item in events)
			{
				if (item.EventArgs is MouseEventArgs)
				{
					MouseEventArgs arg = (MouseEventArgs)item.EventArgs;
					MyMouseEventArgs myArgs = new MyMouseEventArgs(arg.Button, arg.Clicks, arg.X, arg.Y, arg.Delta);
					item.EventArgs = myArgs;
				}
				else if (item.EventArgs is KeyEventArgs)
				{
					KeyEventArgs arg = (KeyEventArgs)item.EventArgs;
					MyKeyEventArgs myArgs = new MyKeyEventArgs(arg.KeyCode);
					item.EventArgs = myArgs;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
                string filePath = null;
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Open Data File";
                theDialog.InitialDirectory = Environment.CurrentDirectory;
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = theDialog.FileName.ToString();
                }

				isCancel = false;
				ObjectToSerialize ots = DeSerializeObject(filePath);
				events = ots.Events;
				Thread thread = new Thread(() => WorkThreadFunction(int.Parse(txtLoop.Text)));
				thread.Start();									

			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			isCancel = true;
		}


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                isCancel = true;
                return true;
            }
            else if (keyData == Keys.F2)
            {
                recordStartButton_Click(null, null);
            }
            else if (keyData == Keys.F3)
            {
                recordStopButton_Click(null, null);
            }
            else if (keyData == Keys.F8)
            {
                button1_Click(null, null);
            }
            else if (keyData == Keys.F9)
            {
                playBackMacroButton_Click(null, null);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


		
	}
}