using Xamarin.Forms;

namespace MvvmLibrary.Factorias
{
    public interface IPage
    {
        INavigation Navigation { get; }
    }
}