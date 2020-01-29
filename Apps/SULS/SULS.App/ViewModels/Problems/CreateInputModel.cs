namespace SULS.App.ViewModels.Problems
{
    using SIS.MvcFramework.Attributes.Validation;

    public class CreateInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Name should be between 5 and 20 symbols")]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, "Points should be between 50 and 300")]
        public int Points { get; set; }
    }
}