namespace WorkerImportadorPIM
{
    public class Domain
    {
        public static class Settings
        {
            public static string ConnectionString { get; set; }

            public static string Token { get; set; }

            public static string DataInicialImportacao { get; set; }

            public static string DataFinalImportacao { get; set; }

            public static int Tempo { get; set; }
        }
    }
}