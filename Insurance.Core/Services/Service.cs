using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Core.Services
{
    public class Service : IService
    {
        //Validar que las polizás de riesgo alto cubrimiento < 50%
        public bool CheckRiskKind(int riskKind, int percent)
        {
            return (riskKind == 4 && percent > 50)? false : true;
        }
    }
}
