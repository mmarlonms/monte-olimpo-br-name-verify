﻿using System;

namespace MonteOlimpo.BR.NameVerify.Console
{
    public static class Program
    {
        static void Main(string[] args)
        {

            do
            {
                System.Console.WriteLine("Digite o nome");
                string nome = System.Console.ReadLine();
                System.Console.WriteLine("O nome " + nome + " possui " + NameVerify.Verify(nome) + "% de confiabilidade");
             
            } while (true);

      
        }
    }
}
