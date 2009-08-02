namespace Apache.Shiro.Authz
{
    public interface IPermission
    {
        bool Implies(IPermission permission);
    }
}
