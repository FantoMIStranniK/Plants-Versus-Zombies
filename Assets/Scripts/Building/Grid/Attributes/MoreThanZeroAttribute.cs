#if UNITY_EDITOR
using System;
using Sirenix.OdinInspector.Editor.Validation;

[assembly: RegisterValidator(typeof(PVZ.Grid.MoreThanZeroValidator))]

namespace PVZ.Grid
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MoreThanZeroAttribute : Attribute { }

    public class MoreThanZeroValidator : AttributeValidator<MoreThanZeroAttribute, int>
    {
        protected override void Validate(ValidationResult result)
        {
            if (this.ValueEntry.SmartValue <= 0)
            {
                result.Message = "This value cannot be less or equal zero";
                result.ResultType = ValidationResultType.Error;
            }
        }
    }
}
#endif