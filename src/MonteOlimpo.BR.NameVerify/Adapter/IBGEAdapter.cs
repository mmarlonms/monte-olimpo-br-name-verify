using MonteOlimpo.BR.NameVerify.Adapter.Client;
using MonteOlimpo.BR.NameVerify.Domain.Models;
using Refit;
using System;
using System.Collections.Generic;

namespace MonteOlimpo.BR.NameVerify.Adapter
{
    public class IbgeAdapter
    {
        private readonly IIbgeApiClient ibgeAPI;

        public IbgeAdapter(Uri urlBase)
        {
            this.ibgeAPI = RestService.For<IIbgeApiClient>(urlBase.ToString());
        }

        public List<Result> Find(string name)
        {
            return this.ibgeAPI.GetNameResult(name).Result;
        }
    }
}