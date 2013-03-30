using System;
using System.Collections;
using System.Collections.Generic;

namespace NCore.Validation
{
    [Serializable]
    public class ViolationsContainer : IEnumerable<Violation>
    {
        public Violation[] Violations { get; private set; }

        public bool IsValid
        {
            get { return Violations.Length == 0; }
        }

        public ViolationsContainer(params Violation[] violations)
        {
            Violations = violations ?? new Violation[0];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Violation> GetEnumerator()
        {
            return ((IEnumerable<Violation>)Violations).GetEnumerator();
        }
    }
}