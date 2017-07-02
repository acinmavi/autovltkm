using System;
using System.Windows.Forms;

namespace MouseKeyboardLibrary
{
    /// <summary>
    ///
    /// <author>vtit_dungnt77</author>
    /// <date>1/23/2013 3:46:37 PM</date>
    /// </summary>
    [Serializable]
     public class MyKeyEventArgs : EventArgs {
        #region Fields

private Keys keydata;
private Keys keycode;
private Keys modifiers;
private bool alt = false;
private bool control = false;
private bool handled = false;
private bool shift = false;
private int keyvalue = -1;

#endregion Fields

        //
//  --- Constructor
//
public MyKeyEventArgs(Keys keycode)
{
    this.keycode = keycode;
}

        #region Public Properties

public virtual bool Alt
{
get {
return alt;
}
}

public bool Control
{
get {
return control;
}
}

public bool Handled
{
get {
return handled;
}
set {
handled = value;
}
}

public Keys KeyCode
{
get {
return keycode;
}
}

public Keys KeyData
{
get {
return keydata;
}
}

public int KeyValue
{
get {
return keyvalue;
}
}

public Keys Modifiers
{
get {
return modifiers;
}
}

public bool Shift
{
get {
return shift;
}
}

#endregion Public Properties

        #region Public Methods

/// <summary>
/// GetHashCode Method
/// </summary>
///
/// <remarks>
/// Calculates a hashing value.
/// </remarks>

public override int GetHashCode ()
{
//FIXME: add class specific stuff;
return base.GetHashCode();
}

/// <summary>
/// ToString Method
/// </summary>
///
/// <remarks>
/// Formats the object as a string.
/// </remarks>

public override string ToString ()
{
//FIXME: add class specific stuff;
return base.ToString() + " KeyEventArgs";
}

#endregion Public Methods
}
}