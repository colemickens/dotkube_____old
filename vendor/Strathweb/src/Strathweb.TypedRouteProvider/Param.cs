using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Core;
using System.Collections.Generic;
using System.Reflection;

namespace Strathweb.TypedRouteProvider
{
	public static class Param<TValue>
	{
	    public static TValue Any
	    {
	        get { return default(TValue); }
	    }
	}
}
