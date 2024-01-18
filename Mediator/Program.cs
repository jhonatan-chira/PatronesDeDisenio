using Mediator;
using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediador = new Mediator();

            IColleague oPepe = new User(mediador);
            IColleague oAdmin = new UserAdmin(mediador);
            IColleague oAdmin2 = new UserAdmin(mediador);

            mediador.Add(oPepe);
            mediador.Add(oAdmin);
            mediador.Add(oAdmin2);

            oPepe.Communicate("Oye admin tengo un problema");
        }
    }
}