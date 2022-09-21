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
            string[] oldKeySet = { "level" };
            string[] newKeySet = { "device", "channel" };
            string s = ReplaceKeyWord(oldKeySet, newKeySet,
                "public"
                );
            Console.WriteLine(s);

            Console.ReadKey();
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

        static string ReplaceKeyWord(string[] oldKeySet, string[] newKeySet, string s)
        {
            //e.g. eeeee
            StringBuilder AllLowerOldKeyBuilder = new StringBuilder();
            //e.g. EEEEE
            StringBuilder AllUpperOldKeyBuilder = new StringBuilder();
            //e.g. EeeeeEeeee
            StringBuilder CamelOldKeyBuilder = new StringBuilder();
            StringBuilder AllLowerNewKeyBuilder = new StringBuilder();
            StringBuilder AllUpperNewKeyBuilder = new StringBuilder();
            StringBuilder CamelNewKeyBuilder = new StringBuilder();

            foreach (string oldKey in oldKeySet)
            {
                AllLowerOldKeyBuilder.Append(oldKey.ToLower());
                AllUpperOldKeyBuilder.Append(oldKey.ToUpper());
                CamelOldKeyBuilder.Append(oldKey.Substring(0, 1).ToUpper());
                CamelOldKeyBuilder.Append(oldKey.Substring(1).ToLower());
            }

            foreach (string newKey in newKeySet)
            {
                AllLowerNewKeyBuilder.Append(newKey.ToLower());
                AllUpperNewKeyBuilder.Append(newKey.ToUpper());
                CamelNewKeyBuilder.Append(newKey.Substring(0, 1).ToUpper());
                CamelNewKeyBuilder.Append(newKey.Substring(1).ToLower());
            }

            return s.Replace(AllLowerOldKeyBuilder.ToString(), AllLowerNewKeyBuilder.ToString())
                    .Replace(AllUpperOldKeyBuilder.ToString(), AllUpperNewKeyBuilder.ToString())
                    .Replace(CamelOldKeyBuilder.ToString(), CamelNewKeyBuilder.ToString());
        }
    }
}
