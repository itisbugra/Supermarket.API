using System;

namespace Supermarket.API.Domain.Models
{
    public class Context
    {
        public int Id { get; set; }

        /// <summary>
        /// Default name of the context. Will be shown if no localizable entry 
        /// is available to the client.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Default description of the context, supports CommonMark to enable 
        /// rich text. Will be shown if no localizable entry is available to the client.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Short name for the context in native locale.
        /// 
        /// Currently, this field does not enforce any casing, however forward changes
        /// in the API may do so.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Specifies visibility of the context to the platform users.
        /// </summary>
        public bool IsVisible { get; set; }

        public DateTime InsertedAt { get; set; }
    }
}
