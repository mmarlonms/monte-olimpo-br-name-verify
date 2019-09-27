using MonteOlimpo.BR.NameVerify.Adapter;
using MonteOlimpo.BR.NameVerify.Properties;
using System;
using System.Linq;

namespace MonteOlimpo.BR.NameVerify
{
    public static class NameVerify
    {
        private static readonly IbgeAdapter ibgeAdapter = new IbgeAdapter(new Uri(Resources.ResourceManager.GetString("UrlBase")));

        public static decimal Verify(string name)
        {
            var names = SplitName(name);

            decimal round = 0;

            foreach (var n in names)
            {
                var result = ibgeAdapter.Find(n);

                if (result.Count > 0)
                {
                    var frequency = result.SelectMany(y => y.Res).Sum(x => x.Frequencia);

                    if (frequency > 10000)
                    {
                        round += 100;
                    }
                    else if (frequency > 50000)
                    {
                        round += 90;
                    }
                    else if (frequency > 25000)
                    {
                        round += 80;
                    }
                    else
                    {
                        round += 70;
                    }
                }
            }
                                 
            return round/names.Length;
        }

        private static string[] SplitName(string name)
        {
            var names = name.Split(" ");

            return names.Where(x => x.Length > 3).ToArray();
        }
    }
}