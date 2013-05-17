using System;
using System.Collections.Generic;
using System.Linq;

namespace NCore.Validation
{
    public class ObjectValidator<T> : IObjectValidator<T> where T : class
    {
        protected IList<IValidationNode> ValidationNodes { get; private set; }

        public ObjectValidator()
        {
            ValidationNodes = new List<IValidationNode>();
        }

        public virtual ObjectValidator<T> FailIf(Func<T, bool> requirement, Func<T, Violation> violationFn)
        {
            ValidationNodes.Add(new Requirement(requirement, violationFn));

            return this;
        }

        public virtual ObjectValidator<T> BreakIfAnyViolations()
        {
            ValidationNodes.Add(new BreakIfViolationsExists());

            return this;
        }

        public virtual ViolationsContainer Validate(T item)
        {
            var violations = new List<Violation>();

            foreach (var node in ValidationNodes)
            {
                if (node is Requirement)
                    OnHandleRequirement((Requirement)node, item, violations);

                if (node is BreakIfViolationsExists && violations.Any())
                    break;
            }

            return new ViolationsContainer(violations.ToArray());
        }

        protected virtual void OnHandleRequirement(Requirement requirement, T item, IList<Violation> violations)
        {
            var isViolated = requirement.Rule.Invoke(item);
            if (isViolated)
                violations.Add(requirement.ViolationFn.Invoke(item));
        }

        protected interface IValidationNode { }

        protected class Requirement : IValidationNode
        {
            public readonly Func<T, bool> Rule;
            public readonly Func<T, Violation> ViolationFn;

            public Requirement(Func<T, bool> rule, Func<T, Violation> violationFn)
            {
                Rule = rule;
                ViolationFn = violationFn;
            }
        }

        protected class BreakIfViolationsExists : IValidationNode { }
    }
}