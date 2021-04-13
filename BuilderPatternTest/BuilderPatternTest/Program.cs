using System;

namespace BuilderPatternTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var myChurchill = new Churchill()
                .WithIceCream("VANILLA")
                //.WithSyrop("PURPLE")
                .OfSize(Churchill.Size.MEDIUM);

            Console.WriteLine($"{myChurchill.GetSize} {myChurchill.GetIceCream} {myChurchill.GetSyrop}");
        }
    }

    public class Churchill 
    {
        public enum Size { SMALL=0, MEDIUM=1, BIG =2 };

        private string _iceCream = string.Empty; //default is no iceCream
        private string _syrop = "RED";
        private Size _size = Size.SMALL;

        public string GetIceCream { get => _iceCream; }
        public string GetSyrop { get => _syrop;}
        public Size GetSize { get => _size;}
        


        //separte the constructors of an object from it, using methods returning self instances instead

        public Churchill WithIceCream(string iceCreamFlavor) 
        {
            _iceCream = iceCreamFlavor;
            return this;
        }

        public Churchill WithSyrop(string syropFlavor)
        {
            _syrop = syropFlavor;
            return this;
        }

        public Churchill OfSize(Size size)
        {
            _size = size;
            return this;
        }


        public Churchill Build()
        {
            return this;
        }
    }
}
