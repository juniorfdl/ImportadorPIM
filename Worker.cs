using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WorkerImportadorPIM.Controllers;

namespace WorkerImportadorPIM
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public Worker(
            ILogger<Worker> logger,
            IHttpClientFactory clientFactory,
            IConfiguration configuration)
        {
            this._logger = logger;
            this._clientFactory = clientFactory;
            Domain.Settings.ConnectionString = configuration.GetConnectionString("DefaultConnection");
            Domain.Settings.Token = configuration.GetConnectionString("Token");
            Domain.Settings.Tempo = Convert.ToInt32(configuration.GetConnectionString("Tempo"));
            Domain.Settings.DataInicialImportacao = configuration.GetConnectionString("DataInicialImportacao");
            Domain.Settings.DataFinalImportacao = configuration.GetConnectionString("DataFinalImportacao");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this._logger.LogInformation("Importador PIM iniciando.");
            while (!stoppingToken.IsCancellationRequested)
            {
                this._logger.LogInformation("Worker running at: {time}", (object) DateTimeOffset.Now);
                try
                {
                    ProcessarImportacao proc = new ProcessarImportacao(this._clientFactory, (ILogger) this._logger, stoppingToken);
                    await proc.ExecuteAsync();
                    proc = (ProcessarImportacao) null;
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex.Message);
                }
                await Task.Delay(Domain.Settings.Tempo, stoppingToken);
            }
            this._logger.LogInformation("Importador PIM está parando.");
        }
    }
}