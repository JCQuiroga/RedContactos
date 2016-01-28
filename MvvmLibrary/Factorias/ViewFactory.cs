using System;
using System.Collections.Generic;
using Autofac;
using MvvmLibrary.ViewModel.Base;
using Xamarin.Forms;

namespace MvvmLibrary.Factorias
{
    public class ViewFactory : IViewFactory
    {
        readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly IComponentContext _componentContext;

        public ViewFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        public void Register<TViewModel, TView>() where TViewModel : class, IViewModel where TView : Page
        {
            _map[typeof(TViewModel)] = typeof(TView);
        }

        public Page Resolve<TViewModel>(Action<TViewModel> action = null) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            return Resolve<TViewModel>(out viewModel, action);
        }

        public Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> action = null) where TViewModel : class, IViewModel
        {
            viewModel = _componentContext.Resolve<TViewModel>();
            var tipoVista = _map[typeof(TViewModel)];
            var vista = _componentContext.Resolve(tipoVista) as Page;
            if (action != null)
                viewModel.SetState(action);

            vista.BindingContext = viewModel;

            return vista;
        }

        public Page Resolve<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            var tipoVista = _map[typeof(TViewModel)];
            var vista = _componentContext.Resolve(tipoVista) as Page;
            vista.BindingContext = viewModel;
            return vista;
        }
    }
}