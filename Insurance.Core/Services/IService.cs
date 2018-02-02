using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Core.Services
{
    public interface IService
    {
        bool CheckRiskKind(int riskKind, int percent);
    }
}
