namespace FrontTest.Validation
{
    public static class AgeValidation
    {
        public static int UserAge(DateTime dob)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - dob.Year;
            if (dob > now.AddYears(-age)) age--;

            return age;
        }
    }
}
