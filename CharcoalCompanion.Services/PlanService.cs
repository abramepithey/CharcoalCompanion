using CharcoalCompanion.Contracts;
using CharcoalCompanion.Data;
using CharcoalCompanion.Models.Plans;
using CharcoalCompanion.Models.Steps;
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
            using (var ctx = new ApplicationDbContext())
            {
                var stepOne =
                    ctx
                        .Steps
                        .Single(o => o.StepId == model.StepOneId);

                var stepTwo =
                    ctx
                        .Steps
                        .Single(o => o.StepId == model.StepTwoId);

                var stepThree =
                    ctx
                        .Steps
                        .Single(o => o.StepId == model.StepThreeId);

                var entity = new Plan
                {
                    UserId = _userId,
                    StepOne = stepOne,
                    StepTwo = stepTwo,
                    StepThree = stepThree
                };

                ctx.Plans.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<PlanListItem> GetAllPlans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plans
                        .Where(e => /*e.IsSaved == true &&*/ e.UserId == _userId)
                        .Select(e =>
                            new PlanListItem
                            {
                                PlanId = e.PlanId,
                                Title = e.Title
                            });

                return query.ToArray();
            }
        }

        public PlanCreate GetAllStepsToChooseFrom()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var model = new PlanCreate();
                var query =
                    ctx
                        .Steps
                        .Select(e =>
                        new StepListItem
                        {
                            StepId = e.StepId,
                            StepType = e.StepType,
                            Name = e.Name,
                            ImageLink = e.ImageLink
                        }).ToList();

                model.Meats = query.Where(q => q.StepType == Data.Steps.StepTypes.Meat).ToList();
                model.Cuts = query.Where(c => c.StepType == Data.Steps.StepTypes.Cut).ToList();
                model.CharcoalSetups = query.Where(s => s.StepType == Data.Steps.StepTypes.CharcoalSetup).ToList();
                return model;
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
