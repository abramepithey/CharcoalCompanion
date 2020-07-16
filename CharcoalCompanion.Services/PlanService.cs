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
                return ctx.SaveChanges() >= 1;
            }
        }

        public ICollection<PlanListItem> GetAllPlans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plans
                        .Where(e => e.IsSaved == true && e.UserId == _userId)
                        .Select(e =>
                            new PlanListItem
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
                        PlanId = query.PlanId,
                        Title = query.Title,
                        StepOne = query.StepOne,
                        StepTwo = query.StepTwo,
                        StepThree = query.StepThree,
                        IsSaved = query.IsSaved
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

                entity.IsSaved = model.IsSaved;
                entity.Title = model.Title;
                entity.StepOne = stepOne;
                entity.StepTwo = stepTwo;
                entity.StepThree = stepThree;

                return ctx.SaveChanges() >= 1;
            }
        }

        public PlanCreate CreateModelLoadSteps(PlanCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
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

                var Meats = query.Where(m => m.StepType == Data.Steps.StepTypes.Meat).ToList();
                var Cuts = query.Where(m => m.StepType == Data.Steps.StepTypes.Cut).ToList();
                var CharcoalSetups = query.Where(m => m.StepType == Data.Steps.StepTypes.CharcoalSetup).ToList();

                model.Meats = Meats;
                model.Cuts = Cuts;
                model.CharcoalSetups = CharcoalSetups;
            }

            return model;
        }

        public PlanUpdate UpdateModelLoadSteps(PlanUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
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

                var Meats = query.Where(m => m.StepType == Data.Steps.StepTypes.Meat).ToList();
                var Cuts = query.Where(m => m.StepType == Data.Steps.StepTypes.Cut).ToList();
                var CharcoalSetups = query.Where(m => m.StepType == Data.Steps.StepTypes.CharcoalSetup).ToList();

                model.Meats = Meats;
                model.Cuts = Cuts;
                model.CharcoalSetups = CharcoalSetups;
            }

            return model;
        }

        public bool FavoritePlan(PlanSave model)
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
                        .Single(e => e.PlanId == id && e.UserId == _userId);

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
