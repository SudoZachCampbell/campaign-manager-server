using DDCatalogue.Model.Auth;

namespace DDCatalogue.Model
{
    public class Owned : Base, IOwned
    {
        public Account Owner { get; set; }
    }
}