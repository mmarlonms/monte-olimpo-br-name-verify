using MonteOlimpo.BR.NameVerify.Domain.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonteOlimpo.BR.NameVerify.Adapter.Client
{
    public interface IIbgeApiClient
    {
        [Get("/censos/nomes/{nome}")]
        Task<List<Result>> GetNameResult(string nome);
    }
}