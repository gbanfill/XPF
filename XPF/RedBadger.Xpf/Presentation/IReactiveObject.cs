namespace RedBadger.Xpf.Presentation
{
    using System;

    /// <summary>
    ///     Represents an object that participates in the Reactive Property system.
    /// </summary>
    public interface IReactiveObject
    {
        /// <summary>
        ///     Clears the value of a <see cref = "IReactiveProperty">IReactiveProperty</see> on this instance of <see cref = "IReactiveObject">IReactiveObject</see>.
        /// </summary>
        /// <param name = "property">The <see cref = "IReactiveProperty">IReactiveProperty</see> to clear.</param>
        void ClearValue(IReactiveProperty property);

        /// <summary>
        ///     Gets an <see cref = "IObservable{T}">IObservable</see> for a <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see> for this instance of <see cref = "ReactiveObject">ReactiveObject</see>.
        /// </summary>
        /// <typeparam name = "TProperty">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>'s <see cref = "Type">Type</see></typeparam>
        /// <typeparam name = "TOwner">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>'s owner <see cref = "Type">Type</see></typeparam>
        /// <param name = "property">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see> to retrieve a value for.</param>
        /// <returns>An <see cref = "IObservable{T}">IObservable</see> around the <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>.</returns>
        IObservable<TProperty> GetObservable<TProperty, TOwner>(ReactiveProperty<TProperty, TOwner> property)
            where TOwner : class, IReactiveObject;

        /// <summary>
        ///     Gets an <see cref = "IObserver{T}">IObserver</see> for a <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see> for this instance of <see cref = "ReactiveObject">ReactiveObject</see>.
        /// </summary>
        /// <typeparam name = "TProperty">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>'s <see cref = "Type">Type</see></typeparam>
        /// <typeparam name = "TOwner">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>'s owner <see cref = "Type">Type</see></typeparam>
        /// <param name = "property">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see> to retrieve a value for.</param>
        /// <returns>An <see cref = "IObserver{T}">IObserver</see> around the <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>.</returns>
        IObserver<TProperty> GetObserver<TProperty, TOwner>(ReactiveProperty<TProperty, TOwner> property)
            where TOwner : class, IReactiveObject;

        /// <summary>
        ///     Gets the current value of a <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see> on this instance of <see cref = "IReactiveObject">IReactiveObject</see>.
        /// </summary>
        /// <typeparam name = "TProperty">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>'s <see cref = "Type">Type</see></typeparam>
        /// <typeparam name = "TOwner">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>'s owner <see cref = "Type">Type</see></typeparam>
        /// <param name = "property">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see> to retrieve a value for.</param>
        /// <returns>The current value.</returns>
        TProperty GetValue<TProperty, TOwner>(ReactiveProperty<TProperty, TOwner> property)
            where TOwner : class, IReactiveObject;

        /// <summary>
        ///     Sets the value of a <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see> on this instance of <see cref = "IReactiveObject">IReactiveObject</see>.
        /// </summary>
        /// <typeparam name = "TProperty">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>'s <see cref = "Type">Type</see></typeparam>
        /// <typeparam name = "TOwner">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see>'s owner <see cref = "Type">Type</see></typeparam>
        /// <param name = "property">The <see cref = "ReactiveProperty{TProperty,TOwner}">ReactiveProperty</see> to set.</param>
        /// <param name = "newValue">The new value.</param>
        void SetValue<TProperty, TOwner>(ReactiveProperty<TProperty, TOwner> property, TProperty newValue)
            where TOwner : class, IReactiveObject;
    }
}