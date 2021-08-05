using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSC343_calculator.ViewModels
{
    public class TopViewModel : Screen
    {

#region Properties to be displayed

        private string _closureAttributes = "ABCDEFGH";
        public string ClosureAttributes
        {
            get { return _closureAttributes; }
            set {
                _closureAttributes = value;
                // Since ClosureResult depends on ClosureAttributes, make sure to call NotifyOfPropertyChange
                // Otherwise the value of ClosureResult will not update
                NotifyOfPropertyChange(() => ClosureResult1);
                NotifyOfPropertyChange(() => ClosureResult2);
                NotifyOfPropertyChange(() => ClosureResult3);
            }
        }

        private string _closureFDs = "ABF->G BC->H BC->E BC->G BE->G BE->H";
        public string ClosureFDs
        {
            get { return _closureFDs; }
            set {
                _closureFDs = value;
                // Since ClosureResult depends on ClosureFDs, make sure to call NotifyOfPropertyChange
                // Otherwise the value of ClosureResult will not update
                NotifyOfPropertyChange(() => ClosureResult1);
                NotifyOfPropertyChange(() => ClosureResult2);
                NotifyOfPropertyChange(() => ClosureResult3);
            }
        }

        private string _closureTarget1 = "";
        public string ClosureTarget1
        {
            get { return _closureTarget1; }
            set {
                _closureTarget1 = value;
                // Since ClosureResult1 depends on ClosureTarget1, make sure to call NotifyOfPropertyChange
                // Otherwise the value of ClosureResult will not update
                NotifyOfPropertyChange(() => ClosureResult1);
            }
        }

        // Note how this property is not tied to an underlying field (ie. no private string _closureResult1)
        // This property calculates the result inside the getter every time the value of the property is needed
        public string ClosureResult1
        {
            get
            {
                string result = Closure(ClosureFDs, ClosureTarget1);
                if (result != "N/A")
                {
                    bool superkey = ToAttributeSet(result).SetEquals(ToAttributeSet(ClosureAttributes));
                    return $"{ClosureTarget1}+ = {result}{(superkey ? " (superkey!)" : "")}";
                }
                return "N/A";
            }
        }

        private string _closureTarget2 = "";
        public string ClosureTarget2
        {
            get { return _closureTarget2; }
            set {
                _closureTarget2 = value;
                // Since ClosureResult2 depends on ClosureTarget2, make sure to call NotifyOfPropertyChange
                // Otherwise the value of ClosureResult will not update
                NotifyOfPropertyChange(() => ClosureResult2);
            }
        }

        // Note how this property is not tied to an underlying field (ie. no private string _closureResult2)
        // This property calculates the result inside the getter every time the value of the property is needed
        public string ClosureResult2
        {
            get
            {
                string result = Closure(ClosureFDs, ClosureTarget2);
                if (result != "N/A")
                {
                    bool superkey = ToAttributeSet(result).SetEquals(ToAttributeSet(ClosureAttributes));
                    return $"{ClosureTarget2}+ = {result}{(superkey ? " (superkey!)" : "")}";
                }
                return "N/A";
            }
        }

        private string _closureTarget3 = "";
        public string ClosureTarget3
        {
            get { return _closureTarget3; }
            set {
                _closureTarget3 = value;
                // Since ClosureResult3 depends on ClosureTarget3, make sure to call NotifyOfPropertyChange
                // Otherwise the value of ClosureResult will not update
                NotifyOfPropertyChange(() => ClosureResult3);
            }
        }

        // Note how this property is not tied to an underlying field (ie. no private string _closureResult3)
        // This property calculates the result inside the getter every time the value of the property is needed
        public string ClosureResult3
        {
            get
            {
                string result = Closure(ClosureFDs, ClosureTarget3);
                if (result != "N/A")
                {
                    bool superkey = ToAttributeSet(result).SetEquals(ToAttributeSet(ClosureAttributes));
                    return $"{ClosureTarget3}+ = {result}{(superkey ? " (superkey!)" : "")}";
                }
                return "N/A";
            }
        }

        private string _closureTarget4 = "";
        public string ClosureTarget4
        {
            get { return _closureTarget4; }
            set {
                _closureTarget4 = value;
                NotifyOfPropertyChange(() => ClosureResult4);
            }
        }

        public string ClosureResult4
        {
            get
            {
                string result = Closure(ClosureFDs, ClosureTarget4);
                if (result != "N/A")
                {
                    bool superkey = ToAttributeSet(result).SetEquals(ToAttributeSet(ClosureAttributes));
                    return $"{ClosureTarget4}+ = {result}{(superkey ? " (superkey!)" : "")}";
                }
                return result;
            }
        }

        public string MinLHS
        {
            get {
                try
                {
                    // Without FD
                    Regex rx = new Regex(@"(\w+)->(\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    var matches = rx.Matches(WithoutFD);
                    if (matches.Count == 0)
                        return "N/A";
                    FD without = new FD(matches[0].Groups[1].Value, matches[0].Groups[2].Value);
                    return new string(without.LHS.ToArray());
                }
                catch
                {
                    return "";
                }
            }
        }

        private string _withoutFD;
        public string WithoutFD
        {
            get { return _withoutFD; }
            set {
                _withoutFD = value;
                NotifyOfPropertyChange(() => MinLHS);
                NotifyOfPropertyChange(() => ClosureWithoutFD);
            }
        }

        public string ClosureWithoutFD
        {
            get {
                if (MinLHS == "" || WithoutFD == "")
                    return "N/A";
                
                string result = Closure(ClosureFDs.Replace(WithoutFD, ""), MinLHS);
                if (result != "N/A")
                {
                    return $"{MinLHS}+ = {result}";
                }
                return result;
            }
        }
#endregion

        HashSet<char> ToAttributeSet(string s)
        {
            return new HashSet<char>(s.ToCharArray());
        }

        struct FD
        {
            public HashSet<char> LHS;
            public HashSet<char> RHS;
            public FD(string l, string r)
            {
                LHS = new HashSet<char>(l.ToCharArray());
                RHS = new HashSet<char>(r.ToCharArray());
            }
            public static bool operator ==(FD a, FD b)
            {
                return a.LHS.SetEquals(b.LHS) && a.RHS.SetEquals(b.RHS);
            }
            public static bool operator !=(FD a, FD b)
            {
                return !(a.LHS.SetEquals(b.LHS) && a.RHS.SetEquals(b.RHS));
            }
        }

        string Closure(string FDs, string target)
        {
            if (target == null || target == "")
                return "N/A";
            try
            {
                Regex rx = new Regex(@"(\w+)->(\w+)",
                  RegexOptions.Compiled | RegexOptions.IgnoreCase);
                MatchCollection matches = rx.Matches(FDs);
                var S = matches.Cast<Match>().Select((match) => new FD(match.Groups[1].Value, match.Groups[2].Value)).ToList(); // FDs
                if (S.Count() == 0)
                    return "N/A";

                HashSet<char> closure = new HashSet<char>(target.ToCharArray()); // initialize closure to target
                bool keepGoing = true;
                while (keepGoing)
                {
                    keepGoing = false;
                    foreach (FD fd in S)
                    {
                        // if LHS is in closure, add RHS to closure
                        if (fd.LHS.IsSubsetOf(closure) && !fd.RHS.IsSubsetOf(closure))
                        {
                            foreach(char rhs in fd.RHS)
                                closure.Add(rhs);
                            keepGoing = true;
                        }
                    }
                }
                return new string(closure.ToArray());
            }
            catch
            {
                return "N/A";
            }
        }
    }
}
