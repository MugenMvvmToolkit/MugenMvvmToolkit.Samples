namespace Binding.Portable.Interfaces
{
    public interface ILocalizationManager
    {
        void Initilaize();

        void ChangeCulture(string culture);
    }
}