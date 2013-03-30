using System;

namespace NCore.Validation
{
    public interface IObjectValidator<T> : IValidate<T> where T : class 
    {
        ObjectValidator<T> FailIf(Func<T, bool> requirement, Func<T, Violation> violationFn);
        ObjectValidator<T> BreakIfAnyViolations();
    }
}