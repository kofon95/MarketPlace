using DAL.Functions;

namespace DAL
{
    public class FunctionsManager
    {
        private FunctionsManager()
        { }


        public IFunctions Functions => new SqlFunctions();


        public static FunctionsManager Manager { get; }

        static FunctionsManager()
        {
            Manager = new FunctionsManager();
        }
    }
}
