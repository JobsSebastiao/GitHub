﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(posicaoNumeroTriangulo("adfasf"));
        }

        public static int posicaoNumeroTriangulo(String palavra) 
        {
            ///array com lista de números triângulo
            int[] numsTriangulo = numerosTriangulo();

            if (numsTriangulo.Contains( valorTexto(palavra)))
            {
                return Array.IndexOf(numsTriangulo, valorTexto(palavra)) + 1;
            }
            else
            {
                return -1;
            }

        }
        /// <summary>
        /// Gera um array preenchido com uma sequência de números Triângulo
        /// </summary>
        /// <returns></returns>
        public static int[] numerosTriangulo()
        {    
            int[] numsTriangulo = null;

            String nums = "";

            for (int i = 1; i < 50; i++ )
            {
                nums += (i * (i + 1) / 2).ToString() + ",";
            }

            string retirarUltimaVirgula = nums.Substring(0,nums.Length-1);

            string[] numsArray = nums.Split(',');

            numsTriangulo = new int[numsArray.Length-1];

            for (int i = 0; i < numsArray.Length-1;i++ )
            {

                numsTriangulo[i] =Convert.ToInt32(numsArray[i]);
            }

            return numsTriangulo;

        }

        /// <summary>
        /// Caucula o valor para o texto informado.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static int valorTexto(String texto)
        {
            int sum = 0;

            char letra = ' ';

            for (int i = 0; i < texto.Length; i++ )
            {
                //captura cada letra
               letra = Convert.ToChar(texto.Substring(i,1).ToUpper().ToString());
                //retirna o seu valor e realiza a soma 
                sum += Convert.ToInt32(retornaValorLetra(letra));
            }

            return sum;
        }

        public static int retornaValorLetra(char letra)
        {

            switch (letra)
            {
                case 'A':
                    return Convert.ToInt32(LETTERS.A);
                case 'B':
                    return Convert.ToInt32(LETTERS.B);
                case 'C':
                    return Convert.ToInt32(LETTERS.C);
                case 'D':
                    return Convert.ToInt32(LETTERS.D);
                case 'E':
                    return Convert.ToInt32(LETTERS.E);
                case 'F':
                    return Convert.ToInt32(LETTERS.F);
                case 'G':
                    return Convert.ToInt32(LETTERS.G);
                case 'H':
                    return Convert.ToInt32(LETTERS.H);
                case 'I':
                    return Convert.ToInt32(LETTERS.I);
                case 'J':
                    return Convert.ToInt32(LETTERS.J);
                case 'K':
                    return Convert.ToInt32(LETTERS.K);
                case 'L':
                    return Convert.ToInt32(LETTERS.L);
                case 'M':
                    return Convert.ToInt32(LETTERS.M);
                case 'N':
                    return Convert.ToInt32(LETTERS.N);
                case 'O':
                    return Convert.ToInt32(LETTERS.O);
                case 'P':
                    return Convert.ToInt32(LETTERS.P);
                case 'Q':
                    return Convert.ToInt32(LETTERS.Q);
                case 'R':
                    return Convert.ToInt32(LETTERS.R);
                case 'S':
                    return Convert.ToInt32(LETTERS.S);
                case 'T':
                    return Convert.ToInt32(LETTERS.T);
                case 'U':
                    return Convert.ToInt32(LETTERS.U);
                case 'V':
                    return Convert.ToInt32(LETTERS.V);
                case 'W':
                    return Convert.ToInt32(LETTERS.W);
                case 'X':
                    return Convert.ToInt32(LETTERS.X);
                case 'Y':
                    return Convert.ToInt32(LETTERS.Y);
                case 'Z':
                    return Convert.ToInt32(LETTERS.Z);
                default:
                    return 0;
            }
        }

        enum LETTERS
        {
        A=1,
        B=2,
        C=3,
        D=4,
        E=5,
        F=6,
        G=7,
        H=8,
        I=9,
        J=10,
        K=11,
        L=12,
        M=13,
        N=14,
        O=15,
        P=16,
        Q=17,
        R=18,
        S=19,
        T=20,
        U=21,
        V=22,
        W=23,
        X=24,
        Y=25,
        Z=26

        }
    }
}
