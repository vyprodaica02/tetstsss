using LoginWithGoogAutheries.common;

namespace LoginWithGoogAutheries.Entity
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string email { get; set; }
    }
}
