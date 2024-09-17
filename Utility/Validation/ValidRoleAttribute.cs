using System.ComponentModel.DataAnnotations;

namespace Dashboard.Utility.Validation
{
    public class ValidRoleAttribute : ValidationAttribute
    {
        private readonly string[] _validRoles = { "Admin", "Sales", "Inventory", "Revenue", "CustomerSupport" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var role = value as string;
            if (role != null && !_validRoles.Contains(role))
            {
                return new ValidationResult("Invalid role");
            }

            return ValidationResult.Success!;
        }
    }
}
