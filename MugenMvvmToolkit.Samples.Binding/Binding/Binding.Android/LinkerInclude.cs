using System.Linq;

namespace Binding.Droid
{
    public static class LinkerInclude
    {
        static LinkerInclude()
        {
            "test".Count(c => c == 'a');
        }
    }
}