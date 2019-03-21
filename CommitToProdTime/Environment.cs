using System;

namespace CommitToProdTime
{
    public class Environment
    {
        

        public string enviroment { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }



        public override bool Equals(object obj)
        {
            var s = obj.ToString();
            return s.Equals(enviroment);
        }

    }
}