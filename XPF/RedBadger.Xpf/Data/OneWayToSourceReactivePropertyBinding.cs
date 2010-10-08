﻿namespace RedBadger.Xpf.Data
{
    internal class OneWayToSourceReactivePropertyBinding<T, TSource> : OneWayToSourceBinding<T>
        where TSource : class, IReactiveObject
    {
        private readonly ReactiveProperty<T> reactiveProperty;

        public OneWayToSourceReactivePropertyBinding(IReactiveObject source, ReactiveProperty<T> reactiveProperty)
            : base(source.GetObserver<T, TSource>(reactiveProperty))
        {
        }

        public OneWayToSourceReactivePropertyBinding(ReactiveProperty<T> reactiveProperty)
            : base(BindingResolutionMode.Deferred)
        {
            this.reactiveProperty = reactiveProperty;
        }

        public override void Resolve(object dataContext)
        {
            var reactiveObject = dataContext as ReactiveObject;
            if (reactiveObject != null)
            {
                this.TargetObserver = reactiveObject.GetObserver<T, TSource>(this.reactiveProperty);
                this.OnNext(this.InitialValue);
            }
        }
    }
}