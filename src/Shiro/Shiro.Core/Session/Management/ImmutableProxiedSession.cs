namespace Apache.Shiro.Session.Management
{
    public class ImmutableProxiedSession : ProxiedSession
    {
        public ImmutableProxiedSession(ISession session)
            : base(session)
        {

        }

        public override long Timeout
        {
            set
            {
                throw new InvalidSessionException(Properties.Resources.ImmutableSessionMessage);
            }
        }

        public override void Stop()
        {
            throw new InvalidSessionException(Properties.Resources.ImmutableSessionMessage);
        }

        public override void Touch()
        {
            throw new InvalidSessionException(Properties.Resources.ImmutableSessionMessage);
        }
    }
}
