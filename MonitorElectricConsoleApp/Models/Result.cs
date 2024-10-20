using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorElectricConsoleApp.Models
{
    public class Result
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// время вызова api-метода
        /// </summary>
        public DateTime CurrentTime { get; set; }

        /// <summary>
        /// первый аргумент
        /// </summary>
        public int FirstArg { get; set; }

        /// <summary>
        /// второй аргумент
        /// </summary>
        public int SecondArg { get; set; }

        /// <summary>
        /// итог
        /// </summary>
        public double Total { get; set; }
    }
}
