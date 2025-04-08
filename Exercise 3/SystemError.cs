using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    internal abstract class SystemError
    {
        public abstract string ErrorMessage();
    }

    internal class EngineFailureError : SystemError
    {
        public override string ErrorMessage()
        {
            return "Motorfel: Kontrollera motorstatus!";
        }
    }

    internal class BrakeFailureError : SystemError
    {
        public override string ErrorMessage()
        {
            return "Bromsfel: Fordonet är osäkert att köra!";
        }
    }

    internal class TransmissionFailureError : SystemError
    {
        public override string ErrorMessage()
        {
            return "Växellådsproblem: Reparation krävs!";
        }
    }
}
