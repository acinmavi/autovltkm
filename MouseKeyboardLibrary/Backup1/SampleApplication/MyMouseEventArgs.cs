﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
namespace GlobalMacroRecorder
{
    /// <summary>
    ///     The MouseEventArgs class provides access to the logical
    ///     Mouse device for all derived event args.
    /// </summary>
    /// 
    [Serializable]
    public class MyMouseEventArgs : EventArgs
    {
        public MyMouseEventArgs()
        {
            
        }
        public MyMouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta)
        {
            _Button = button;
            _Clicks = clicks;
            _X = x;
            _Y = y;
            _Delta = delta;
        }

        private MouseButtons _Button;
        private int _Clicks;
        private int _Delta;
        private int _X;
        private int _Y;

        public MouseButtons Button { get { return _Button; } }
        public int Clicks { get { return _Clicks; } }
        public int Delta { get { return _Delta; } }
        public Point Location { get { return new Point(_X, _Y); } }
        public int X { get { return _X; } }
        public int Y { get { return _Y; } }

        public static implicit operator MyMouseEventArgs(MouseEventArgs e)
        {
            return new MyMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta);
        }
        public static implicit operator MouseEventArgs(MyMouseEventArgs e)
        {
            return new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta);
        }
    }
}
