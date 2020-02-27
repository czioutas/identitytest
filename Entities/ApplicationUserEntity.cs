using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace identityissue
{
    public class ApplicationUserEntity : IdentityUser<int>
    {

        [ForeignKey(nameof(Details))]
        public int? DetailsEntityId { get; set; }

        public DetailsEntity Details { get; set; }

        public ApplicationUserEntity()
        {
        }

        public ApplicationUserEntity(
            int id, string userName, string email, string firstName, string lastName,
            int? DetailsId, DetailsEntity details) : base(userName)
        {
            Id = id;
            Email = email;
            UserName = userName;
            
            DetailsEntityId = DetailsId;
            Details = details;
        }
    }
}