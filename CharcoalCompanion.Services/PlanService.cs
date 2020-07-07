using CharcoalCompanion.Contracts;
using CharcoalCompanion.Models.Plans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Services
{
    public class PlanService : IPlanService
    {
        public bool CreatePlan(PlanCreate model)
        {
            throw new NotImplementedException();
        }

        public ICollection<PlanList> GetAllPlans()
        {
            throw new NotImplementedException();
        }

        public PlanDetail GetPlanById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePlan(PlanUpdate model)
        {
            throw new NotImplementedException();
        }

        public bool DeletePlan(int id)
        {
            throw new NotImplementedException();
        }

        private readonly Guid _userId;
        public PlanService(Guid userId)
        {
            _userId = userId;
        }
    }
}
