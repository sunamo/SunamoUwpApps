namespace apps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

    /// <summary>
    /// Represents the consts type.
    /// </summary>
    public static class Consts
    {
        /// <summary>
        /// The dialog size.
        /// </summary>
        public static readonly Size dialogSize = new Size(1024, 256);

        /// <summary>
        /// Inicializuje W i H velikostí double.MaxValue
        /// </summary>
        public static readonly Size maxSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
        /// <summary>
        /// The actual size.
        /// </summary>
        public static Size actualSize = new Size(1024, 768);
        /// <summary>
        /// The http localhost slash constant.
        /// </summary>
        public const string HttpLocalhostSlash = "http://sunamo.net/";
        /// <summary>
        /// The http sunamo cz slash constant.
        /// </summary>
        public const string HttpSunamoCzSlash = "http://www.sunamo.cz/";
    }
