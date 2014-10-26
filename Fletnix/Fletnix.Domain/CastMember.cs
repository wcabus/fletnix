namespace Fletnix.Domain
{
    public class CastMember
    {
        public virtual MediaStream MediaStream { get; set; }
        public virtual Celebrity Celebrity { get; set; }
        public virtual MediaRole MediaRole { get; set; }
    }
}