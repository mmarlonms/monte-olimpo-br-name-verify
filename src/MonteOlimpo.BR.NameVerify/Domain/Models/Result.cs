using System.Collections.Generic;

namespace MonteOlimpo.BR.NameVerify.Domain.Models
{
    public class Result
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Localidade { get; set; }

        public List<Res> Res { get; set; }

        public Result()
        {
            this.Res = new List<Res>();
        }
    }
}