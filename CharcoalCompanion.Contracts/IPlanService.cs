using CharcoalCompanion.Models.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Contracts
{
    public interface IPlanService
    {
        bool CreatePlan(PlanCreate model);
        ICollection<PlanListItem> GetAllPlans();
        PlanDetail GetPlanById(int id);
        bool UpdatePlan(PlanUpdate model);
        bool DeletePlan(int id);
    }
}
