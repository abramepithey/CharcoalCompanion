using CharcoalCompanion.Contracts;
using CharcoalCompanion.Data;
using CharcoalCompanion.Data.Steps;
using CharcoalCompanion.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CharcoalCompanion.Services
{
    public class StepService : IStepService
    {
        public bool CreateStep(StepCreate model)
        {
            var entity = new Step
            {
                UserId = _userId,
                StepType = model.StepType,
                Name = model.Name,
                Description = model.Description,
                FinalPageDetail = model.FinalPageDetail,
                ImageLink = model.ImageLink,
                IsSaved = true
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Steps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StepListItem> GetAllSteps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Steps
                        .Where(e => e.IsSaved == true)
                        .Select(
                            e =>
                                new StepListItem
                                {
                                    StepId = e.StepId,
                                    StepType = e.StepType,
                                    Name = e.Name,
                                    Description = e.Description,
                                    ImageLink = e.ImageLink
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<StepListItem> GetAllOfOneStep()
        {
            throw new NotImplementedException();
        }

        public StepDetail GetStepById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Steps
                        .Single(e => e.StepId == id && e.IsSaved == true);
                return
                    new StepDetail
                    {
                        StepId = entity.StepId,
                        StepType = entity.StepType,
                        Name = entity.Name,
                        Description = entity.Description,
                        FinalPageDetail = entity.FinalPageDetail,
                        ImageLink = entity.ImageLink
                    };
            }
        }

        public StepDetail GetOwnedStepById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Steps
                        .Single(e => e.StepId == id && e.IsSaved == true);

                if (entity.UserId != _userId)
                {
                    throw new UnauthorizedAccessException();
                }

                return
                    new StepDetail
                    {
                        StepId = entity.StepId,
                        StepType = entity.StepType,
                        Name = entity.Name,
                        Description = entity.Description,
                        FinalPageDetail = entity.FinalPageDetail,
                        ImageLink = entity.ImageLink
                    };
            }
        }

        public bool UpdateStep(StepUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Steps
                        .Single(e => e.StepId == model.StepId);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.FinalPageDetail = model.FinalPageDetail;
                entity.ImageLink = model.ImageLink;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStep(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Steps
                        .Single(e => e.StepId == id);

                entity.IsSaved = false;

                return ctx.SaveChanges() == 1;
            }
        }

        private readonly Guid _userId;

        public StepService(Guid userId)
        {
            _userId = userId;
        }

        public StepService() { }
    }
}
