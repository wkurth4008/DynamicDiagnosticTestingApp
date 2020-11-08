//////////////////////////////////////////////////////////
///
/// Name: diagnosticStepInfo
/// Author: William Kurth
/// Description: Test step Information for all user defined steps
/// Class:  diagnosticStepInfo
/// Base Class: 
/// Notes:
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsDiagnosticTest;

namespace ACSDiagnosticsMainForm
{
    /// <summary>
    /// Step Info for all user defined steps
    /// </summary>
   public class diagnosticStepInfo
    {

        public int order;

        public string strStepName;

        public clsDiagnosticTest.ucDiagnosticStep objMyStep;

        public string strResultText;

        public clsDiagnosticTest.ucDiagnosticStep.StepResult myResult;


    }


}
