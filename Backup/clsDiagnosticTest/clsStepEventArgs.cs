using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clsDiagnosticTest
{
    /// <summary>
    /// <Author>WDK 2/6/10 </Author>
    /// Step Event args
    /// </summary>
    public class StepEventArgs : System.EventArgs
    {
        public string strStepName = "";
        public StepEventArgs(string stepName)
        {
            strStepName = stepName;
        }
    }

}
