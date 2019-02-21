using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;

namespace GameHUB.Business.Twitch.ScheduleJob
{
    [ScheduledPlugIn(DisplayName = "Update Twitch Games")]
    public class TwitchSceduledJob : ScheduledJobBase
    {
        private bool _stopSignaled;

        public TwitchSceduledJob()
        {
            IsStoppable = true;
        }
        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }
        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));
            
            TwitchUtils.GamesList = new TwitchDataFetcher().TopGames();
            
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }

            return "Succesfully updated twitch games list.";
        }
    }
}
