using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordDiffer;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var textA = @"zero one two three four fyve six seven";
            var textB = @"zero one too treee four five six seven eight nine";

            var result = DiffEngine.Process(ref textA, ref textB);

            var html =
                    $@"
                    <html>
                     <head>
                      <style>
                        ins{{background-color: #d5ffba;}}
                        del{{background-color: #ffc6d5;}}
                      </style>
                     </head>
                      <body>
                        {result}
                      </body>
                    </html>
                    ";

            File.WriteAllText(@"test.html", html);
            Process.Start("test.html");
        }
    }
}
