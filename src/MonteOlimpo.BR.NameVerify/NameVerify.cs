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
            bool firstName = true;
            decimal round = 0;
            decimal percent = 0;

            foreach (var n in names)
            {
                var result = ibgeAdapter.Find(n);

                if (firstName)
                {
                    if (result.Count > 0)
                    {
                        var frequency = result.SelectMany(y => y.Res).Sum(x => x.Frequencia);
                        percent += FisrtNameRound(frequency);
                    }

                    firstName = false;
                }
                else //Sobrenome
                {
                    if (result.Count > 0)
                    {
                        round += 100;
                    }
                    else
                    {
                        round += 90;
                    }
                }
            }

            var secondNameRound = (round * 50) / ((names.Length-1) * 100);

            return percent + secondNameRound;
        }

        private static decimal FisrtNameRound(int frequency)
        {
            var round = 0;

            if (frequency > 10000)
            {
                round = 50;
            }
            else if (frequency > 50000)
            {
                round = 45;
            }
            else if (frequency > 25000)
            {
                round = 40;
            }
            else
            {
                round = 35;
            }

            return round;
        }

        private static string[] SplitName(string name)
        {
            var names = name.Split(" ");

            return names.Where(x => x.Length > 3).ToArray();
        }
    }
}