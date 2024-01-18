namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            EstrategiasDelProgramadorContexto oProgramador = new EstrategiasDelProgramadorContexto();

            //Obtenemos diferentes comportamientos usando el método Programar
            oProgramador.Programar(EstrategiasDelProgramadorContexto.Comportamiento.PatronesDiseño);
            oProgramador.Programar(EstrategiasDelProgramadorContexto.Comportamiento.EscribirCodigo);
        }
    }
}