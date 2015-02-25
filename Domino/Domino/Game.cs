using Autofac;
using Domino.Logic.Implements;
using Domino.Logic.Interfaces;

namespace Domino
{
    class Game
    {
        private static IContainer Container { get; set; }
        //private static DrawnGame _drawnGame;
        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<DominoGameRepository>().As<IDominoGameRepository>();
            builder.RegisterType<PlayerRepository>().As<IPlayerRepository>();
            builder.RegisterType<StackRepository>().As<IStackRepository>();
            builder.RegisterType<DrawnGame>().As<IDrawnGame>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IDrawnGame>();
                app.Render(); 
            }
           // _drawnGame.Render();
        }
    }
}
