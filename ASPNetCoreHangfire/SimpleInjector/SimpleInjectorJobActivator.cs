using Hangfire;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;

namespace ASPNetCoreHangfire.SimpleInjector
{
    public class SimpleInjectorJobActivator : JobActivator
    {
        public Container Container { get; }
        public ScopedLifestyle Lifestyle { get; }

        public SimpleInjectorJobActivator(Container container)
        {
            Lifestyle = new AsyncScopedLifestyle();
            container.Options.DefaultScopedLifestyle = Lifestyle;

            Container = container;
        }

        public override object ActivateJob(Type type)
        {
            return Container.GetInstance(type);
        }

        public override JobActivatorScope BeginScope(JobActivatorContext c)
        {
            return new SimpleInjectorScope(Container, Lifestyle.GetCurrentScope(Container));
        }

        private sealed class SimpleInjectorScope : JobActivatorScope
        {
            private readonly Container _container;
            private readonly Scope _scope;

            public SimpleInjectorScope(Container container, Scope scope)
            {
                _container = container;
                _scope = scope;
            }

            public override object Resolve(Type type)
            {
                return _container.GetInstance(type);
            }

            public override void DisposeScope()
            {
                if (_scope != null)
                {
                    _scope.Dispose();
                }
            }
        }
    }
}
