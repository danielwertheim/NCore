using NCore.Validation;
using NUnit.Framework;

namespace NCore.Tests.UnitTests.Validation
{
    [TestFixture]
    public class ObjectValidatorTests : UnitTestBase
    {
        [Test]
        public void When_validating_item_with_violations_before_BreakIfAnyViolations_It_returns_only_the_violations_before_it()
        {
            var item = new CreateWorkOrderTemplate();

            var validator = new CreateWorkOrderTemplateValidator();
            var vc = validator.Validate(item);

            Assert.IsFalse(vc.IsValid);
            Assert.AreEqual(2, vc.Violations.Length);
            Assert.AreEqual("Name", vc.Violations[0].Key);
            Assert.AreEqual("Name is missing and must be provided.", vc.Violations[0].Message);
            Assert.AreEqual(Violation.Types.Required, vc.Violations[0].Type);
            Assert.AreEqual("CreatedBy", vc.Violations[1].Key);
            Assert.AreEqual("Created by is missing and must be provided.", vc.Violations[1].Message);
            Assert.AreEqual(Violation.Types.Required, vc.Violations[1].Type);
        }

        [Test]
        public void When_validating_item_with_violations_only_after_BreakIfAnyViolations_It_returns_only_the_violations_after_it()
        {
            var item = new CreateWorkOrderTemplate { Name = "Foo", CreatedBy = "Bar" };

            var validator = new CreateWorkOrderTemplateValidator() { ShouldFailOnNameUniquenessTest = true };
            var vc = validator.Validate(item);

            Assert.IsFalse(vc.IsValid);
            Assert.AreEqual(1, vc.Violations.Length);
            Assert.AreEqual("Name", vc.Violations[0].Key);
            Assert.AreEqual("Name is allready in use and not unique.", vc.Violations[0].Message);
            Assert.AreEqual(Violation.Types.NotUnique, vc.Violations[0].Type);
        }
    }

    internal class CreateWorkOrderTemplateValidator : ObjectValidator<CreateWorkOrderTemplate>
    {
        internal bool ShouldFailOnNameUniquenessTest;

        internal CreateWorkOrderTemplateValidator()
        {
            base
                .FailIf(
                    i => string.IsNullOrWhiteSpace(i.Name),
                    i => new Violation("Name", "Name is missing and must be provided.", Violation.Types.Required))
                .FailIf(
                    i => string.IsNullOrWhiteSpace(i.CreatedBy),
                    i => new Violation("CreatedBy", "Created by is missing and must be provided.", Violation.Types.Required))
                .BreakIfAnyViolations()
                .FailIf(
                    i => ShouldFailOnNameUniquenessTest,
                    i => new Violation("Name", "Name is allready in use and not unique.", Violation.Types.NotUnique));
        }
    }

    internal class CreateWorkOrderTemplate
    {
        public string CreatedBy { get; set; }
        public string Name { get; set; }
    }
}