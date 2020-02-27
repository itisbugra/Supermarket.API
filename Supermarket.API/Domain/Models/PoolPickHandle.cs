using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models
{
    public class PoolPickHandle
    {
        /// <summary>
        /// The unique identifier of the handle.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The identifier of the user picking the question from the pool.
        /// </summary>
        public int PickerId { get; set; }

        /// <summary>
        /// The question being picked from the pool.
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// The number of seconds question is available for.
        /// </summary>
        public int AvailableFor { get; set; }

        /// <summary>
        /// The timestamp showing when the handle was created.
        /// </summary>
        public DateTime InsertedAt { get; set; }

        public User Picker { get; set; }

        public Question Question { get; set; }

        /// <summary>
        /// The timestamp when question is available until.
        /// </summary>
        public DateTime AvailableUntil {
            get => InsertedAt.AddSeconds(AvailableFor);
        }

        /// <summary>
        /// Shows if handle is timed out.
        /// </summary>
        public bool IsTimedOut {
            get => AvailableUntil > DateTime.Now;
        }
    }
}
