using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MusikQuiz.Utility
{
    public static class ErrorsForModelState
    {
        public static ModelStateDictionary AddErrorsToModelState(IdentityResult identityResult, ModelStateDictionary modelState)
        {
            foreach (var error in identityResult.Errors)
            {
                modelState.TryAddModelError(error.Code, error.Description);
            }

            return modelState;
        }
    }
}
