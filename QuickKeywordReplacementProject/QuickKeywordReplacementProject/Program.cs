using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKeywordReplacementProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        static string ReplaceKeyWord(string oldKey, string newKey, string s)
        {
            //e.g. eeeee
            string AllLowerOldKey = oldKey.ToLower();
            //e.g. Eeeee
            string CamelOldKey = oldKey.Substring(0, 1).ToUpper() + oldKey.Substring(1).ToLower();
            //e.g. EEEEE
            string AllUpperOldKey = oldKey.ToUpper();
            string AllLowerNewKey = newKey.ToLower();
            string CamelNewKey = newKey.Substring(0, 1).ToUpper() + newKey.Substring(1).ToLower();
            string AllUpperNewKey = newKey.ToUpper();

            return s.Replace(AllLowerOldKey, AllLowerNewKey)
                    .Replace(AllUpperOldKey, AllUpperNewKey)
                    .Replace(CamelOldKey, CamelNewKey);
        }
    }
}
