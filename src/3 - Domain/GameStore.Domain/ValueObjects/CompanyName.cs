using System;
using Flunt.Validations;
using GameStore.Domain.Entities.Common;

namespace GameStore.Domain.ValueObjects
{
    public class CompanyName : ValueObject
    {
        public CompanyName(string fantasyName)
        {
            FantasyName = fantasyName;
        }

        public string FantasyName { get; private set; }
        public string SocialName { get; private set; }

        public void AddSocialName(string socialName) {
            SocialName = socialName;
        }
    }
}
