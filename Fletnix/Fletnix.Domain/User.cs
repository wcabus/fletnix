using System;
using System.ComponentModel.DataAnnotations;

namespace Fletnix.Domain
{
    public class User
    {
        [Required, StringLength(40)]
        public string Id { get; set; }

        [EmailAddress, Required, StringLength(512)]
        public string Email { get; set; }

        [Required, StringLength(128)]
        public string FirstName { get; set; }
        
        [Required, StringLength(128)]
        public string LastName { get; set; }

        public DateTime MemberSince { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}
