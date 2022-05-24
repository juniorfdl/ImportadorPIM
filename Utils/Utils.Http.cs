// Decompiled with JetBrains decompiler
// Type: WorkerImportadorPIM.Utils.Utils_Http
// Assembly: WorkerImportadorPIM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B09D98CC-7CFB-4CD4-A057-1FEEEA06B450
// Assembly location: C:\Temp\ImportacaoPim\ImportacaoPim\WorkerImportadorPIM\WorkerImportadorPIM.dll

using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerImportadorPIM.Utils
{
  public class Utils_Http
  {
    public static async Task<TValue> Get<TValue>(
      string uri,
      CancellationToken stoppingToken,
      ILogger logger,
      IHttpClientFactory clientFactory)
    {
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
      HttpClient client = clientFactory.CreateClient();
      HttpResponseMessage response = await client.SendAsync(request, stoppingToken);
      if (response.IsSuccessStatusCode)
      {
        Stream stream = await response.Content.ReadAsStreamAsync();
        TValue obj = await JsonSerializer.DeserializeAsync<TValue>(stream, cancellationToken: stoppingToken);
        return obj;
      }
      logger.LogInformation(string.Format("Status: {0} - {1}", (object) response.StatusCode, (object) response.RequestMessage));
      return default (TValue);
    }

    public static string GetURI(string url)
    {
      string inicialImportacao = DateTime.Today.ToString("yyyy-MM-dd");
      string dataFinalImportacao = DateTime.Today.ToString("yyyy-MM-dd");
      if (Domain.Settings.DataInicialImportacao != null)
        inicialImportacao = Domain.Settings.DataInicialImportacao;
      if (Domain.Settings.DataFinalImportacao != null)
        dataFinalImportacao = Domain.Settings.DataFinalImportacao;
      return url + "&access_token=" + Domain.Settings.Token + "&data_cadastro_de=" + inicialImportacao + "&data_cadastro_ate=" + dataFinalImportacao;
    }
  }
}
