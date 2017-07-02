using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GlobalMacroRecorder
{
    /// <summary>
    /// 
    /// <author>vtit_dungnt77</author>
    /// <date>1/23/2013 3:15:22 PM</date>
    /// </summary>
    [Serializable()]
   public class ObjectToSerialize
    {
        public  List<MacroEvent> events ;

        public List<MacroEvent> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }

        public ObjectToSerialize()
        {
        }

        public ObjectToSerialize(SerializationInfo info, StreamingContext ctxt)
        {
            this.events = (List<MacroEvent>)info.GetValue("MacroEvent", typeof(List<MacroEvent>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("MacroEvent", this.events);
        }
    }
}
