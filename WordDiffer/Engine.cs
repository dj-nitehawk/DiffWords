using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordDiffer
{
    public static class DiffEngine
    {
        private static Regex r = new Regex(@"(?<=[\s])", RegexOptions.Compiled);
        private static string delOpen = "<del style=\"background-color:rgb(255,224,224);text-decoration:line-through;\">";
        private static string insOpen = "<ins style=\"text-decoration:none;background-color:rgb(224,255,224);\">";
        private static string delClose = "</del>";
        private static string insClose = "</ins>";


        public static string Process(ref string TextA, ref string TextB)
        {
            var A = r.Split(TextA);
            var B = r.Split(TextB);
            var max = Math.Max(A.Count(), B.Count());
            var sbDel = new StringBuilder(delOpen);
            var sbIns = new StringBuilder(insOpen);
            var sbOutput = new StringBuilder();
            var aCurr = string.Empty;
            var bCurr = string.Empty;
            var aNext = string.Empty;
            var bNext = string.Empty;

            for (int i = 0; i < max; i++)
            {
                aCurr = (i > A.Count() - 1) ? string.Empty : A[i];
                bCurr = (i > B.Count() - 1) ? string.Empty : B[i];
                aNext = (i > A.Count() - 2) ? string.Empty : A[i + 1];
                bNext = (i > B.Count() - 2) ? string.Empty : B[i + 1];

                if (aCurr.TrimEnd(' ') == bCurr.TrimEnd(' '))
                {
                    sbOutput.Append(aCurr);
                }
                else
                {
                    if (aNext.TrimEnd(' ') != bNext.TrimEnd(' '))
                    {
                        sbDel.Append(aCurr);
                        sbIns.Append(bCurr);
                    }
                    else
                    {
                        sbDel.Append(aCurr);
                        sbIns.Append(bCurr);
                        sbOutput
                            .Append(sbDel.ToString())
                            .Append(delClose)
                            .Append(sbIns.ToString())
                            .Append(insClose);
                        sbDel.Clear().Append(delOpen);
                        sbIns.Clear().Append(insOpen);
                    }
                }
            }

            A = null;
            B = null;
            sbDel = null;
            sbIns = null;
            return sbOutput.ToString();

        }
    }
}
