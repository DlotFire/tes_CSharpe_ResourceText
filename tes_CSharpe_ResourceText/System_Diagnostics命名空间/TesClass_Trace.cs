using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace tes_CSharpe_ResourceText.System_Diagnostics命名空间
{
    class TesClass_Trace
    {
        public TesClass_Trace()
        {
            Console.WriteLine("\n====== TesClass_Trace construction ======");

            OriginTemplete();

            Console.WriteLine("\n------ TesClass_Trace construction ------");
        }

        private void OriginTemplete()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;
            Trace.Indent();
            Trace.WriteLine("Entering Main");
            Console.WriteLine("Hello World.");
            Trace.WriteLine("Exiting Main");
            Trace.Unindent();
        }
    }
}
