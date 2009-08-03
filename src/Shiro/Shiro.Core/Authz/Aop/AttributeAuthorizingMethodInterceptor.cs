using System.Collections.Generic;

using Apache.Shiro.Aop;

namespace Apache.Shiro.Authz.Aop
{
    public class AttributeAuthorizingMethodInterceptor : AuthorizingMethodInterceptorSupport
    {
        public AttributeAuthorizingMethodInterceptor()
        {
            MethodInterceptors = new IAuthorizingMethodInterceptor[]
            {
                new RolesAttributeMethodInterceptor(),
                new PermissionsAttributeMethodInterceptor(),
                new AuthenticatedAttributeMethodInterceptor(),
                new UserAttributeMethodInterceptor(),
                new GuestAttributeMethodInterceptor()
            };
        }

        public ICollection<IAuthorizingMethodInterceptor> MethodInterceptors { get; set; }

        public override void AssertAuthorized(IMethodInvocation invocation)
        {
            if (MethodInterceptors == null || MethodInterceptors.Count == 0)
            {
                return;
            }

            foreach (var interceptor in MethodInterceptors)
            {
                interceptor.AssertAuthorized(invocation);
            }
        }
    }
}