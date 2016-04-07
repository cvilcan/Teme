// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructuremapConfigurationManager.AppSettings["BasePath"].cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using ConfigurationManager.AppSettings["BasePath"].DependencyResolution;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(ConfigurationManager.AppSettings["BasePath"].App_Start.StructuremapConfigurationManager.AppSettings["BasePath"]), "Start")]

namespace ConfigurationManager.AppSettings["BasePath"].App_Start {
    public static class StructuremapConfigurationManager.AppSettings["BasePath"] {
        public static void Start() {
			var container = StructuremapMvc.StructureMapDependencyScope.Container;
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapConfigurationManager.AppSettings["BasePath"]DependencyResolver(container);
        }
    }
}