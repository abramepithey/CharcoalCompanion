﻿using CharcoalCompanion.Contracts;
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
        public int? CreatePlan(PlanCreate model)
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
                    Title = model.Title,
                    StepOne = stepOne,
                    StepTwo = stepTwo,
                    StepThree = stepThree,
                    IsSaved = true
                };

                ctx.Plans.Add(entity);
                ctx.SaveChanges();

                return entity.PlanId;
            }
        }

        public ICollection<PlanListItem> GetAllPlans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plans
                        .Where(e => e.IsSaved == true)
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
                        StepThree = query.StepThree
                    };
            }
        }

        public PlanDetail GetOwnedPlanById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Plans
                        .Single(e => e.PlanId == id && e.IsSaved == true);

                if (query.UserId != _userId)
                {
                    throw new UnauthorizedAccessException();
                }

                return
                    new PlanDetail
                    {
                        PlanId = query.PlanId,
                        Title = query.Title,
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
                        .Where(e => e.IsSaved == true)
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

                if (Meats.Count == 0 || Cuts.Count == 0 || CharcoalSetups.Count == 0)
                {
                    throw new Exception();
                }

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
                        .Where(e => e.IsSaved == true)
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

                if (Meats.Count == 0 || Cuts.Count == 0 || CharcoalSetups.Count == 0)
                {
                    throw new Exception();
                }

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

        public PlanService() { }
    }
}
