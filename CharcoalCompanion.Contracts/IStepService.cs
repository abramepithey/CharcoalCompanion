using CharcoalCompanion.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharcoalCompanion.Contracts
{
    public interface IStepService
    {
        bool CreateStep(StepCreate model);
        IEnumerable<StepListItem> GetAllSteps();
        IEnumerable<StepListItem> GetAllOfOneStep();
        StepDetail GetStepById(int id);
        bool EditStep(StepUpdate model);
        bool DeleteStep(int id);
    }
}
