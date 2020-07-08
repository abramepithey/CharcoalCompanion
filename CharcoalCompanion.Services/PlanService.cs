using CharcoalCompanion.Contracts;
using CharcoalCompanion.Data;
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
            var entity = new Plan
            {
                UserId = _userId,
                StepOne = model.StepOne,
                StepTwo = model.StepTwo,
                StepThree = model.StepThree
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Plans.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<PlanList> GetAllPlans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plans
                        .Where(e => e.IsSaved == true && e.UserId == _userId)
                        .Select(e =>
                            new PlanList
                            {
                                PlanId = e.PlanId,
                                Title = e.Title
                            });

                return query.ToArray();
            }
        }

        public PlanDetail GetPlanById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plans
                        .Single(e => e.PlanId == id && e.IsSaved == true);

                return
                    new PlanDetail
                    {
                        StepOne = query.StepOne,
                        StepTwo = query.StepTwo,
                        StepThree = query.StepThree
                    };
            }
        }

        public bool UpdatePlan(PlanUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plans
                        .Single(e => e.PlanId == model.PlanId && e.UserId == _userId);

                entity.IsSaved = model.IsSaved;
                entity.Title = model.Title;
                entity.StepOne = model.StepOne;
                entity.StepTwo = model.StepTwo;
                entity.StepThree = model.StepThree;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool SavePlan(PlanSave model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plans
                        .Single(e => e.PlanId == model.PlanId && e.UserId == _userId);

                entity.Title = model.Title;
                entity.IsSaved = true;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlan(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Plans
                        .Single(e => e.PlanId == id && e.UserId == _userId && e.IsSaved == true);

                entity.IsSaved = false;

                return ctx.SaveChanges() == 1;
            }
        }

        private readonly Guid _userId;
        public PlanService(Guid userId)
        {
            _userId = userId;
        }
    }
}
