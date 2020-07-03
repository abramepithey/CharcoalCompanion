using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Contracts
{
    public interface IPlanService
    {
        //bool CreatePlan(PlanCreate model);
        //bool UpdatePlan(PlanUpdate model);
        void PlanDetail(int id);
        bool DeletePlan(int id);
    }
}
