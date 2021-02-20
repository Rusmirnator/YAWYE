using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface ICalcData
    {
        CalcData FindWeight(int CalcDataId);
        CalcData AddWeight(CalcData newData);
        CalcData Update(CalcData updatedData);
        CalcData Delete(int id);
        int Commit();
    }
}
