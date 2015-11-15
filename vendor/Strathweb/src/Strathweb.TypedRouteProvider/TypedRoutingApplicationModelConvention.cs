using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ApplicationModels;
using Microsoft.AspNet.Mvc.Core;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Strathweb.TypedRouteProvider
{
    public class TypedRoutingApplicationModelConvention : IApplicationModelConvention
    {
        internal static readonly Dictionary<TypeInfo, List<TypedRoute>> Routes = new Dictionary<TypeInfo, List<TypedRoute>>();
     
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                if (Routes.ContainsKey(controller.ControllerType))
                {
                    var typedRoutes = Routes[controller.ControllerType];
                    foreach (var route in typedRoutes)
                    {
                        var action = controller.Actions.FirstOrDefault(x => x.ActionMethod == route.ActionMember);
                        if (action != null)
                        {
                            action.AttributeRouteModel = route;
                            foreach (var method in route.HttpMethods)
                            {
                                action.HttpMethods.Add(method);
                            }
                        }
                    }
                }
            }
        }
    }
}
