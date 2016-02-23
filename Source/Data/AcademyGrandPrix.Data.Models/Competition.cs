namespace AcademyGrandPrix.Data.Models
{
    using System;

    using System.Collections.Generic;

    using AcademyGrandPrix.Data.Common.Models;

    public class Competition : BaseModel<int>
    {
        private ICollection<User> contesters;

        public Competition()
        {
            this.contesters = new HashSet<User>();
        }

        public int TrackId { get; set; }

        public virtual Track Track { get; set; }

        public bool IsPublic { get; set; }

        public int LapsCount { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
        
        public virtual ICollection<User> Contesters
        {
            get { return this.contesters; }
            set { this.contesters = value; }
        }
    }
}
