using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface ICalcData
    {
        CalcData GetById(int id);
        decimal FindWeight(int mid,int pid);
        CalcData AddWeight(CalcData newData);
        CalcData Update(CalcData updatedData);
        CalcData Delete(int id);
        CalcData LoadLast();
        int Commit();
    }
}
