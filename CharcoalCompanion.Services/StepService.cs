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
            var entity = new Step()
            {
                UserId = _userId,
                StepType = model.StepType,
                Name = model.Name,
                Description = model.Description,
                ImageLink = model.ImageLink
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
                        .Select(
                            e =>
                                new StepListItem
                                {
                                    StepId = e.StepId,
                                    StepType = e.StepType,
                                    Name = e.Name,
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
                        .Single(e => e.StepId == id);
                return
                    new StepDetail
                    {
                        StepId = entity.StepId,
                        StepType = entity.StepType,
                        Name = entity.Name,
                        Description = entity.Description,
                        ImageLink = entity.ImageLink
                    };
            }
        }

        public bool EditStep(StepUpdate model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStep(int id)
        {
            throw new NotImplementedException();
        }

        private readonly Guid _userId;

        public StepService(Guid userId)
        {
            _userId = userId;
        }
    }
}
