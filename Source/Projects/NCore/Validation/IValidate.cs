namespace NCore.Validation
{
    public interface IValidate<in T> where T:class
    {
        ViolationsContainer Validate(T item);
    }
}