using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application.Generetor
{
    public static class Generate
    {
        public static string Token()
        {
            string random = string.Empty;

            Enumerable.Range(48, 75).
                Where(i => i < 58 || i > 64 && i < 91 || i > 96).
                OrderBy(i => new Random().Next()).
                ToList().
                ForEach(i => random += Convert.ToChar(i));

            return random.Substring(new Random().Next(0, random.Length - 8) - 8);
        }
    }
}
