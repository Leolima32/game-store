using GameStore.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameStore.Domain.Entities
{
    public class User: BaseEntity
    {
        public User(string userId, string name, DateTime birthDate)
        {
            UserId = userId;
            Name = name;
            BirthDate = birthDate;
        }

        [Key]
        public string UserId { get; private set; }
        public string Name { get; private set; }
        public string AccessKey { get; private set; }
        public DateTime BirthDate { get; private set; }
        public IEnumerable<Genre> GenreInterests{ get; private set; }
        public IEnumerable<Game> WishsList { get; private set; }

        public bool IsVipMember()
        {
            return DateTime.Now.Year - this.CreatedDate.Year >= 5;
        }
    }
}
