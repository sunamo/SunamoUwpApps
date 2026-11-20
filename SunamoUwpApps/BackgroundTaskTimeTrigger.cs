namespace apps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

    /// <summary>
    /// Represents the background task time trigger type.
    /// </summary>
    public class BackgroundTaskTimeTrigger 
    {
        /// <summary>
        /// The progress.
        /// </summary>
        public string progress = "";
        /// <summary>
        /// The registered.
        /// </summary>
        public bool registered = false;
        /// <summary>
        /// The name.
        /// </summary>
        public string name = "";
        /// <summary>
        /// The entry point.
        /// </summary>
        public string entryPoint = "";

        /// <summary>
        /// Initializes a new instance of the background task time trigger class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="entryPoint">The entry point.</param>
        public BackgroundTaskTimeTrigger(string name, string entryPoint)
        {
            this.name = name;
            this.entryPoint = entryPoint;
        }

        /// <summary>
        /// Register background task.
        /// </summary>
        /// <returns>The register background task result.</returns>
        public  BackgroundTaskRegistration RegisterBackgroundTask()
        {


            var builder = new BackgroundTaskBuilder();

            builder.Name = name;
            builder.TaskEntryPoint = entryPoint;
            builder.SetTrigger(null);
            BackgroundTaskRegistration task = builder.Register();

            registered = true;

            return task;
        }
    }
